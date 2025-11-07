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
        private int selectedBookingId = 0;
        private bool isEditMode = false;

        public Reservation()
        {
            InitializeComponent();
            roomComponent = new Classes.Room();
            userRepository = new UserRepository();
            customerRepository = new CustomerRepository();
            bookingRepository = new BookingRepository();
            LoadBookingData();
            SetupDataGridView();
            SetFormMode(false); 
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            LoadRoom();
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView for row selection
            booked_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booked_list.MultiSelect = false;
            booked_list.ReadOnly = true;

            // Add event handler for row selection
            booked_list.CellClick += Booked_list_CellClick;
        }

        private void Booked_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = booked_list.Rows[e.RowIndex];
                    selectedBookingId = Convert.ToInt32(row.Cells["Booking ID"].Value);

                    // Load booking details
                    Booking booking = bookingRepository.GetById(selectedBookingId);

                    if (booking != null)
                    {
                        PopulateFormWithBooking(booking);
                        SetFormMode(true); // Switch to Edit mode
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PopulateFormWithBooking(Booking booking)
        {
            // Split full name into first and last name
            string[] nameParts = booking.customer?.User?.fullName?.Split(' ') ?? new string[] { "", "" };

            if (nameParts.Length >= 2)
            {
                txtLastName.Text = nameParts[0];
                txtFirstName.Text = string.Join(" ", nameParts.Skip(1));
            }
            else
            {
                txtFirstName.Text = nameParts.Length > 0 ? nameParts[0] : "";
                txtLastName.Text = "";
            }

            txtNationality.Text = booking.customer?.User?.nationality ?? "";
            txtIdCard.Text = booking.customer?.User?.idCardNumber ?? "";
            txtDob.Value = booking.customer?.User?.dob ?? DateTime.Now;

            if (booking.customer?.User?.idCardType != null)
            {
                txtIdType.SelectedValue = booking.customer.User.idCardType;
            }

            txtCheckIn.Value = booking.checkInDate;
            txtCheckOut.Value = booking.checkOutDate;
            roomNumberValue.Text = booking.room?.roomNumber ?? "";
            roomId = booking.roomId ?? 0;
            roomPrice = (int)(booking.totalAmount ?? 0);
        }

        private void SetFormMode(bool editMode)
        {
            isEditMode = editMode;

            if (editMode)
            {
                // Change Add button to Cancel button
                addOrderBtn.Text = "Cancel";
                addOrderBtn.Enabled = true;

                if (this.Controls.Find("btnEdit", true).Length > 0)
                    this.Controls.Find("btnEdit", true)[0].Enabled = true;

                if (this.Controls.Find("btnDelete", true).Length > 0)
                    this.Controls.Find("btnDelete", true)[0].Enabled = true;
            }
            else
            {
                // Change Cancel button back to Add button
                addOrderBtn.Text = "Add Reservation";
                addOrderBtn.Enabled = true;

                if (this.Controls.Find("btnEdit", true).Length > 0)
                    this.Controls.Find("btnEdit", true)[0].Enabled = false;

                if (this.Controls.Find("btnDelete", true).Length > 0)
                    this.Controls.Find("btnDelete", true)[0].Enabled = false;
            }
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

        private void LoadBookingData()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Booking ID");
                table.Columns.Add("Guest Name");
                table.Columns.Add("Nationality");
                table.Columns.Add("Room No");
                table.Columns.Add("Check-In Date");
                table.Columns.Add("Check-Out Date");
                table.Columns.Add("Status");

                List<Booking> bookings = bookingRepository.GetAll();

                foreach (var booking in bookings)
                {
                    string guestName = booking.customer?.User?.fullName ?? "N/A";
                    string nationality = booking.customer?.User?.nationality ?? "N/A";
                    string roomNumber = booking.room?.roomNumber ?? "N/A";
                    string checkInDate = booking.checkInDate.ToString("yyyy-MM-dd");
                    string checkOutDate = booking.checkOutDate.ToString("yyyy-MM-dd");
                    string status = GetBookingStatus(booking.bookingStatus);

                    table.Rows.Add(
                        booking.bookingId,
                        guestName,
                        nationality,
                        roomNumber,
                        checkInDate,
                        checkOutDate,
                        status
                    );
                }

                booked_list.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetBookingStatus(int statusCode)
        {
            switch (statusCode)
            {
                case 1:
                    return "Booked";
                case 2:
                    return "Checked-In";
                case 3:
                    return "Checked-Out";
                default:
                    return "Unknown";
            }
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            // If in edit mode, act as Cancel button
            if (isEditMode)
            {
                ClearForm();
                SetFormMode(false);
                return;
            }

            // Otherwise, act as Add button
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

                LoadBookingData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0)
            {
                MessageBox.Show("No booking selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Booking existingBooking = bookingRepository.GetById(selectedBookingId);

                if (existingBooking != null)
                {
                    var fullName = $"{txtLastName.Text} {txtFirstName.Text}".Trim();
                    existingBooking.customer.User.fullName = fullName;
                    existingBooking.customer.User.dob = txtDob.Value;
                    existingBooking.customer.User.nationality = txtNationality.Text;
                    existingBooking.customer.User.idCardNumber = txtIdCard.Text;
                    existingBooking.customer.User.idCardType = Convert.ToInt32(txtIdType.SelectedValue);

                    userRepository.Update(existingBooking.customer.User);

                    existingBooking.roomId = roomId;
                    existingBooking.checkInDate = txtCheckIn.Value;
                    existingBooking.checkOutDate = txtCheckOut.Value;
                    existingBooking.totalAmount = roomPrice;

                    bool success = bookingRepository.Update(existingBooking);

                    if (success)
                    {
                        LoadBookingData();
                        ClearForm();
                        SetFormMode(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0)
            {
                MessageBox.Show("No booking selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this reservation?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = bookingRepository.Delete(selectedBookingId);

                    if (success)
                    {
                        LoadBookingData();
                        ClearForm();
                        SetFormMode(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNationality.Clear();
            txtIdCard.Clear();
            txtDob.Value = DateTime.Now;
            txtCheckIn.Value = DateTime.Now;
            txtCheckOut.Value = DateTime.Now.AddDays(1);
            roomNumberValue.Text = "";
            roomId = 0;
            roomPrice = 0;
            selectedBookingId = 0;

            booked_list.ClearSelection();
        }
    }
}