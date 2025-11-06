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
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(Customer customer)
        {
            string query = @"INSERT INTO customers (user_id, address) 
                             VALUES (@user_id, @address);SELECT LAST_INSERT_ID();";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@user_id", customer.userId);
            cmd.Parameters.AddWithValue("@address", customer.address);

            try
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting room: " + ex.Message);
                return 0;
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            string query = "SELECT * FROM customers";

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
                            var customer = new Customer
                            {
                                customerId = reader.GetInt32("customer_id"),
                                userId = reader.GetInt32("user_id"),
                                address = reader.GetString("address")
                            };

                            customers.Add(customer);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while getting customers: {ex.Message}", ex);
                }
            }

            return customers;
        }


        public override Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
