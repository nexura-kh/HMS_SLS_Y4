using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class Booking
    {
        public int bookingId { get; set; }
        public int customerId { get; set; }
        public int? roomId { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public decimal? totalAmount { get; set; }
        public DateTime bookingDate { get; set; }
        public int bookingStatus { get; set; }

        // Navigation properties
        public Customer customer { get; set; }
        public Room room { get; set; }
    }
}
