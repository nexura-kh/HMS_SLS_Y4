using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HMS_SLS_Y4.Repositories
{
    public class PaymentRepository:BaseRepository<Payment>
    {
        public PaymentRepository() : base(DatabaseHelper.ConnectionString) {}

        public override int Add(Payment payment)
        {
            string insert = @"
                INSERT INTO payments (booking_id, amount, payment_date, payment_status, payment_method)
                VALUES (@booking_id, @amount, @payment_date, @payment_status, @payment_method);
                SELECT LAST_INSERT_ID();
            ";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@booking_id", payment.BookingId);
                cmd.Parameters.AddWithValue("@amount", payment.Amount);
                cmd.Parameters.AddWithValue("@payment_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@payment_status", payment.PaymentStatus??"Paid");
                cmd.Parameters.AddWithValue("@payment_method", payment.PaymentMethod??"Cash");

                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to insert payment: " + ex.Message, ex);
                }
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Payment> GetAll()
        {
            string query = @"
                             SELECT u.full_name AS customer_name,
                                    u.nationality,
                                    r.room_number,
                                    rt.type_name AS room_type,
                                    rt.price_per_night AS room_price,
                                    b.booking_id,
                                    b.check_in_date,
                                    b.check_out_date,
                                    b.booking_status,
                                    fo.order_date,
                                    fo.status AS order_status,
                                    oi.orderItem_id,
                                    oi.quantity,
                                    oi.note,
                                    oi.total_price AS order_total_price,
                                    f.food_name,
                                    f.price AS food_price,
                                    p.payment_id,
                                    p.amount AS payment_amount,
                                    p.payment_date,
                                    p.payment_status,
                                    p.payment_method
                                FROM users u
                                JOIN customers c ON u.id = c.user_id
                                JOIN bookings b ON c.customer_id = b.customer_id
                                LEFT JOIN rooms r ON b.room_id = r.room_id
                                LEFT JOIN room_types rt ON r.room_type_id = rt.type_id
                                LEFT JOIN food_orders fo ON b.booking_id = fo.booking_id
                                LEFT JOIN order_items oi ON fo.order_id = oi.order_id
                                LEFT JOIN foods f ON oi.food_id = f.food_id
                                LEFT JOIN payments p 
                                    ON p.booking_id = b.booking_id 
                                    OR p.order_item_id = oi.orderItem_id
                                ORDER BY fo.order_date DESC;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                var payments = new List<Payment>();
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var payment = new Payment
                            {
                                PaymentId = reader.GetInt32("payment_id"),
                                Amount = reader.GetDecimal("payment_amount"),
                                PaymentDate = reader.GetDateTime("payment_date"),
                                PaymentStatus = reader.GetString("payment_status"),
                                PaymentMethod = reader.GetString("payment_method"),
                            };
                            payments.Add(payment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve payments: " + ex.Message, ex);
                }
                return payments;
            }
        }

        public override Payment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Payment entity)
        {
            throw new NotImplementedException();
        }
        public (string Status, string Method) GetPaymentStatus(int bookingID)
        {
            string query = @"
                            SELECT p.payment_status, p.payment_method
                            FROM payments p
                            WHERE p.booking_id = @BookingId
                            ORDER BY p.payment_date DESC
                            LIMIT 1;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", bookingID);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string status = reader["payment_status"] != DBNull.Value
                            ? reader["payment_status"].ToString()
                            : "Pending";

                        string method = reader["payment_method"] != DBNull.Value
                            ? reader["payment_method"].ToString()
                            : "N/A";

                        return (status, method);
                    }
                    else
                    {
                        return ("No Payment", "N/A");
                    }
                }
            }
        }
    }
}
