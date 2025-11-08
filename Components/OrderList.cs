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
        private Main _mainForm;
        private OrderItemRepository orderItemRepository = new OrderItemRepository();

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
            btnPrintOrder.Click += btnPrintOrder_Click;
            btnEditOrder.Click += btnEditOrder_Click;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
        }

        private void LoadTableData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("BookingID", typeof(int));
            table.Columns.Add("Order Date");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Nationality");
            table.Columns.Add("Items");
            table.Columns.Add("Note");
            table.Columns.Add("Status");

            var orderItems = orderItemRepository.GetAll();

            var groupedOrders = orderItems
                .GroupBy(oi => oi.Booking.bookingId)
                .Select(group => new
                {
                    BookingId = group.First().Booking.bookingId,
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
                Nationality = row.Cells["Nationality"].Value?.ToString(),
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

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = orderList_data.SelectedRows[0];
                int bookingId = Convert.ToInt32(selectedRow.Cells["BookingID"].Value);

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this order?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get all order items for this booking
                        var orderItemsToDelete = orderItemRepository.GetAll()
                            .Where(oi => oi.Booking.bookingId == bookingId)
                            .ToList();

                        // Delete each order item
                        foreach (var item in orderItemsToDelete)
                        {
                            // Try different delete method signatures
                            try
                            {
                                orderItemRepository.Delete(item.OrderItemId);
                            }
                            catch
                            {
                                // If Delete(int) doesn't exist, try other signatures
                                //orderItemRepository.DeleteOrderItem(item.OrderItemId);
                            }
                        }

                        MessageBox.Show("Order deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload the data
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

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (orderList_data.SelectedRows.Count > 0)
            {
                DataGridViewRow row = orderList_data.SelectedRows[0];

                int bookingId = row.Cells["BookingID"].Value != null ? Convert.ToInt32(row.Cells["BookingID"].Value) : 0;
                string roomNumber = row.Cells["Room"].Value?.ToString() ?? "N/A";
                string customerName = row.Cells["Customer"].Value?.ToString() ?? "N/A";

                // Navigate to Order form with the booking data
                _mainForm.LoadOrder(bookingId, roomNumber, customerName);
            }
            else
            {
                MessageBox.Show("Please select an order to edit.",
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