using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Utils;

namespace HMS_SLS_Y4.Components
{
    public partial class OrderList : UserControl
    {
        private OrderItemRepository orderItemRepository = new OrderItemRepository();

        public OrderList()
        {
            InitializeComponent();
            LoadTableData();
        }
        //invoicePanel
        //orderList_data
        private void SetupEventHandlers()
        {
            //orderList_data.SelectionChanged += OrderList_Data_SelectionChanged;
            //button1.Click += BtnPrint_Click;
        }
        private void LoadTableData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Order Date");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Nationality");
            table.Columns.Add("Items");
            table.Columns.Add("Note");
            table.Columns.Add("Status");

            var orderItems = orderItemRepository.GetAll();

            // Group by Order ID (or you can group by Customer if needed)
            var groupedOrders = orderItems
                .GroupBy(oi => oi.Booking.customer.User.fullName)
                .Select(group => new
                {
                    OrderId = group.Key,
                    OrderDate = group.First().FoodOrder.orderDate,
                    Room = group.First().Booking.room.roomNumber,
                    Customer = group.First().Booking.customer.User.fullName,
                    Nationality = group.First().Booking.customer.User.nationality,
                    Items = string.Join(", ", group.Select(oi => oi.Food.FoodName)), // Combine items
                    Notes = string.Join("; ", group.Where(oi => !string.IsNullOrEmpty(oi.note)).Select(oi => oi.note)), // Combine notes
                    Status = group.First().FoodOrder.status
                });

            foreach (var order in groupedOrders)
            {
                table.Rows.Add(
                    order.OrderDate.ToString("yyyy-MM-dd"),
                    order.Room,
                    order.Customer,
                    order.Nationality,
                    order.Items, // "coca, steak, ..."
                    order.Notes,
                    order.Status
                );
            }

            orderList_data.DataSource = table;
            orderList_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderList_data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderList_data.MultiSelect = false;
            orderList_data.ReadOnly = true;
            orderList_data.AllowUserToAddRows = false;
        }

        private void GenerateInvoice(DataGridViewRow row)
        {
            InvoiceData invoiceData = ExtractInvoiceDataFromRow(row);
            Utilities.GenerateInvoiceInPanel(invoicePanel, invoiceData);
        }
        private InvoiceData ExtractInvoiceDataFromRow(DataGridViewRow row)
        {
            InvoiceData data = new InvoiceData
            {
                CheckIn = row.Cells["Check-In"].Value?.ToString(),
                Room = row.Cells["Room"].Value?.ToString(),
                Customer = row.Cells["Customer"].Value?.ToString(),
                Nationality = row.Cells["Nationality"].Value?.ToString(),
                RoomPrice = Convert.ToDecimal(row.Cells["Room Price"].Value),
                FoodPrice = Convert.ToDecimal(row.Cells["Food Price"].Value),
                Total = Convert.ToDecimal(row.Cells["Total"].Value),
                PaymentMethod = row.Cells["Payment Method"].Value?.ToString(),
                Status = row.Cells["Status"].Value?.ToString(),
                Items = new Dictionary<string, int>
                {
                    { "Beef Steak", 1 },
                    { "Coke", 2 }
                }
            };
            return data;
        }
        private void OrderList_data_SelectionChanged(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = orderList_data.SelectedRows[0];
                GenerateInvoice(selectedRow);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
