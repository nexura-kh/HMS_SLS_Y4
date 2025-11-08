using System;
using System.Collections.Generic;
using HMS_SLS_Y4.Data;
using MySql.Data.MySqlClient;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;

namespace HMS_SLS_Y4.Seeders
{
    public class SeedReservation
    {
        private readonly UserRepository userRepo = new UserRepository();
        private readonly CustomerRepository customerRepo = new CustomerRepository();
        private readonly RoomRepository roomRepo = new RoomRepository();
        private readonly BookingRepository bookingRepo = new BookingRepository();
        private readonly RoomTypeRepository roomTypeRepo = new RoomTypeRepository();

        private readonly string connStr = DatabaseHelper.ConnectionString;

        public void SeedUsers()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SET FOREIGN_KEY_CHECKS = 0;
                    TRUNCATE TABLE users;
                    TRUNCATE TABLE customers;
                    TRUNCATE TABLE bookings;
                    SET FOREIGN_KEY_CHECKS = 1;
                ";
                cmd.ExecuteNonQuery();
            }

            var users = new List<User>
            {
                new User { fullName = "Kong Chan", dob = new DateTime(2004,1,1), nationality = "Cambodian", idCardNumber="2025001"},
                new User { fullName = "Em Pisey", dob = new DateTime(2004,11,6), nationality = "British", idCardNumber="2025002"},
                new User { fullName = "Lim Khimheng", dob = new DateTime(2004,8,10), nationality = "Chinese", idCardNumber="2025003"},
                new User { fullName = "Saroth Tola", dob = new DateTime(2004,10,22), nationality = "French", idCardNumber="2025004"},
            };

            foreach (var user in users)
            {
                userRepo.Add(user);
            }
        }

        public void SeedCustomers()
        {
            var users = userRepo.GetAll();
            var customers = new List<Customer>
            {
                new Customer { userId = users[0].id, address = "Phnom Penh" },
                new Customer { userId = users[1].id, address = "London" },
                new Customer { userId = users[2].id, address = "Beijing" },
                new Customer { userId = users[3].id, address = "Marseille" },
            };

            foreach (var customer in customers)
            {
                customerRepo.Add(customer);
            }
        }

        public void SeedReservations()
        {
            var customers = customerRepo.GetAll();
            var rooms = roomRepo.GetAll();

            var reservations = new List<Booking>
            {
                new Booking { customerId = customers[0].customerId, roomId = rooms[0].roomId, checkInDate = DateTime.Now, checkOutDate = DateTime.Now.AddDays(2), totalAmount = rooms[0].RoomType.price, bookingDate = DateTime.Now, bookingStatus = 1 },
                new Booking { customerId = customers[1].customerId, roomId = rooms[1].roomId, checkInDate = DateTime.Now, checkOutDate = DateTime.Now.AddDays(3), totalAmount = rooms[1].RoomType.price, bookingDate = DateTime.Now, bookingStatus = 2 },
                new Booking { customerId = customers[2].customerId, roomId = rooms[2].roomId, checkInDate = DateTime.Now, checkOutDate = DateTime.Now.AddDays(1), totalAmount = rooms[2].RoomType.price, bookingDate = DateTime.Now, bookingStatus = 2 },
                new Booking { customerId = customers[3].customerId, roomId = rooms[3].roomId, checkInDate = DateTime.Now, checkOutDate = DateTime.Now.AddDays(4), totalAmount = rooms[3].RoomType.price, bookingDate = DateTime.Now, bookingStatus = 1 },
            };

            foreach (var reservation in reservations)
            {
                bookingRepo.Add(reservation);
                roomRepo.updateRoomStatus(reservation.roomId.Value, false);
            }
        }
    }
}
