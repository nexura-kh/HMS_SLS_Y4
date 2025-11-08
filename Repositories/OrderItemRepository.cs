using HMS_SLS_Y4.Components;
using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Enums;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Models.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>
    {
        public OrderItemRepository() : base(DatabaseHelper.ConnectionString)
        {
        }

        public override int Add(OrderItem orderItem)
        {

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                INSERT INTO order_items (order_id, food_id, quantity, note, total_price)
                VALUES (@orderId, @foodId, @quantity, @note, @totalPrice);SELECT LAST_INSERT_ID();";
                cmd.Parameters.AddWithValue("@orderId", orderItem.OrderId);
                cmd.Parameters.AddWithValue("@foodId", orderItem.FoodId);
                cmd.Parameters.AddWithValue("@quantity", orderItem.Quantity);
                cmd.Parameters.AddWithValue("@note", orderItem.note ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@totalPrice", orderItem.totalPrice);

                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error inserting order item: " + ex.Message);
                    throw;
                }
            }
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<OrderItem> GetAll()
        {
            string query = @"SELECT 
                u.full_name AS customer_name,
                u.nationality,
                r.room_number,
                rt.type_name AS room_type,
                b.check_in_date,
                b.check_out_date,
                b.booking_status,
                fo.order_date,
                fo.status AS order_status,
                oi.orderItem_id,
                oi.quantity,
                oi.note,
                oi.total_price,
                f.food_name,
                f.price AS food_price
            FROM users u
            JOIN customers c ON u.id = c.user_id
            JOIN bookings b ON c.customer_id = b.customer_id
            LEFT JOIN rooms r ON b.room_id = r.room_id
            LEFT JOIN room_types rt ON r.room_type_id = rt.type_id
            LEFT JOIN food_orders fo ON b.booking_id = fo.booking_id
            LEFT JOIN order_items oi ON fo.order_id = oi.order_id
            LEFT JOIN foods f ON oi.food_id = f.food_id
            ORDER BY fo.order_date DESC;
";
            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var orderItems = new List<OrderItem>();
                        while (reader.Read())
                        {
                            var orderItem = new OrderItem
                            {
                                OrderItemId = reader.GetInt32("orderItem_id"),
                                Quantity = reader.GetInt32("quantity"),
                                totalPrice = reader.GetDecimal("total_price"),
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? null : reader.GetString("note"),
                                Booking = new Booking
                                {
                                    checkInDate = reader.GetDateTime("check_in_date"),
                                    checkOutDate = reader.GetDateTime("check_out_date"),
                                    bookingStatus = reader.GetInt32("booking_status"),
                                    room = new HMS_SLS_Y4.Models.Room
                                    {
                                        roomNumber = reader.IsDBNull(reader.GetOrdinal("room_number")) ? "N/A" : reader.GetString("room_number"),
                                    },
                                    customer = new HMS_SLS_Y4.Models.Customer
                                    {
                                        User = new User
                                        {
                                            fullName = reader.GetString("customer_name"),
                                            nationality = reader.GetString("nationality"),
                                        },
                                    }
                                },
                                FoodOrder = new FoodOrder
                                {
                                    orderDate = reader.GetDateTime("order_date"),
                                    status = reader.GetString("order_status"),
                                },
                                Food = new HMS_SLS_Y4.Models.Food
                                {
                                    FoodName = reader.GetString("food_name"),
                                    Price = reader.GetDecimal("food_price"),
                                }
                            };
                            orderItems.Add(orderItem);
                        }
                        return orderItems;
                    }
                }
                catch (MySqlException ex)
                {
                    throw;
                }
            }

        }

        public override OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderItemDTOcs> GetOrderItemsByBookingId(int bookingId)
        {
            
            List<OrderItemDTOcs> orderItems = new List<OrderItemDTOcs>();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                       string query = @"
                            SELECT 
                        b.booking_status,
                        fo.order_date,
                        fo.status AS order_status,            
                        oi.quantity,
                        oi.note,
                        oi.total_price,
                        f.food_name,
                        f.description
                    FROM users u
                    JOIN customers c ON u.id = c.user_id
                    JOIN bookings b ON c.customer_id = b.customer_id
                    LEFT JOIN food_orders fo ON b.booking_id = fo.booking_id
                    LEFT JOIN order_items oi ON fo.order_id = oi.order_id
                    LEFT JOIN foods f ON oi.food_id = f.food_id WHERE b.booking_id = 1
                    ORDER BY fo.order_date DESC ;
                ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new OrderItemDTOcs
                            {
                                // assign properties from reader to OrderItemDTOcs
                                itemName = reader.GetString("food_name"),
                                description = reader.GetString("description"),
                                totalPrice = reader.GetDecimal("total_price"),
                                quantity = reader.GetInt32("quantity"),
                                status = Enum.TryParse<FoodOrderStatus>(reader.GetString("order_status"), out var status) ? status : FoodOrderStatus.Cancel,
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? null : reader.GetString("note")
                            };

                            orderItems.Add(item);
                        }
                    }
                }
            }

            return orderItems;
        }




    }
}
