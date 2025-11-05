using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public int userId { get; set; }
        public string address { get; set; }

        public User User { get; set; }
    }
}
