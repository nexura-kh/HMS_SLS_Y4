using HMS_SLS_Y4.Components;
using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            string query = "SELECT * FROM order_item";
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
                                OrderItemId = reader.GetInt32("order_item_id"),
                                OrderId = reader.GetInt32("order_id"),
                                FoodId = reader.GetInt32("food_id"),
                                Quantity = reader.GetInt32("quantity"),
                                note = reader.IsDBNull(reader.GetOrdinal("note")) ? null : reader.GetString("note"),
                                totalPrice = reader.GetDecimal("total_price")
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
    }
}
