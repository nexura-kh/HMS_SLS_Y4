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
    public class RoomTypeRepository:BaseRepository<RoomType>
    {

        String StrConn = DatabaseHelper.ConnectionString;

        public RoomTypeRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(RoomType roomType)
        {
            string query = @"INSERT INTO room_types (type_name, description, price_per_night) 
                             VALUES (@roomName, @roomDescription, @roomPrice)";

            using (MySqlConnection conn = new MySqlConnection(StrConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomName", roomType.typeName);
                    cmd.Parameters.AddWithValue("@roomDescription", roomType.description);
                    cmd.Parameters.AddWithValue("@roomPrice", roomType.price);

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

                return 1;
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<RoomType> GetAll()
        {
            throw new NotImplementedException();
        }

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

                                RoomType roomType = new RoomType(roomTypeId, typeName,price,description);
                                roomTypes.Add(roomType);
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
            return roomTypes;
        }

        public override RoomType GetById(int id)
        {
            throw new NotImplementedException();
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
                                int roomTypeID = reader.GetInt32("type_id");
                                string typeName = reader.GetString("type_name");
                                decimal price = reader.GetDecimal("price_per_night");
                                string description = reader.GetString("description");
                                roomType = new RoomType(roomTypeID,typeName, price, description);
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


        public override bool Update(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
