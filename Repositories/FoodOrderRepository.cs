using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HMS_SLS_Y4.Repositories
{
    public class FoodOrderRepository : BaseRepository<FoodOrder>
    {
        public FoodOrderRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(FoodOrder foodOrder)
        {
            string query = @"INSERT INTO food_orders (booking_id, order_date, status) 
                             VALUES (@booking_id, @order_date, @status);SELECT LAST_INSERT_ID();";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@booking_id", foodOrder.bookingId);
            cmd.Parameters.AddWithValue("@order_date", foodOrder.orderDate);
            cmd.Parameters.AddWithValue("@status", foodOrder.status);

            try
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting food order: " + ex.Message);
                return 0;
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<FoodOrder> GetAll()
        {
            string query = "SELECT * FROM food_orders";
            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var orders = new List<FoodOrder>();
                        while (reader.Read())
                        {
                            var order = new FoodOrder
                            {
                                orderId = reader.GetInt32("order_id"),
                                bookingId = reader.GetInt32("booking_id"),
                                orderDate = reader.GetDateTime("order_date"),
                                status = reader.GetString("status")
                            };
                            orders.Add(order);
                        }
                        return orders;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error retrieving food orders: " + ex.Message);
                    return new List<FoodOrder>();
                }
            }
        }

        public override FoodOrder GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(FoodOrder entity)
        {
            throw new NotImplementedException();
        }


    }
}
