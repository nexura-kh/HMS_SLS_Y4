using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS_SLS_Y4.Repositories
{
    public class RoomTypeRepository
    {

        String StrConn = DatabaseHelper.ConnectionString;

        public List<RoomType> GetAllRoomTypes()
        {
           // Create a list to store the room types
            List<RoomType> roomTypes = new List<RoomType>();

            using (MySqlConnection conn = new MySqlConnection(StrConn))
            {
                string query = "SELECT type_id, type_name, price_per_night, description FROM room_types";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int roomTypeId = reader.GetInt32("type_id");
                                string typeName = reader.GetString("type_name");
                                decimal price = reader.GetDecimal("price_per_night");
                                string description = reader.GetString("description");

                                RoomType roomType = new RoomType(roomTypeId, typeName, price, description);
                                roomTypes.Add(roomType);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // Handle database-specific exceptions
                        Console.WriteLine("Database error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        // Handle general exceptions
                        Console.WriteLine("Unexpected error: " + ex.Message);
                    }
                }
            }
            return roomTypes;
        }

        public RoomType GetRoomTypeById(int roomTypeId)
        {
            RoomType? roomType = null;
            using (MySqlConnection conn = new MySqlConnection(StrConn))
            {
                string query = "SELECT type_id, type_name, price_per_night, description FROM room_types WHERE type_id = @RoomTypeId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomTypeId", roomTypeId);
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string typeName = reader.GetString("type_name");
                                decimal price = reader.GetDecimal("price_per_night");
                                string description = reader.GetString("description");
                                roomType = new RoomType(roomTypeId, typeName, price, description);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Database error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unexpected error: " + ex.Message);
                    }
                }
            }
            return roomType;
        }

             
        public void UpdateRoomType(decimal pricePerNight, string description, int typeId)
        {

        using (MySqlConnection conn = new MySqlConnection(StrConn))
        {
        

            string query = @"UPDATE room_types 
                         SET price_per_night = @pricePerNight, description = @description 
                         WHERE type_id = @typeId";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                   

                    cmd.Parameters.AddWithValue("@pricePerNight", pricePerNight);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@typeId", typeId);

                

                    int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                        MessageBox.Show("Room type updated successfully.");
                }
                else
                {
                    MessageBox.Show("No record found with the given type_id.");
                }
            }
        }
    }



}
}
