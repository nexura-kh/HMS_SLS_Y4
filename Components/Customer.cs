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
        private int customerId;
        private BookingRepository bookingRepository = new BookingRepository();
        private List<Booking> _allBookings;

        public Customer(Main mainForm)
        {
            InitializeComponent();
            LoadCustomerData();

            _mainForm = mainForm;

            chkAll.CheckedChanged += chkAll_CheckedChanged;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            chkAll.Checked = true;
        }

        private void LoadCustomerData()
        {
            _allBookings = bookingRepository.GetAll();

            UpdateStatCards();
            DisplayData(_allBookings);
            LoadRecentBookings(_allBookings);
        }

        private void DisplayData(List<Booking> bookings)
        {
            var table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Full Name");
            table.Columns.Add("Contact");
            table.Columns.Add("Checking In");
            table.Columns.Add("Checking Out");
            table.Columns.Add("Room Number");
            table.Columns.Add("Room Type");
            table.Columns.Add("Booking Status");

            foreach (var booking in bookings)
            {
                table.Rows.Add(
                    booking.bookingId,
                    booking.customer?.User?.fullName ?? "N/A",
                    booking.customer?.User?.nationality ?? "N/A",
                    booking.checkInDate.ToString("yyyy-MM-dd"),
                    booking.checkOutDate.ToString("yyyy-MM-dd"),
                    booking.room != null ? booking.room.roomNumber : "N/A",
                    booking.room != null ? booking.room.roomType.typeName : "N/A",
                    booking.bookingStatus == 1 ? "Booked" :
                    booking.bookingStatus == 2 ? "Checked-In" :
                    booking.bookingStatus == 3 ? "Checked-Out" : "Booked"
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

            int totalBooked = _allBookings.Count(b => b.bookingStatus == 1);
            int totalCheckedIn = _allBookings.Count(b => b.bookingStatus == 2);
            int totalCheckedOut = _allBookings.Count(b => b.bookingStatus == 3);

            lblStatValue1.Text = totalCustomers.ToString();
            lblStatValue2.Text = totalBooked.ToString();
            lblStatValue3.Text = totalCheckedIn.ToString();
            lblStatValue4.Text = totalCheckedOut.ToString();
        }

        private void LoadRecentBookings(List<Booking> source)
        {
            if (source == null) return;

            var recentBookings = source
                .OrderByDescending(b => b.checkInDate)
                .Take(3)
                .ToList();

            pnlRecentCard1.Visible = false;
            pnlRecentCard2.Visible = false;
            pnlRecentCard3.Visible = false;

            if (recentBookings.Count >= 1)
            {
                var b1 = recentBookings[0];
                lblRecentTitle1.Text = b1.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate1.Text = b1.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard1.Visible = true;
            }

            if (recentBookings.Count >= 2)
            {
                var b2 = recentBookings[1];
                lblRecentTitle2.Text = b2.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate2.Text = b2.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard2.Visible = true;
            }

            if (recentBookings.Count >= 3)
            {
                var b3 = recentBookings[2];
                lblRecentTitle3.Text = b3.customer?.User?.fullName ?? "Customer N/A";
                lblRecentDate3.Text = b3.checkInDate.ToString("dd-MMM-yyyy");
                pnlRecentCard3.Visible = true;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                DisplayData(_allBookings);
                LoadRecentBookings(_allBookings);
                dtpDate.Enabled = false;
            }
            else
            {
                dtpDate.Enabled = true;
                FilterByDate();
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (!chkAll.Checked)
                FilterByDate();
        }

        private void FilterByDate()
        {
            if (_allBookings == null) return;

            DateTime selected = dtpDate.Value.Date;

            var filtered = _allBookings
                .Where(b => b.checkInDate.Date == selected)
                .ToList();

            DisplayData(filtered);
            LoadRecentBookings(filtered);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                bookingId = Convert.ToInt32(row.Cells["ID"].Value);
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
                bookingId = Convert.ToInt32(row.Cells["ID"].Value);
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
