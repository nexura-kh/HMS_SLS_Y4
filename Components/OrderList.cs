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
    public partial class OrderList : UserControl
    {
        public OrderList()
        {
            InitializeComponent();
            LoadMockupData();
        }
        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Order Date");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Nationality");
            table.Columns.Add("Items");
            table.Columns.Add("Note");
            table.Columns.Add("Status");

            table.Rows.Add("2025-11-01", "A101", "John Smith", "USA", "Coke, Steak, French Fries", "Before 3 PM", "Ordered");
            table.Rows.Add("2025-11-01", "A102", "Maria Garcia", "Spain", "Salad, Juice, Pasta", "No onion", "Delivered");
            table.Rows.Add("2025-11-02", "B201", "Michael Chen", "China", "Tea, Dumplings, Rice", "Extra sauce", "Pending");
            table.Rows.Add("2025-11-02", "C301", "Sokha Lim", "Cambodia", "Iced Coffee, Sandwich", "Less sugar", "Delivered");
            table.Rows.Add("2025-11-03", "B105", "David Brown", "UK", "Pizza, Cola", "Cheese crust", "Cancelled");
            table.Rows.Add("2025-11-03", "A103", "Emma Wilson", "Australia", "Burger, Fries, Soda", "No pickles", "Ordered");
            table.Rows.Add("2025-11-04", "C302", "Ahmed Ali", "Egypt", "Kebab, Lemon Tea", "Hot", "Delivered");
            table.Rows.Add("2025-11-05", "B203", "Sreynich T.", "Cambodia", "Fried Rice, Iced Latte", "No chili", "Ordered");
            table.Rows.Add("2025-11-05", "A104", "Olivia Davis", "Canada", "Soup, Salad, Bread", "Gluten-free", "Pending");
            table.Rows.Add("2025-11-06", "B202", "Robert Lee", "Singapore", "Curry, Rice, Water", "Spicy", "Delivered");

            orderList_data.DataSource = table;

            orderList_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderList_data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderList_data.MultiSelect = false;
            orderList_data.ReadOnly = true;
            orderList_data.AllowUserToAddRows = false;
        }
    }
}
