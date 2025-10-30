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
using Newtonsoft.Json;

namespace HMS_SLS_Y4.Classes
{
    public partial class Room : Component
    {
        public class RoomData
        {
            public string room_number { get; set; }
            public string type { get; set; }
            public int capacity { get; set; }
            public bool availability { get; set; }
        }

        public Room()
        {
            InitializeComponent();
        }

        public Room(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        // Method to load rooms and display in a FlowLayoutPanel
        public void LoadRooms(FlowLayoutPanel panel)
        {
            try
            {
                // Get the path to room.json
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
                string jsonPath = Path.Combine(projectPath, "Resources", "data", "room.json");

                // Check if file exists
                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show($"Room data file not found at: {jsonPath}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Read and deserialize JSON
                string jsonData = File.ReadAllText(jsonPath);
                List<RoomData> rooms = JsonConvert.DeserializeObject<List<RoomData>>(jsonData);

                // Clear existing controls
                panel.Controls.Clear();

                // Loop through each room
                foreach (RoomData room in rooms)
                {
                    // Create room card panel
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

        // Create a room card UI element
        private Panel CreateRoomCard(RoomData room, string projectPath)
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

            // Add hover effect
            roomCard.MouseEnter += (s, e) => roomCard.BackColor = Color.FromArgb(230, 240, 255);
            roomCard.MouseLeave += (s, e) => roomCard.BackColor = Color.White;

            // Get icon path
            string iconPath = GetRoomIconPath(room.type, room.availability, projectPath);

            // Create PictureBox for icon
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
                roomIcon.BackColor = room.availability ? Color.LightGreen : Color.LightCoral;
            }

            // Room number label
            Label roomNumberLabel = new Label
            {
                Text = room.room_number,
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
                Text = room.type.ToUpper(),
                Location = new Point(5, 85),
                Width = 90,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7),
                ForeColor = room.availability ? Color.Green : Color.Red,
                Tag = room
            };

            // Status label
            Label statusLabel = new Label
            {
                Text = room.availability ? "Available" : "Occupied",
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

            if (roomType.ToLower() == "single")
            {
                iconFileName = isAvailable ? "single_bed_available.png" : "single_bed_unavailble.png";
            }
            else if (roomType.ToLower() == "twin")
            {
                iconFileName = isAvailable ? "twin_bed_available.png" : "twin_bed_unavailable.png";
            }

            return Path.Combine(projectPath, "Resources", "icon", iconFileName);
        }

        // Click event handler
        private void RoomCard_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            RoomData room = control?.Tag as RoomData ?? (control?.Parent?.Tag as RoomData);

            if (room != null)
            {
                string status = room.availability ? "Available" : "Unavailable";
                string message = $"Room Number: {room.room_number}\n" +
                               $"Type: {room.type}\n" +
                               $"Capacity: {room.capacity}\n" +
                               $"Status: {status}";

                MessageBox.Show(message, "Room Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Get all available rooms
        public List<RoomData> GetAvailableRooms()
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
                string jsonPath = Path.Combine(projectPath, "Resources", "data", "room.json");

                string jsonData = File.ReadAllText(jsonPath);
                List<RoomData> rooms = JsonConvert.DeserializeObject<List<RoomData>>(jsonData);

                return rooms.Where(r => r.availability).ToList();
            }
            catch
            {
                return new List<RoomData>();
            }
        }

        // Get rooms by type
        public List<RoomData> GetRoomsByType(string type)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
                string jsonPath = Path.Combine(projectPath, "Resources", "data", "room.json");

                string jsonData = File.ReadAllText(jsonPath);
                List<RoomData> rooms = JsonConvert.DeserializeObject<List<RoomData>>(jsonData);

                return rooms.Where(r => r.type.ToLower() == type.ToLower()).ToList();
            }
            catch
            {
                return new List<RoomData>();
            }
        }
    }
}