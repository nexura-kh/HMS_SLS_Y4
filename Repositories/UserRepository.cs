using HMS_SLS_Y4.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HMS_SLS_Y4.Repositories
{
    public class UserRepository
    {
         string conStr = DatabaseHelper.ConnectionString;

        public bool ValidateUser(string email, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // true if found, false if not
                }
            }
        }
    }
}
