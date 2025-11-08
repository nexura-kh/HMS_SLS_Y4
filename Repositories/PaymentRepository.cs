using HMS_SLS_Y4.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HMS_SLS_Y4.Repositories
{
    public class PaymentRepository
    {
        private readonly string _connectionString;

        public PaymentRepository()
        {
            _connectionString = DatabaseHelper.ConnectionString;
        }

        /// <summary>
        /// Returns order item rows joined with booking/customer/room/payment info.
        /// One row per order_item (so you can pay per item). LEFT JOIN payments so unpaid items still show.
        /// </summary>
        public DataTable GetOrdersForPayment()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT
                    oi.orderItem_id AS OrderItemID,
                    fo.order_id AS OrderID,
                    b.booking_id AS BookingID,
                    u.full_name AS CustomerName,
                    r.room_number AS RoomNumber,
                    f.food_name AS FoodName,
                    oi.quantity AS Quantity,
                    oi.total_price AS ItemTotal,
                    p.payment_id AS PaymentID,
                    p.amount AS PaidAmount,
                    p.payment_date AS PaymentDate,
                    fo.order_date AS OrderDate,
                    fo.status AS OrderStatus
                FROM order_items oi
                JOIN food_orders fo ON oi.order_id = fo.order_id
                JOIN bookings b ON fo.booking_id = b.booking_id
                JOIN customers c ON b.customer_id = c.customer_id
                JOIN users u ON c.user_id = u.id
                LEFT JOIN rooms r ON b.room_id = r.room_id
                LEFT JOIN foods f ON oi.food_id = f.food_id
                LEFT JOIN payments p ON p.order_item_id = oi.orderItem_id
                ORDER BY fo.order_date DESC, b.booking_id DESC, oi.orderItem_id DESC;
            ";

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to fetch orders for payment: " + ex.Message, ex);
                }
            }

            return dt;
        }

        /// <summary>
        /// Insert payment record for specific order item (and optionally booking).
        /// Returns inserted payment_id.
        /// </summary>
        public int InsertPayment(int bookingId, int orderItemId, decimal amount)
        {
            if (orderItemId <= 0) throw new ArgumentException("orderItemId must be > 0");

            string insert = @"
                INSERT INTO payments (booking_id, order_item_id, amount)
                VALUES (@bookingId, @orderItemId, @amount);
                SELECT LAST_INSERT_ID();
            ";

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@bookingId", bookingId <= 0 ? (object)DBNull.Value : bookingId);
                cmd.Parameters.AddWithValue("@orderItemId", orderItemId);
                cmd.Parameters.AddWithValue("@amount", amount);

                try
                {
                    conn.Open();
                    var idObj = cmd.ExecuteScalar();
                    return Convert.ToInt32(idObj);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to insert payment: " + ex.Message, ex);
                }
            }
        }
    }
}
