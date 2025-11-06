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
                INSERT INTO order_item (order_id, food_id, quantity, note, total_price)
                VALUES (@orderId, @foodId, @quantity, @note, @totalPrice);";
                cmd.Parameters.AddWithValue("@orderId", orderItem.OrderId);
                cmd.Parameters.AddWithValue("@foodId", orderItem.FoodId);
                cmd.Parameters.AddWithValue("@quantity", orderItem.Quantity);
                cmd.Parameters.AddWithValue("@note", orderItem.note ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@totalPrice", orderItem.totalPrice);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    long insertedId = cmd.LastInsertedId; // newly created orderItem_id
                                                          // use insertedId if needed
                }
                catch (MySqlException ex)
                {
                    // handle DB errors (log or show message)
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
            throw new NotImplementedException();
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
