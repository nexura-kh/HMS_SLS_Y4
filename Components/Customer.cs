using System;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Customer : UserControl
    {
        private Main _mainForm;

        // Pass Main form reference in constructor
        public Customer(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadMockupData();
        }

        private void LoadMockupData()
        {
            var table = new System.Data.DataTable();

            // Add relevant columns
            table.Columns.Add("ID");
            table.Columns.Add("Full Name");
            table.Columns.Add("Phone");
            table.Columns.Add("Last Booking Date");
            table.Columns.Add("Room Number");
            table.Columns.Add("Room Type");
            table.Columns.Add("Booking Status");

            // Add mockup rows
            table.Rows.Add(1, "Em Pisey", "0123456789", "2025-10-25", "101", "Single", "Checked In");
            table.Rows.Add(2, "Saroth Tola", "0987654321", "2025-11-01", "202", "Double", "Reserved");
            table.Rows.Add(3, "Chenda Sok", "0123987654", "2025-09-30", "303", "Suite", "Checked Out");
            table.Rows.Add(4, "Rithy Meng", "0176543210", "2025-11-03", "404", "Double", "Reserved");
            table.Rows.Add(5, "Sophea Kim", "0156781234", "2025-10-28", "505", "Single", "Checked In");

            dgvCustomers.DataSource = table;
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ensure clicked row is valid
            {
                // Call Main form to load Order control
                _mainForm.LoadOrder();
            }
        }
    }
}
