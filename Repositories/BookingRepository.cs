using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Models.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Repositories
{
    public class BookingRepository : BaseRepository<Booking>
    {
        public UserRepository userRepository = new UserRepository();
        public CustomerRepository customerRepository = new CustomerRepository();
        public BookingRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(Booking booking)
        {
            string query = @"INSERT INTO bookings (customer_id, room_id, check_in_date, check_out_date, total_amount, booking_date, booking_status) 
                           VALUES (@customer_id, @room_id, @check_in_date, @check_out_date, @total_amount, @booking_date, @booking_status);
                           SELECT LAST_INSERT_ID();";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@customer_id", booking.customerId);
                cmd.Parameters.AddWithValue("@room_id", booking.roomId);
                cmd.Parameters.AddWithValue("@check_in_date", booking.checkInDate);
                cmd.Parameters.AddWithValue("@check_out_date", booking.checkOutDate);
                cmd.Parameters.AddWithValue("@total_amount", booking.totalAmount);
                cmd.Parameters.AddWithValue("@booking_date", booking.bookingDate);
                cmd.Parameters.AddWithValue("@booking_status", booking.bookingStatus);

                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while adding booking: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error while adding booking: {ex.Message}", ex);
                }
            }
        }

        public override bool Delete(int id)
        {
            string query = "DELETE FROM bookings WHERE booking_id = @booking_id";

            using (var conn = new MySqlConnection(ConnectionString))

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@booking_id", id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while deleting booking: {ex.Message}", ex);
                }
            }
        }

        public override List<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();

            string query = @"
                SELECT 
                    b.booking_id, b.customer_id, b.room_id, 
                    b.check_in_date, b.check_out_date, b.total_amount,
                    b.booking_date, b.booking_status,
                    c.customer_id, c.address,
                    u.id, u.full_name, u.dob, u.nationality, u.id_card_number,
                    r.room_id, r.room_number, r.is_available, r.room_type_id,
                    rt.type_id, rt.type_name, rt.price_per_night, rt.description
                FROM bookings b
                INNER JOIN customers c ON b.customer_id = c.customer_id
                INNER JOIN users u ON c.user_id = u.id
                LEFT JOIN rooms r ON b.room_id = r.room_id
                LEFT JOIN room_types rt ON r.room_type_id = rt.type_id
                ORDER BY b.booking_date DESC;
            ";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var booking = new Booking
                    {
                        bookingId = reader.GetInt32("booking_id"),
                        customerId = reader.GetInt32("customer_id"),

                        roomId = reader.IsDBNull(reader.GetOrdinal("room_id"))
                            ? (int?)null
                            : reader.GetInt32("room_id"),

                        checkInDate = reader.IsDBNull(reader.GetOrdinal("check_in_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("check_in_date"),

                        checkOutDate = reader.IsDBNull(reader.GetOrdinal("check_out_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("check_out_date"),

                        totalAmount = reader.IsDBNull(reader.GetOrdinal("total_amount"))
                            ? (decimal?)null
                            : reader.GetDecimal("total_amount"),

                        bookingDate = reader.IsDBNull(reader.GetOrdinal("booking_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("booking_date"),

                        bookingStatus = reader.IsDBNull(reader.GetOrdinal("booking_status"))
                            ? 0
                            : reader.GetInt32("booking_status"),

                        customer = new Customer
                        {
                            customerId = reader.GetInt32("customer_id"),
                            address = reader.IsDBNull(reader.GetOrdinal("address"))
                                ? string.Empty
                                : reader.GetString("address"),

                            User = new HMS_SLS_Y4.Models.User
                            {
                                id = reader.GetInt32("id"),
                                fullName = reader.IsDBNull(reader.GetOrdinal("full_name"))
                                    ? string.Empty
                                    : reader.GetString("full_name"),

                                dob = reader.IsDBNull(reader.GetOrdinal("dob"))
                                    ? DateTime.MinValue
                                    : reader.GetDateTime("dob"),

                                nationality = reader.IsDBNull(reader.GetOrdinal("nationality"))
                                    ? string.Empty
                                    : reader.GetString("nationality"),

                                idCardNumber = reader.IsDBNull(reader.GetOrdinal("id_card_number"))
                                    ? string.Empty
                                    : reader.GetString("id_card_number")
                            }
                        },

                        room = reader.IsDBNull(reader.GetOrdinal("room_id"))
                            ? null
                            : new Room
                            {
                                roomId = reader.GetInt32("room_id"),
                                roomNumber = reader.IsDBNull(reader.GetOrdinal("room_number"))
                                    ? string.Empty
                                    : reader.GetString("room_number"),

                                isAvailable = !reader.IsDBNull(reader.GetOrdinal("is_available")) &&
                                              reader.GetBoolean("is_available"),

                                roomTypeId = reader.IsDBNull(reader.GetOrdinal("room_type_id"))
                                    ? 0
                                    : reader.GetInt32("room_type_id"),

                                roomType = reader.IsDBNull(reader.GetOrdinal("type_id"))
                                    ? null
                                    : new RoomType
                                    {
                                        roomTypeId = reader.GetInt32("type_id"),
                                        typeName = reader.IsDBNull(reader.GetOrdinal("type_name"))
                                            ? string.Empty
                                            : reader.GetString("type_name"),

                                        price = reader.IsDBNull(reader.GetOrdinal("price_per_night"))
                                            ? 0m
                                            : reader.GetDecimal("price_per_night"),

                                        description = reader.IsDBNull(reader.GetOrdinal("description"))
                                            ? string.Empty
                                            : reader.GetString("description")
                                    }
                            }
                    };

                    bookings.Add(booking);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching bookings: " + ex.Message);
            }

            return bookings;
        }


        public override Booking GetById(int id)
        {
            string query = @"
                            SELECT 
                                b.booking_id, b.customer_id, b.room_id, 
                                b.check_in_date, b.check_out_date, b.total_amount,
                                b.booking_date, b.booking_status,
                                c.customer_id, c.address,
                                u.id, u.full_name, u.dob, u.nationality, u.id_card_number,
                                r.room_id, r.room_number, r.is_available, r.room_type_id,
                                rt.type_id, rt.type_name, rt.price_per_night, rt.description
                            FROM bookings b
                            INNER JOIN customers c ON b.customer_id = c.customer_id
                            INNER JOIN users u ON c.user_id = u.id
                            LEFT JOIN rooms r ON b.room_id = r.room_id
                            LEFT JOIN room_types rt ON r.room_type_id = rt.type_id
                            WHERE b.booking_id = @booking_id;
                        ";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@booking_id", id);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var booking = new Booking
                    {
                        bookingId = reader.IsDBNull(reader.GetOrdinal("booking_id")) ? 0 : reader.GetInt32("booking_id"),
                        customerId = reader.IsDBNull(reader.GetOrdinal("customer_id")) ? 0 : reader.GetInt32("customer_id"),
                        roomId = reader.IsDBNull(reader.GetOrdinal("room_id")) ? (int?)null : reader.GetInt32("room_id"),

                        checkInDate = reader.IsDBNull(reader.GetOrdinal("check_in_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("check_in_date"),

                        checkOutDate = reader.IsDBNull(reader.GetOrdinal("check_out_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("check_out_date"),

                        totalAmount = reader.IsDBNull(reader.GetOrdinal("total_amount"))
                            ? (decimal?)null
                            : reader.GetDecimal("total_amount"),

                        bookingDate = reader.IsDBNull(reader.GetOrdinal("booking_date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime("booking_date"),

                        bookingStatus = reader.IsDBNull(reader.GetOrdinal("booking_status"))
                            ? 0
                            : reader.GetInt32("booking_status"),

                        customer = new Customer
                        {
                            customerId = reader.IsDBNull(reader.GetOrdinal("customer_id")) ? 0 : reader.GetInt32("customer_id"),
                            address = reader.IsDBNull(reader.GetOrdinal("address")) ? string.Empty : reader.GetString("address"),

                            User = new HMS_SLS_Y4.Models.User
                            {
                                id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32("id"),
                                fullName = reader.IsDBNull(reader.GetOrdinal("full_name")) ? "Unknown" : reader.GetString("full_name"),
                                nationality = reader.IsDBNull(reader.GetOrdinal("nationality")) ? "N/A" : reader.GetString("nationality"),
                                dob = reader.IsDBNull(reader.GetOrdinal("dob")) ? DateTime.MinValue : reader.GetDateTime("dob"),
                                idCardNumber = reader.IsDBNull(reader.GetOrdinal("id_card_number")) ? "N/A" : reader.GetString("id_card_number")
                            }
                        },

                        room = reader.IsDBNull(reader.GetOrdinal("room_id"))
                            ? null
                            : new Room
                            {
                                roomId = reader.IsDBNull(reader.GetOrdinal("room_id")) ? 0 : reader.GetInt32("room_id"),
                                roomNumber = reader.IsDBNull(reader.GetOrdinal("room_number")) ? "N/A" : reader.GetString("room_number"),
                                isAvailable = !reader.IsDBNull(reader.GetOrdinal("is_available")) && reader.GetBoolean("is_available"),
                                roomTypeId = reader.IsDBNull(reader.GetOrdinal("room_type_id")) ? 0 : reader.GetInt32("room_type_id"),

                                roomType = reader.IsDBNull(reader.GetOrdinal("type_id"))
                                    ? null
                                    : new RoomType
                                    {
                                        roomTypeId = reader.IsDBNull(reader.GetOrdinal("type_id")) ? 0 : reader.GetInt32("type_id"),
                                        typeName = reader.IsDBNull(reader.GetOrdinal("type_name")) ? "N/A" : reader.GetString("type_name"),
                                        price = reader.IsDBNull(reader.GetOrdinal("price_per_night")) ? 0m : reader.GetDecimal("price_per_night"),
                                        description = reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description")
                                    }
                            }
                    };

                    return booking;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error while fetching booking (ID: {id}): {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }


        public override bool Update(Booking booking)
        {
            string query = @"UPDATE bookings 
                           SET customer_id = @customer_id, 
                               room_id = @room_id, 
                               check_in_date = @check_in_date, 
                               check_out_date = @check_out_date, 
                               total_amount = @total_amount, 
                               booking_status = @booking_status
                           WHERE booking_id = @booking_id";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@booking_id", booking.bookingId);
                cmd.Parameters.AddWithValue("@customer_id", booking.customerId);
                cmd.Parameters.AddWithValue("@room_id", booking.roomId);
                cmd.Parameters.AddWithValue("@check_in_date", booking.checkInDate);
                cmd.Parameters.AddWithValue("@check_out_date", booking.checkOutDate);
                cmd.Parameters.AddWithValue("@total_amount", booking.totalAmount);
                cmd.Parameters.AddWithValue("@booking_status", booking.bookingStatus);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while updating booking: {ex.Message}", ex);
                }
            }
        }
        public bool UpdateBookingStatus(int bookingId, int status)
        {
            string query = @"UPDATE bookings 
                           SET booking_status = @booking_status
                           WHERE booking_id = @booking_id";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@booking_id", bookingId);
                cmd.Parameters.AddWithValue("@booking_status", status);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error while updating booking status: {ex.Message}", ex);
                }
            }
        }
    }
}