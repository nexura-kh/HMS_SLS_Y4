using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Models;

namespace HMS_SLS_Y4.Classes
{
    public partial class Room : Component
    {
        private RoomRepository _roomRepository;
        private RoomTypeRepository _roomTypeRepository;

        public Room()
        {
            InitializeComponent();
            _roomRepository = new RoomRepository();
            _roomTypeRepository = new RoomTypeRepository();
        }

        public Room(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            _roomRepository = new RoomRepository();
            _roomTypeRepository = new RoomTypeRepository();
        }

        public void LoadRooms(FlowLayoutPanel panel)
        {
            try
            {
                // Get rooms from database
                List<Models.Room> rooms = _roomRepository.GetAll();

                if (rooms == null || rooms.Count == 0)
                {
                    MessageBox.Show("No rooms found in the database.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                panel.Controls.Clear();

                // Get project path for icons
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;

                foreach (Models.Room room in rooms)
                {
                    Panel roomCard = CreateRoomCard(room, projectPath);
                    panel.Controls.Add(roomCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateRoomCard(Models.Room room, string projectPath)
        {
            Panel roomCard = new Panel
            {
                Width = 103,
                Height = 115,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = room,
                Cursor = Cursors.Hand
            };

            roomCard.MouseEnter += (s, e) => roomCard.BackColor = Color.FromArgb(230, 240, 255);
            roomCard.MouseLeave += (s, e) => roomCard.BackColor = Color.White;

            string roomTypeName = room.RoomType.typeName;
            decimal capacity = room.RoomType.price;

            string iconPath = GetRoomIconPath(roomTypeName, room.isAvailable, projectPath);

            PictureBox roomIcon = new PictureBox
            {
                Width = 58,
                Height = 58,
                Location = new Point(20, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = room
            };

            // Load icon
            if (File.Exists(iconPath))
            {
                roomIcon.Image = Image.FromFile(iconPath);
            }
            else
            {
                // Create a simple placeholder if icon not found
                roomIcon.BackColor = room.isAvailable ? Color.LightGreen : Color.LightCoral;
            }

            // Room number label
            Label roomNumberLabel = new Label
            {
                Text = room.roomNumber,
                Location = new Point(5, 65),
                Width = 90,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = room
            };

            // Room type label
            Label roomTypeLabel = new Label
            {
                Text = roomTypeName.ToUpper(),
                Location = new Point(5, 85),
                Width = 90,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7),
                ForeColor = room.isAvailable ? Color.Green : Color.Red,
                Tag = room
            };

            // Status label
            Label statusLabel = new Label
            {
                Text = room.isAvailable ? "Available" : "Occupied",
                Location = new Point(5, 110),
                Width = 90,
                Height = 15,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 6),
                ForeColor = Color.Gray,
                Tag = room
            };

            // Add click events
            roomCard.Click += RoomCard_Click;
            roomIcon.Click += RoomCard_Click;
            roomNumberLabel.Click += RoomCard_Click;
            roomTypeLabel.Click += RoomCard_Click;
            statusLabel.Click += RoomCard_Click;

            // Add controls to card
            roomCard.Controls.Add(roomIcon);
            roomCard.Controls.Add(roomNumberLabel);
            roomCard.Controls.Add(roomTypeLabel);
            roomCard.Controls.Add(statusLabel);

            return roomCard;
        }

        // Get icon path based on room type and availability
        private string GetRoomIconPath(string roomType, bool isAvailable, string projectPath)
        {
            string iconFileName = "";

            if (roomType.ToLower() == "single fan" || roomType.ToLower() == "single ac")
            {
                iconFileName = isAvailable ? "single_bed_available.png" : "single_bed_unavailble.png";
            }
            else if (roomType.ToLower() == "twins fan" || roomType.ToLower() == "twins ac")
            {
                iconFileName = isAvailable ? "twin_bed_available.png" : "twin_bed_unavailable.png";
            }

            return Path.Combine(projectPath, "Resources", "icon", iconFileName);
        }
        public class RoomClickedEventArgs : EventArgs
        {
            public int RoomId { get; }
            public string RoomNumber { get; }
            public int RoomPrice { get; }

            public RoomClickedEventArgs(int roomId, string roomNumber, int roomPrice)
            {
                RoomId = roomId;
                RoomNumber = roomNumber;
                RoomPrice = roomPrice;
            }
        }

        // Event to notify when a room is clicked
        public event EventHandler<RoomClickedEventArgs> RoomClicked;

        private void RoomCard_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Models.Room room = control?.Tag as Models.Room ?? control?.Parent?.Tag as Models.Room;
            int roomPrice = (int)room.RoomType.price;

            if (room == null)
                return;

            RoomClicked?.Invoke(this, new RoomClickedEventArgs(room.roomId, room.roomNumber,roomPrice));
        }

        public List<Models.Room> GetAvailableRooms()
        {
            try
            {
                List<Models.Room> rooms = _roomRepository.GetAll();
                return rooms.Where(r => r.isAvailable).ToList();
            }
            catch
            {
                return new List<Models.Room>();
            }
        }

        // Get rooms by type
        public List<Models.Room> GetRoomsByType(string typeName)
        {
            try
            {
                List<Models.Room> rooms = _roomRepository.GetAll();
                return rooms.Where(r => r.roomType?.typeName.ToLower() == typeName.ToLower()).ToList();
            }
            catch
            {
                return new List<Models.Room>();
            }
        }

        // Get room by ID
        public Models.Room GetRoomById(int roomId)
        {
            try
            {
                return _roomRepository.GetById(roomId);
            }
            catch
            {
                return null;
            }
        }

        // Update room availability
        public bool UpdateRoomAvailability(int roomId, bool isAvailable)
        {
            try
            {
                Models.Room room = _roomRepository.GetById(roomId);
                if (room != null)
                {
                    room.isAvailable = isAvailable;
                    return _roomRepository.Update(room);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}