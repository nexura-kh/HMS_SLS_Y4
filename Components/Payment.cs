using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HMS_SLS_Y4.Utils;
using HMS_SLS_Y4.Repositories;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {

        private readonly PaymentRepository paymentRepository = new PaymentRepository();
        private readonly OrderItemRepository orderItemRepository = new OrderItemRepository();


        public Payment()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadPaymentData();
        }

        private void SetupEventHandlers()
        {
            paymentList.SelectionChanged += PaymentList_SelectionChanged;

            button1.Click += BtnPrint_Click;

            button2.Click += BtnConfirm_Click;
            button3.Click += BtnCancel_Click;
        }

        private void PaymentList_SelectionChanged(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count > 0)
            {
                GenerateInvoice(paymentList.SelectedRows[0]);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count > 0)
            {
                InvoiceData invoiceData = ExtractInvoiceDataFromRow(paymentList.SelectedRows[0]);
                Utilities.ShowInvoicePrintPreview(invoiceData);
            }
            else
            {
                MessageBox.Show("Please select a payment record to print.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = paymentList.SelectedRows[0];
                string customer = row.Cells["Customer"].Value?.ToString();
                string status = row.Cells["Status"].Value?.ToString();

                if (status == "Paid")
                {
                    MessageBox.Show($"Payment for {customer} is already confirmed.", "Already Paid",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        $"Confirm payment for {customer}?",
                        "Confirm Payment",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        row.Cells["Status"].Value = "Paid";
                        GenerateInvoice(row);
                        MessageBox.Show("Payment confirmed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a payment record to confirm.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            paymentList.ClearSelection();
            invoicePanel.Controls.Clear();
        }

        private void LoadPaymentData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Booking ID", typeof(int));
            table.Columns.Add("Check-In");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Nationality");
            table.Columns.Add("Room Price");
            table.Columns.Add("Food Price");
            table.Columns.Add("Total");
            table.Columns.Add("Payment Method");
            table.Columns.Add("Status");

            var items = orderItemRepository.GetAll();

            var grouped = items
                .Where(i => i.Booking != null && i.Booking.customer != null)
                .GroupBy(i => new
                {
                    i.Booking.bookingId,
                    i.Booking.customer.User.fullName,
                    i.Booking.customer.User.nationality,
                    Room = i.Booking.room?.roomNumber,
                    RoomPrice = i.Booking.roomType?.price ?? 0,
                    CheckIn = i.Booking.checkInDate,
                    Status = i.FoodOrder?.status ?? "Unpaid"
                })
                .Select(g => new
                {
                    g.Key.bookingId,
                    g.Key.CheckIn,
                    g.Key.Room,
                    g.Key.fullName,
                    g.Key.nationality,
                    RoomPrice = g.Key.RoomPrice,
                    FoodPrice = g.Sum(i => i.Food?.Price ?? 0),
                    Total = g.Key.RoomPrice + g.Sum(i => i.Food?.Price ?? 0),
                    PaymentMethod = "Credit Card",
                    Status = g.Key.Status
                })
                .ToList();

            foreach (var item in grouped)
            {
                table.Rows.Add(
                    item.bookingId,
                    item.CheckIn.ToString("yyyy-MM-dd"),
                    item.Room ?? "N/A",
                    item.fullName,
                    item.nationality,
                    item.RoomPrice.ToString("F2"),
                    item.FoodPrice.ToString("F2"),
                    item.Total.ToString("F2"),
                    item.PaymentMethod,
                    item.Status
                );
            }
            paymentList.DataSource = table;
            paymentList.Columns["Booking ID"].Visible = false;
            paymentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paymentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentList.MultiSelect = false;
            paymentList.ReadOnly = true;
            paymentList.AllowUserToAddRows = false;

        }



        private void GenerateInvoice(DataGridViewRow row)
        {
            InvoiceData invoiceData = ExtractInvoiceDataFromRow(row);
            Utilities.GenerateInvoiceInPanel(invoicePanel, invoiceData);
        }

        private InvoiceData ExtractInvoiceDataFromRow(DataGridViewRow row)
        {
            int bookingId = Convert.ToInt32(row.Cells["Booking ID"].Value);

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
            decimal roomPrice = row.Cells["Room Price"].Value != null ? Convert.ToDecimal(row.Cells["Room Price"].Value) : 0;

            var booking = orderItems.First().Booking;

            InvoiceData data = new InvoiceData
            {
                CheckIn = row.Cells["Check-In"].Value?.ToString(),
                Room = row.Cells["Room"].Value?.ToString(),
                RoomPrice = roomPrice,
                Customer = row.Cells["Customer"].Value?.ToString(),
                Nationality = row.Cells["Nationality"].Value?.ToString(),
                FoodPrice = foodPrice,
                Total = foodPrice + roomPrice,
                PaymentMethod = "Cash",
                Status = row.Cells["Status"].Value?.ToString(),
                Items = itemsDict,
                InvoiceMode = "payment"
            };

            return data;
        }
    }
}