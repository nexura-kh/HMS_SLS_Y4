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
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base(DatabaseHelper.ConnectionString) {}

        public override int Add(User user)
        {
            MessageBox.Show($"Debug: Adding user with name {user.fullName}, DOB {user.dob}, Nationality {user.nationality}, ID Card Number {user.idCardNumber}, ID Card Type {user.idCardType}");
            string query = @"INSERT INTO users (full_name, dob, nationality, id_card_number, id_card_type) 
                           VALUES (@full_name, @dob, @nationality, @id_card_number, @id_card_type);
                           SELECT LAST_INSERT_ID();";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@full_name", user.fullName);
                cmd.Parameters.AddWithValue("@dob", user.dob);
                cmd.Parameters.AddWithValue("@nationality", user.nationality);
                cmd.Parameters.AddWithValue("@id_card_number", user.idCardNumber);
                cmd.Parameters.AddWithValue("@id_card_type", (int)user.idCardType);

                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while adding user: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error while adding user: {ex.Message}", ex);
                }
            }
        }

        public override List<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM users";

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
                            //users.Add(MapToUser(reader));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while getting users: {ex.Message}", ex);
                }
            }

            return users;
        }

        public override User GetById(int id)
        {
            string query = "SELECT * FROM users WHERE id = @id";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //return MapToUser(reader);
                        }
                    }
                }
                catch (MySqlException ex)
        {
                    throw new Exception($"Database error while getting user: {ex.Message}", ex);
                }
            }

            return null;
        }

        public override bool Update(User user)
            {
            string query = @"UPDATE users 
                           SET full_name = @full_name, 
                               dob = @dob, 
                               nationality = @nationality, 
                               id_card_number = @id_card_number, 
                               id_card_type = @id_card_type
                           WHERE id = @id";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
                {
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@full_name", user.fullName);
                cmd.Parameters.AddWithValue("@dob", user.dob);
                cmd.Parameters.AddWithValue("@nationality", user.nationality);
                cmd.Parameters.AddWithValue("@id_card_number", user.idCardNumber);
                cmd.Parameters.AddWithValue("@id_card_type", (int)user.idCardType);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while updating user: {ex.Message}", ex);
                }
            }
        }

        public override bool Delete(int id)
        {
            string query = "DELETE FROM users WHERE id = @id";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while deleting user: {ex.Message}", ex);
                }
            }
        }

        
    }
}
