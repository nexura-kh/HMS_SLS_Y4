using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
        public BookingRepository() : base(DatabaseHelper.ConnectionString){}

        public override int Add(Booking booking)
        {
            string query = @"INSERT INTO bookings (customer_id, room_id, check_in_date, check_out_date, total_amount, booking_date, booking_status) 
                           VALUES (@customer_id, @room_id, @check_in_date, @check_out_date, @total_amount, @booking_date, @booking_status);";

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
                    throw new Exception($"Database error while adding user: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error while adding user: {ex.Message}", ex);
                }
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
