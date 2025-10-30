using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models
{
    public class Room1
    {
        private int roomId;
        private string roomNumber;
        private bool isAvailable;
        private RoomType roomType;

        public int RoomId { get => roomId; set => roomId = value; }
        public string RoomNumber { get => roomNumber; set => roomNumber = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public RoomType RoomType { get => roomType; set => roomType = value; }
    }
}
