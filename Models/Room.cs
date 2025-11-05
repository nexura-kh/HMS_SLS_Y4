using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class Room
    {
        public int roomId { get; set; }
        public string roomNumber { get; set; }
        public bool isAvailable { get; set; }
        public int roomTypeId { get; set; }

        public RoomType roomType { get; set; }
        public RoomType RoomType { get; internal set; }
    }
}
