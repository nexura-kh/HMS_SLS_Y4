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
        public OrderItemRepository() : base(DatabaseHelper.ConnectionString){}
        public OrderItemDTO OrderItemDTO { get; set; }

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
            var query = @"DELETE FROM order_items WHERE orderItem_id = @orderItemId;";
            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@orderItemId", id);
                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error deleting order item: " + ex.Message);
                    return false;
                }
            }
        }

        public override List<OrderItem> GetAll()
        {
            string query = @"
        SELECT 
            u.full_name AS customer_name,
            u.nationality,
            r.room_id,
            r.room_number,
            rt.type_name AS room_type,
            rt.price_per_night AS room_price,
            b.booking_id,
            b.check_in_date,
            b.check_out_date,
            b.booking_status,
            fo.order_id,
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

            var orderItems = new List<OrderItem>();

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var orderItem = new OrderItem
                            {
                                OrderItemId = reader.IsDBNull(reader.GetOrdinal("orderItem_id")) ? 0 : reader.GetInt32("orderItem_id"),
                                Quantity = reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity"),
                                totalPrice = reader.IsDBNull(reader.GetOrdinal("total_price")) ? 0m : reader.GetDecimal("total_price"),
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? string.Empty : reader.GetString("note"),

                                Booking = new Booking
                                {
                                    bookingId = reader.IsDBNull(reader.GetOrdinal("booking_id")) ? 0 : reader.GetInt32("booking_id"),
                                    checkInDate = reader.IsDBNull(reader.GetOrdinal("check_in_date")) ? DateTime.MinValue : reader.GetDateTime("check_in_date"),
                                    checkOutDate = reader.IsDBNull(reader.GetOrdinal("check_out_date")) ? DateTime.MinValue : reader.GetDateTime("check_out_date"),
                                    bookingStatus = reader.IsDBNull(reader.GetOrdinal("booking_status")) ? 0 : reader.GetInt32("booking_status"),

                                    room = new HMS_SLS_Y4.Models.Room
                                    {
                                        roomId = reader.IsDBNull(reader.GetOrdinal("room_id")) ? 0 : reader.GetInt32("room_id"),
                                        roomNumber = reader.IsDBNull(reader.GetOrdinal("room_number")) ? "N/A" : reader.GetString("room_number")
                                    },

                                    roomType = new RoomType
                                    {
                                        typeName = reader.IsDBNull(reader.GetOrdinal("room_type")) ? "N/A" : reader.GetString("room_type"),
                                        price = reader.IsDBNull(reader.GetOrdinal("room_price")) ? 0m : reader.GetDecimal("room_price"),
                                    },

                                    customer = new HMS_SLS_Y4.Models.Customer
                                    {
                                        User = new User
                                        {
                                            fullName = reader.IsDBNull(reader.GetOrdinal("customer_name")) ? "Unknown" : reader.GetString("customer_name"),
                                            nationality = reader.IsDBNull(reader.GetOrdinal("nationality")) ? "N/A" : reader.GetString("nationality")
                                        }
                                    }
                                },

                                FoodOrder = new FoodOrder
                                {
                                    orderId = reader.IsDBNull(reader.GetOrdinal("order_id")) ? 0 : reader.GetInt32("order_id"),
                                    orderDate = reader.IsDBNull(reader.GetOrdinal("order_date")) ? DateTime.MinValue : reader.GetDateTime("order_date"),
                                    status = reader.IsDBNull(reader.GetOrdinal("order_status")) ? "Pending" : reader.GetString("order_status"),
                                },

                                Food = new HMS_SLS_Y4.Models.Food
                                {
                                    FoodName = reader.IsDBNull(reader.GetOrdinal("food_name")) ? "N/A" : reader.GetString("food_name"),
                                    Price = reader.IsDBNull(reader.GetOrdinal("food_price")) ? 0m : reader.GetDecimal("food_price"),
                                }
                            };

                            orderItems.Add(orderItem);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error loading order items: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return orderItems;
        }


        public override OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderItemDTO GetOrderItemById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                b.booking_status,
                fo.order_date,
                fo.status AS order_status,    
                oi.orderItem_id,
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
            LEFT JOIN foods f ON oi.food_id = f.food_id
            WHERE oi.orderItem_id = @OrderItemId
            ORDER BY fo.order_date DESC;
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderItemId", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderItemDTO
                            {
                                orderItemId = reader.GetInt32("orderItem_id"),
                                itemName = reader.GetString("food_name"),
                                description = reader.GetString("description"),
                                totalPrice = reader.GetDecimal("total_price"),
                                quantity = reader.GetInt32("quantity"),
                                status = Enum.TryParse<FoodOrderStatus>(reader.GetString("order_status"), out var status) ? status : FoodOrderStatus.Cancel,
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? null : reader.GetString("note")
                            };
                        }
                    }
                }
            }

            return null;
        }

        public override bool Update(OrderItem entity)
        {
            var query = @"  UPDATE order_items
                            SET food_id = @food_id,
                                quantity = @quantity,
                                note = @note,
                                total_price = @totalPrice
                            WHERE orderItem_id = @orderItemId;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@food_id", entity.FoodId);
                cmd.Parameters.AddWithValue("@quantity", entity.Quantity);
                cmd.Parameters.AddWithValue("@note", entity.note ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@totalPrice", entity.totalPrice);
                cmd.Parameters.AddWithValue("@orderItemId", entity.OrderItemId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error updating order item: " + ex.Message);
                    return false;
                }
            }
        }

        public List<OrderItemDTO> GetOrderItemsByBookingId(int bookingId)
        {
            List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

            string query = @"
                            SELECT 
                                b.booking_status,
                                fo.order_date,
                                fo.status AS order_status,    
                                oi.orderItem_id,
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
                            LEFT JOIN foods f ON oi.food_id = f.food_id
                            WHERE b.booking_id = @bookingId
                            ORDER BY fo.order_date DESC;
                        ";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new OrderItemDTO
                            {
                                orderItemId = reader.IsDBNull(reader.GetOrdinal("orderItem_id")) ? 0 : reader.GetInt32("orderItem_id"),
                                itemName = reader.IsDBNull(reader.GetOrdinal("food_name")) ? string.Empty : reader.GetString("food_name"),
                                description = reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                                totalPrice = reader.IsDBNull(reader.GetOrdinal("total_price")) ? 0m : reader.GetDecimal("total_price"),
                                quantity = reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity"),
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? string.Empty : reader.GetString("note"),
                                status = Enum.TryParse<FoodOrderStatus>(
                                    reader.IsDBNull(reader.GetOrdinal("order_status")) ? "Cancel" : reader.GetString("order_status"),
                                    out var status
                                ) ? status : FoodOrderStatus.Cancel
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
