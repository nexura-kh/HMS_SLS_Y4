using HMS_SLS_Y4.Classes;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HMS_SLS_Y4.Classes.Room;

namespace HMS_SLS_Y4.Components
{
    public partial class Reservation : UserControl
    {
        private Classes.Room roomComponent;
        public Repositories.RoomRepository roomRepository;
        public Repositories.UserRepository userRepository;
        public Repositories.CustomerRepository customerRepository;
        public Repositories.BookingRepository bookingRepository;

        public Reservation()
        {
            InitializeComponent();
            roomComponent = new Classes.Room();
            userRepository = new UserRepository();
            customerRepository = new CustomerRepository();
            bookingRepository = new BookingRepository();
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
                FlowLayoutPanel roomDisplayPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = Color.WhiteSmoke,
                    Padding = new Padding(10)
                };

                available_room.Controls.Clear();
                available_room.Controls.Add(roomDisplayPanel);

                roomComponent.RoomClicked += RoomComponent_RoomClicked;
                roomComponent.LoadRooms(roomDisplayPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int roomPrice = 0;
        int roomId = 0;
        private void RoomComponent_RoomClicked(object sender, RoomClickedEventArgs e)
        {
            roomNumberValue.Text = e.RoomNumber;
            roomPrice = e.RoomPrice;
            roomId = e.RoomId;
        }

        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Reservation ID");
            table.Columns.Add("Guest Name");
            table.Columns.Add("Nationality");
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

            booked_list.DataSource = table;
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            if (roomId == 0)
            {
                MessageBox.Show("Please select a room before making a reservation.", "No Room Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtNationality.Text) ||
                string.IsNullOrWhiteSpace(txtIdCard.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var fullName = $"{txtLastName.Text} {txtFirstName.Text}".Trim();

                User user = new User
                {
                    fullName = fullName,
                    dob = txtDob.Value,
                    nationality = txtNationality.Text,
                    idCardNumber = txtIdCard.Text,
                    idCardType = Convert.ToInt32(txtIdType.SelectedValue)
                };

                int userId = userRepository.Add(user);

                HMS_SLS_Y4.Models.Customer customer = new Models.Customer
                {
                    userId = userId,
                    address = "Unknown"
                };

                int customerId = customerRepository.Add(customer);

                int bookingId = bookingRepository.Add(new Booking
                {
                    customerId = customerId,
                    roomId = roomId,
                    checkInDate = txtCheckIn.Value,
                    checkOutDate = txtCheckOut.Value,
                    totalAmount = roomPrice,
                    bookingDate = DateTime.Now,
                    bookingStatus = 1
                });

                MessageBox.Show("Reservation successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}