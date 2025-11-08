using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq; // Essential for OrderByDescending, Distinct, and Count

namespace HMS_SLS_Y4.Components
{
    public partial class Customer : UserControl
    {
        private Main _mainForm;        
        private int roomId;
        private int bookingId;
        private int cusomterId;
        private BookingRepository bookingRepository = new BookingRepository();
        private List<Booking> _allBookings;

        public Customer(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            loadCustomer();
        }

        private void loadCustomer() { 
            // The method that loads all data and updates all UI elements
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            var table = new System.Data.DataTable();

            // 1. Fetch data first
            // NOTE: Ensure bookingRepository.GetAll() returns List<Booking>
            _allBookings = bookingRepository.GetAll();

            // 2. Calculate and update all stat cards
            UpdateStatCards();

            // 3. Load and display the three most recent bookings
            LoadRecentBookings();

            // 4. Prepare and fill the DataGridView (DGV) DataTable

            // Add relevant columns
            table.Columns.Add("ID");
            table.Columns.Add("Full Name");
            table.Columns.Add("Nationality");
            table.Columns.Add("Checking In");
            table.Columns.Add("Checking Out");
            table.Columns.Add("Room Number");
            table.Columns.Add("Room Type");
            table.Columns.Add("Booking Status");

            table.Columns[4].MaxLength = 50;

           

            var bookings = bookingRepository.GetAll();
            foreach (var booking in bookings)
            {
                
                table.Rows.Add(
                  booking.bookingId,
                  booking.customer.User.fullName,
                  booking.customer.User.nationality,
                  booking.checkInDate.ToString("yyyy-MM-dd"),
                  booking.checkOutDate.ToString("yyyy-MM-dd"),
                  booking.room != null ? booking.room.roomNumber : "N/A",
                  booking.room != null ? booking.room.roomType.typeName : "N/A",
                  booking.bookingStatus == 1 ? "Booked" :
                  booking.bookingStatus == 2 ? "Checked-In":
                  booking.bookingStatus == 2 ? "Checked-Out" : "Booked"
                );
            }

            dgvCustomers.DataSource = table;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void UpdateStatCards()
        {
            if (_allBookings == null) return;

            // --- Calculation using LINQ ---

            // 1. Total Customers (lblStatValue1)
            int totalCustomers = _allBookings
                .Where(b => b.customer != null && b.customer.User != null)
                .Select(b => b.customer.User.id)
                .Distinct()
                .Count();

            // 2. Total Booked (lblStatValue2) - Status 1
            int totalBooked = _allBookings
                .Count(b => b.bookingStatus == 1);

            // 3. Total Checked In (lblStatValue3) - Status 2
            int totalCheckedIn = _allBookings
                .Count(b => b.bookingStatus == 2);

            // 4. Total Checked Out (lblStatValue4) - Status 3
            int totalCheckedOut = _allBookings
                .Count(b => b.bookingStatus == 3);

            // --- Update UI Labels ---
            lblStatValue1.Text = totalCustomers.ToString();
            lblStatValue2.Text = totalBooked.ToString();
            lblStatValue3.Text = totalCheckedIn.ToString();
            lblStatValue4.Text = totalCheckedOut.ToString();
        }

        private void LoadRecentBookings()
        {
            if (_allBookings == null) return;

            // 1. Sort all bookings by CheckInDate in descending order and take the top 3.
            var recentBookings = _allBookings
                .OrderByDescending(b => b.checkInDate)
                .Take(3)
                .ToList();

            // 2. Clear and hide/show panels based on data count
            pnlRecentCard1.Visible = false;
            pnlRecentCard2.Visible = false;
            pnlRecentCard3.Visible = false;

            // Recent Booking 1 (The most recent)
            if (recentBookings.Count >= 1)
            {
                var booking1 = recentBookings[0];
                lblRecentTitle1.Text = booking1.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate1.Text = booking1.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard1.Visible = true;
            }

            // Recent Booking 2
            if (recentBookings.Count >= 2)
            {
                var booking2 = recentBookings[1];
                lblRecentTitle2.Text = booking2.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate2.Text = booking2.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard2.Visible = true;
            }

            // Recent Booking 3
            if (recentBookings.Count >= 3)
            {
                var booking3 = recentBookings[2];
                lblRecentTitle3.Text = booking3.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate3.Text = booking3.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard3.Visible = true;
            }
        }

        // --- Other Events ---

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                bookingId = row.Cells["ID"].Value != null ? Convert.ToInt32(row.Cells["ID"].Value) : 0;
                string roomNumber = row.Cells["Room Number"].Value.ToString();
                string customerName = row.Cells["Full Name"].Value.ToString();

                // check if user is checked in
                if (row.Cells["Booking Status"].Value.ToString() == "Checked-In")
                {
                    // Call Main form to load Order control
                    _mainForm.LoadOrder(bookingId, roomNumber, customerName);
                }
                else
                {
                   MessageBox.Show("Customer is not checked in. Cannot create order.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lblStatTitle3_Click(object sender, EventArgs e)
        {
            // Event handler for designer file
        }
    }
}