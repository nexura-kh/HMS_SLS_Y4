using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Utils;
using Mysqlx.Crud;
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
        private Main _mainForm;
        private OrderItemRepository orderItemRepository = new OrderItemRepository();
        private FoodOrderRepository foodOrderRepository = new FoodOrderRepository();

        public OrderList(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadTableData();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            orderList_data.SelectionChanged += OrderList_data_SelectionChanged;
            orderList_data.CellDoubleClick += OrderList_data_CellDoubleClick; 
            btnPrintOrder.Click += btnPrintOrder_Click;
            btnConfirmPayment.Click += btnConfirmPayment_Click; 
            btnDeleteOrder.Click += btnDeleteOrder_Click;
        }

        private void LoadTableData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("BookingID", typeof(int));
            table.Columns.Add("Order ID", typeof(int));
            table.Columns.Add("Order Date");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Contact");
            table.Columns.Add("Items");
            table.Columns.Add("Note");
            table.Columns.Add("Status");

            var orderItems = orderItemRepository.GetAll();

            var groupedOrders = orderItems
                .GroupBy(oi => oi.Booking.bookingId)
                .Select(group => new
                {
                    BookingId = group.First().Booking.bookingId,
                    OrderID = group.First().FoodOrder.orderId,
                    OrderDate = group.First().FoodOrder.orderDate,
                    Room = group.First().Booking.room.roomNumber,
                    Customer = group.First().Booking.customer.User.fullName,
                    Nationality = group.First().Booking.customer.User.nationality,
                    Items = string.Join(", ", group.Select(oi => oi.Food.FoodName)),
                    Notes = string.Join("; ", group.Where(oi => !string.IsNullOrEmpty(oi.note)).Select(oi => oi.note)),
                    Status = group.First().FoodOrder.status
                });

            foreach (var order in groupedOrders)
            {
                table.Rows.Add(
                    order.BookingId,
                    order.OrderID,
                    order.OrderDate.ToString("yyyy-MM-dd"),
                    order.Room,
                    order.Customer,
                    order.Nationality,
                    order.Items,
                    order.Notes,
                    order.Status
                );
            }

            orderList_data.DataSource = table;
            orderList_data.Columns["BookingID"].Visible = false;
            orderList_data.Columns["Order ID"].Visible = false;
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
            int bookingId = Convert.ToInt32(row.Cells["BookingID"].Value);

            var orderItems = orderItemRepository.GetAll()
                .Where(oi => oi.Booking.bookingId == bookingId)
                .ToList();

            var itemsDict = new Dictionary<string, (int quantity, decimal price, string description, string note)>();

            foreach (var item in orderItems)
            {
                string foodName = item.Food.FoodName;
                decimal price = item.Food.Price;
                string description = item.Food.Description ?? "N/A";
                string note = string.IsNullOrEmpty(item.note) ? "N/A" : item.note;

                if (itemsDict.ContainsKey(foodName))
                {
                    var existing = itemsDict[foodName];
                    itemsDict[foodName] = (existing.quantity + item.Quantity, price, description, note);
                }
                else
                {
                    itemsDict[foodName] = (item.Quantity, price, description, note);
                }
            }

            decimal foodPrice = orderItems.Sum(oi => oi.Food.Price * oi.Quantity);
            var booking = orderItems.First().Booking;

            InvoiceData data = new InvoiceData
            {
                CheckIn = row.Cells["Order Date"].Value?.ToString(),
                Room = row.Cells["Room"].Value?.ToString(),
                Customer = row.Cells["Customer"].Value?.ToString(),
                Nationality = row.Cells["Contact"].Value?.ToString(),
                FoodPrice = foodPrice,
                Total = foodPrice,
                PaymentMethod = "Cash",
                Status = row.Cells["Status"].Value?.ToString(),
                Items = itemsDict,
                InvoiceMode = "order"
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

        private void OrderList_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = orderList_data.Rows[e.RowIndex];
                int bookingId = Convert.ToInt32(row.Cells["BookingID"].Value);
                string roomNumber = row.Cells["Room"].Value?.ToString() ?? "N/A";
                string customerName = row.Cells["Customer"].Value?.ToString() ?? "N/A";

                _mainForm.LoadOrder(bookingId, roomNumber, customerName);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = orderList_data.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells["Order ID"].Value);

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this order?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool updated = foodOrderRepository.Delete(orderId);

                        MessageBox.Show("Order deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadTableData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting order: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = orderList_data.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells["Order ID"].Value);

                DialogResult result = MessageBox.Show(
                    "Confirm payment for this order?",
                    "Confirm Payment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool updated = foodOrderRepository.UpdateOrderStatus(orderId,"Paid");

                        if (updated)
                        {
                            MessageBox.Show("Payment confirmed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadTableData();

                            if (orderList_data.SelectedRows.Count > 0)
                                GenerateInvoice(orderList_data.SelectedRows[0]);
                        }
                        else
                        {
                            MessageBox.Show("No orders were updated.", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error confirming payment: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to confirm payment.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = orderList_data.SelectedRows[0];
                InvoiceData invoiceData = ExtractInvoiceDataFromRow(selectedRow);

                Utilities.ShowInvoicePrintPreview(invoiceData);
            }
            else
            {
                MessageBox.Show("Please select an order to print.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void invoicePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
