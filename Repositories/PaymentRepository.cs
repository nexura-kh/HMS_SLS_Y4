using HMS_SLS_Y4.Components;
using HMS_SLS_Y4.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HMS_SLS_Y4.Repositories
{
    internal class PaymentRepository:BaseRepository<Payment>
    {
        public PaymentRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Payment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetPaymentsWithOrders()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    p.PaymentID,
                    o.OrderID,
                    o.CustomerName,
                    o.RoomNumber,
                    p.Amount,
                    p.PaymentDate
                FROM payments p
                INNER JOIN orders o ON p.OrderID = o.OrderID
                ORDER BY p.PaymentDate DESC;
            ";

            using (MySqlConnection conn = new MySqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to load payments from orders: " + ex.Message);
                }
            }

            return dt;
        }

        public override bool Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
