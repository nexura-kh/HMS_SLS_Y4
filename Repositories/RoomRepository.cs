using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Repositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(Room room)
        {
            string query = @"INSERT INTO rooms (room_number, is_available, room_type_id) 
                             VALUES (@roomNumber, @isAvailable, @roomTypeId)";
            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomNumber", room.roomNumber);
            cmd.Parameters.AddWithValue("@isAvailable", room.isAvailable);
            cmd.Parameters.AddWithValue("@roomTypeId", room.roomTypeId);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting room: " + ex.Message);
                return 0;
            }
        }

        public override bool Delete(int id)
        {
            string query = "DELETE FROM rooms WHERE room_id = @roomId";
            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomId", id);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error deleting room: " + ex.Message);
                return false;
            }
        }

        public override List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            string query = @"SELECT r.room_id, r.room_number, r.is_available, r.room_type_id,
                                    rt.type_name, rt.price_per_night, rt.description
                             FROM rooms r
                             INNER JOIN room_types rt ON r.room_type_id = rt.type_id
                             ORDER BY r.room_number;";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Room room = new Room
                    {
                        roomId = reader.GetInt32("room_id"),
                        roomNumber = reader.GetString("room_number"),
                        isAvailable = reader.GetBoolean("is_available"),
                        roomTypeId = reader.GetInt32("room_type_id"),
                        RoomType = new RoomType(
                            reader.GetInt32("room_type_id"),
                            reader.GetString("type_name"),
                            reader.GetDecimal("price_per_night"),
                            reader.GetString("description")
                        )
                    };
                    rooms.Add(room);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching rooms: " + ex.Message);
            }

            return rooms;
        }

        public override Room GetById(int id)
        {
            string query = @"SELECT r.room_id, r.room_number, r.is_available, r.room_type_id,
                                    rt.type_name, rt.capacity, rt.price_per_night, rt.description
                             FROM rooms r
                             INNER JOIN room_types rt ON r.room_type_id = rt.room_type_id
                             WHERE r.room_id = @roomId";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomId", id);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Room
                    {
                        roomId = reader.GetInt32("room_id"),
                        roomNumber = reader.GetString("room_number"),
                        isAvailable = reader.GetBoolean("is_available"),
                        roomTypeId = reader.GetInt32("room_type_id")
                    };
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching room: " + ex.Message);
            }

            return null;
        }

        public override bool Update(Room room)
        {
            string query = @"UPDATE rooms 
                             SET room_number = @roomNumber, 
                                 is_available = @isAvailable, 
                                 room_type_id = @roomTypeId
                             WHERE room_id = @roomId";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomId", room.roomId);
            cmd.Parameters.AddWithValue("@roomNumber", room.roomNumber);
            cmd.Parameters.AddWithValue("@isAvailable", room.isAvailable);
            cmd.Parameters.AddWithValue("@roomTypeId", room.roomTypeId);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating room: " + ex.Message);
                return false;
            }
        }

        // Additional helper methods
        public List<Room> GetAvailableRooms()
        {
            List<Room> rooms = new List<Room>();
            string query = @"SELECT r.room_id, r.room_number, r.is_available, r.room_type_id,
                                    rt.type_name, rt.capacity, rt.price_per_night, rt.description
                             FROM rooms r
                             INNER JOIN room_types rt ON r.room_type_id = rt.room_type_id
                             WHERE r.is_available = 1
                             ORDER BY r.room_number";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Room room = new Room
                    {
                        roomId = reader.GetInt32("room_id"),
                        roomNumber = reader.GetString("room_number"),
                        isAvailable = reader.GetBoolean("is_available"),
                        roomTypeId = reader.GetInt32("room_type_id")
                    };
                    rooms.Add(room);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching available rooms: " + ex.Message);
            }

            return rooms;
        }

        public Room GetByRoomNumber(string roomNumber)
        {
            string query = @"SELECT r.room_id, r.room_number, r.is_available, r.room_type_id,
                                    rt.type_name, rt.capacity, rt.price_per_night, rt.description
                             FROM rooms r
                             INNER JOIN room_types rt ON r.room_type_id = rt.room_type_id
                             WHERE r.room_number = @roomNumber";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Room
                    {
                        roomId = reader.GetInt32("room_id"),
                        roomNumber = reader.GetString("room_number"),
                        isAvailable = reader.GetBoolean("is_available"),
                        roomTypeId = reader.GetInt32("room_type_id"),
                    };
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching room by number: " + ex.Message);
            }

            return null;
        }


        public List<Room> GetRoomList()
        {
            List<Room> roomList = new List<Room>();
            string query = @"SELECT r.room_id,rt.price_per_night, r.room_number, r.is_available, 
                            rt.type_name, rt.type_id,rt.description
                     FROM rooms r
                     JOIN room_types rt ON r.room_type_id = rt.type_id;";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.roomId = reader.GetInt32("room_id");
                        room.roomNumber = reader.GetString("room_number");
                        room.isAvailable = reader.GetBoolean("is_available");
                        room.RoomType = new RoomType(
                            reader.GetInt32("type_id"),
                            reader.GetString("type_name"),
                            reader.GetDecimal("price_per_night"),
                            reader.GetString("description")
                        );


                        roomList.Add(room);
                    }
                }
            }
            return roomList;
        }


        public void DeleteRoom(int roomId)
        {
            string query = "DELETE FROM rooms WHERE room_id = @roomId";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
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


        public int getRoomIdByNumber(string roomNumber)
        {
            string query = "SELECT room_id FROM rooms WHERE room_number = @roomNumber";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error fetching room ID: " + ex.Message);
                }
            }
            return -1; // Return -1 if not found or error occurs
        }
    }
}