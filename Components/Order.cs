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
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
            LoadMockupData();
        }
        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("No.");
            table.Columns.Add("Item");
            table.Columns.Add("Quantity");
            table.Columns.Add("Description");
            table.Columns.Add("Price ($)");
            table.Columns.Add("Status");
            table.Columns.Add("Note");

            // Add mock rows
            table.Rows.Add(1, "Beef Steak", 1, "More Spicy", 10, "Ordered", "Before 3PM");
            table.Rows.Add(2, "Chicken Wings", 2, "Extra Crispy", 8, "Preparing", "Serve hot");
            table.Rows.Add(6, "Fruit Smoothie", 2, "Mixed Berries", 4.5, "Delivered", "Cold drink");

            orderedList.DataSource = table;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderTitle_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
