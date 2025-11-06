using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class FoodOrder
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }

        // Navigation property
        public Customer customer { get; set; }
    }
}
