using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public decimal PricePerNight { get; set; }


        public RoomType(int roomTypeId, string typeName, decimal price, string description)
        {
            RoomTypeId = roomTypeId;
            TypeName = typeName;
            Price = price;
            Description = description;
        }

        public RoomType()
        {
        }

        public RoomType( string typeName, decimal price, string description)
        {
          
            TypeName = typeName;
            Price = price;
            Description = description;
        }

    }
}
