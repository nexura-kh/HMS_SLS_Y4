using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Repositories
{
    public class RoomRepository
    {
        String StrConn = Data.DatabaseHelper.ConnectionString;


        public bool InsertRoom(int roomNumber, bool isAvailable, int roomTypeId)
        {
            string query = @"INSERT INTO room (room_number, is_available, room_type_id) 
                             VALUES (@roomNumber, @isAvailable, @roomTypeId)";

            using (MySqlConnection conn = new MySqlConnection(StrConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // ✅ Add parameters safely
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                    cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                    cmd.Parameters.AddWithValue("@roomTypeId", roomTypeId);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                       
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error inserting room: " + ex.Message);
                    }
                }

                return true;
            }
        }
    }
}
