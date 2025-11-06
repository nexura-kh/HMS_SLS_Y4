using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models.DTOs
{
    public class BookingDTO
    {
        public int bookingId { get; set; }
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public string bookingDate { get; set; }
        public string bookingStatus { get; set; }

        public Customer customer { get; set; }
        public Room room { get; set; }
    }
}
