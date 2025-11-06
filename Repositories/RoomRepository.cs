using HMS_SLS_Y4.Models;
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


        public List<Room1> GetRoomList()
        {
            List<Room1> roomList = new List<Room1>();
            string query = @"SELECT r.room_id,rt.price_per_night, r.room_number, r.is_available, 
                            rt.type_name, rt.type_id,rt.description
                     FROM room r
                     JOIN room_types rt ON r.room_type_id = rt.type_id;";

            using (MySqlConnection conn = new MySqlConnection(StrConn))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room1 room = new Room1();
                        room.RoomId = reader.GetInt32("room_id");
                        room.RoomNumber = reader.GetString("room_number");
                        room.IsAvailable = reader.GetBoolean("is_available");
                        room.RoomType = new RoomType
                        {
                            RoomTypeId = reader.GetInt16("type_id"),
                            TypeName = reader.GetString("type_name"),
                            Price = reader.GetDecimal("price_per_night"),
                            Description = reader.GetString("description")
                        };
                        

                        roomList.Add(room);
                    }
                }
            }
            return roomList;
        }


        public void DeleteRoom(int roomId)
        {
            string query = "DELETE FROM room WHERE room_id = @roomId";
            using (MySqlConnection conn = new MySqlConnection(StrConn))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room deleted successfully.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error deleting room: " + ex.Message);
                }
            }
        }
    }
}
