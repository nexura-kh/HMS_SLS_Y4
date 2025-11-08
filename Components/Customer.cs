using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq; 

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

        private void loadCustomer()
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            var table = new System.Data.DataTable();

            _allBookings = bookingRepository.GetAll();

            UpdateStatCards();

            LoadRecentBookings();

            table.Columns.Add("ID");
            table.Columns.Add("Full Name");
            table.Columns.Add("Nationality");
            table.Columns.Add("Checking In");
            table.Columns.Add("Checking Out");
            table.Columns.Add("Room Number");
            table.Columns.Add("Room Type");
            table.Columns.Add("Booking Status");

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
                  booking.bookingStatus == 2 ? "Checked-In" :
                  booking.bookingStatus == 2 ? "Checked-Out" : "Booked"
                );
            }

            dgvCustomers.DataSource = table;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UpdateStatCards()
        {
            if (_allBookings == null) return;

            int totalCustomers = _allBookings
                .Where(b => b.customer != null && b.customer.User != null)
                .Select(b => b.customer.User.id)
                .Distinct()
                .Count();

            int totalBooked = _allBookings
                .Count(b => b.bookingStatus == 1);

            int totalCheckedIn = _allBookings
                .Count(b => b.bookingStatus == 2);

            int totalCheckedOut = _allBookings
                .Count(b => b.bookingStatus == 3);

            lblStatValue1.Text = totalCustomers.ToString();
            lblStatValue2.Text = totalBooked.ToString();
            lblStatValue3.Text = totalCheckedIn.ToString();
            lblStatValue4.Text = totalCheckedOut.ToString();
        }

        private void LoadRecentBookings()
        {
            if (_allBookings == null) return;

            var recentBookings = _allBookings
                .OrderByDescending(b => b.checkInDate)
                .Take(3)
                .ToList();

            pnlRecentCard1.Visible = false;
            pnlRecentCard2.Visible = false;
            pnlRecentCard3.Visible = false;

            if (recentBookings.Count >= 1)
            {
                var booking1 = recentBookings[0];
                lblRecentDate1.Text = booking1.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate1.Text = booking1.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard1.Visible = true;
            }

            if (recentBookings.Count >= 2)
            {
                var booking2 = recentBookings[1];
                lblRecentTitle2.Text = booking2.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate2.Text = booking2.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard2.Visible = true;
            }

            if (recentBookings.Count >= 3)
            {
                var booking3 = recentBookings[2];
                lblRecentTitle3.Text = booking3.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate3.Text = booking3.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard3.Visible = true;
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];

                bookingId = row.Cells["ID"].Value != null ? Convert.ToInt32(row.Cells["ID"].Value) : 0;
                string roomNumber = row.Cells["Room Number"].Value?.ToString() ?? "N/A";
                string customerName = row.Cells["Full Name"].Value?.ToString() ?? "N/A";
                string bookingStatus = row.Cells["Booking Status"].Value?.ToString() ?? "";

                if (bookingStatus == "Checked-In")
                {
                    _mainForm.LoadOrder(bookingId, roomNumber, customerName);
                }
                else
                {
                    MessageBox.Show("Customer is not checked in. Cannot create order.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];

                bookingId = row.Cells["ID"].Value != null ? Convert.ToInt32(row.Cells["ID"].Value) : 0;

                _mainForm.LoadReservationWithBooking(bookingId);
            }
            else
            {
                MessageBox.Show("Please select a customer first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}