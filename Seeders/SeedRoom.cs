using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HMS_SLS_Y4.Seeders
{
    public class SeedRoom
    {
        private readonly string connStr = DatabaseHelper.ConnectionString;

        public void SeedRoomTypes()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    SET FOREIGN_KEY_CHECKS = 0;
                                    TRUNCATE TABLE rooms;
                                    TRUNCATE TABLE room_types;
                                    SET FOREIGN_KEY_CHECKS = 1;
                                   ";
                cmd.ExecuteNonQuery();
            }

            var roomTypeRepo = new RoomTypeRepository();

            var roomTypes = new List<RoomType>
            {
                new RoomType(0,"Single Fan", 10m, "One bed with a fan"),
                new RoomType(0,"Single AC", 15m, "One bed with an AC"),
                new RoomType(0,"Twins Fan", 25m, "Two beds with two fans"),
                new RoomType(0,"Twins AC", 30m, "Two beds with two ACs")
            };

            foreach (var roomType in roomTypes)
            {
                roomTypeRepo.Add(roomType);
            }
        }

        public void SeedRooms()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM rooms";
                cmd.ExecuteNonQuery();
            }

            var roomRepo = new RoomRepository();

            var rooms = new List<Room>
            {
                new Room { roomId = 0, roomNumber = "001", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "002", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "003", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "004", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "005", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "006", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "007", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "008", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "009", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "010", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "011", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "012", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "013", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "014", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "015", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "016", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "017", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "018", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "019", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "020", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "021", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "022", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "023", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "024", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "025", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "026", isAvailable = true, roomTypeId = 2 },
                new Room { roomId = 0, roomNumber = "027", isAvailable = true, roomTypeId = 3 },
                new Room { roomId = 0, roomNumber = "028", isAvailable = true, roomTypeId = 4 },
                new Room { roomId = 0, roomNumber = "029", isAvailable = true, roomTypeId = 1 },
                new Room { roomId = 0, roomNumber = "030", isAvailable = true, roomTypeId = 2 }
            };

            foreach (var room in rooms)
            {
                roomRepo.Add(room);
            }
        }
    }
}
