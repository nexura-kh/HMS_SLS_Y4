using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public int? OrderItemId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation properties
        public Booking Booking { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
