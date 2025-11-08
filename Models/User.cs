using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class User
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime? dob { get; set; }
        public string nationality { get; set; }
        public string idCardNumber { get; set; }
        public DateTime createdAt { get; set; }
    }
}
