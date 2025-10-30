using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Reservation : UserControl
    {
        private Classes.Room roomComponent;

        public Reservation()
        {
            InitializeComponent();
            roomComponent = new Classes.Room();
            LoadMockupData();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            LoadRoom();
        }

        private void LoadRoom()
        {
            try
            {
                // Create a FlowLayoutPanel inside the available_room panel
                FlowLayoutPanel roomDisplayPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = Color.WhiteSmoke,
                    Padding = new Padding(10)
                };

                // Clear existing controls and add the FlowLayoutPanel
                available_room.Controls.Clear();
                available_room.Controls.Add(roomDisplayPanel);

                // Load rooms into the panel
                roomComponent.LoadRooms(roomDisplayPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Reservation ID");
            table.Columns.Add("Guest Name");
            table.Columns.Add("Room No");
            table.Columns.Add("Check-In Date");
            table.Columns.Add("Check-Out Date");
            table.Columns.Add("Status");

            // Add some mock rows
            table.Rows.Add("R001", "Sok Dara", "101", "2025-10-25", "2025-10-28", "Confirmed");
            table.Rows.Add("R002", "Ly Sreynich", "102", "2025-10-26", "2025-10-29", "Pending");
            table.Rows.Add("R003", "Chan Vutha", "103", "2025-10-24", "2025-10-26", "Checked-In");
            table.Rows.Add("R004", "Sokha Rith", "104", "2025-10-20", "2025-10-23", "Checked-Out");
            table.Rows.Add("R005", "Kim Lina", "105", "2025-10-30", "2025-11-02", "Cancelled");

            // Assign the table as the DataSource for your DataGridView
            booked_list.DataSource = table;
        }

        // Optional: Method to refresh room display
        public void RefreshRooms()
        {
            LoadRoom();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}