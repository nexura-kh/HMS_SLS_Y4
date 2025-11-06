using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class RoomType
    {
        public int roomTypeId { get; set; }
        public string typeName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public RoomType() { }
        public RoomType(int roomTypeId, decimal price, string description)
        {
            this.roomTypeId = roomTypeId;
            this.price = price;
            this.description = description;
        }
        public RoomType(int roomTypeId, string typeName, decimal price, string description)
        {
            this.roomTypeId = roomTypeId;   
            this.typeName = typeName;
            this.price = price;
            this.description = description;
        }
    }
}