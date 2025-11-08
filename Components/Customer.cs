using HMS_SLS_Y4.Repositories;
using System;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Customer : UserControl
    {
        private Main _mainForm;
        
        private BookingRepository bookingRepository = new BookingRepository();
        
        private int roomId;
        private int cusomterId;


        // Pass Main form reference in constructor
        public Customer(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            loadCustomer();
        }

        private void loadCustomer()
        {
            var table = new System.Data.DataTable();

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

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ensure clicked row is valid
            {

                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                string customerName= row.Cells["Full Name"].Value.ToString();
                string roomNumber = row.Cells["Room Number"].Value.ToString();

              
                // Call Main form to load Order control
                _mainForm.LoadOrder(customerName,roomNumber);
            }
        }
    }
}
