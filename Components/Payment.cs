using HMS_SLS_Y4.Classes;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {
        private readonly PaymentRepository paymentRepository = new PaymentRepository();
        private readonly OrderItemRepository orderItemRepository = new OrderItemRepository();
        private readonly BookingRepository bookingRepository = new BookingRepository();
        private readonly RoomRepository roomRepository = new RoomRepository();

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
            if (paymentList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment record to confirm.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = paymentList.SelectedRows[0];

            string customer = row.Cells["Customer"].Value?.ToString() ?? "Unknown";
            string status = row.Cells["Status"].Value?.ToString() ?? "";
            string paymentMethod = row.Cells["Payment Method"].Value?.ToString() ?? "Cash";
            int bookingId = Convert.ToInt32(row.Cells["Booking ID"].Value);
            int roomId = Convert.ToInt32(row.Cells["Room ID"].Value);
            decimal totalAmount = Convert.ToDecimal(row.Cells["Total"].Value);

            if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Payment for {customer} is already confirmed.", "Already Paid",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Confirm payment for {customer}?\nPayment Method: {paymentMethod}\nTotal Amount: ${totalAmount:F2}",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var existingPayment = paymentRepository.GetPaymentStatus(bookingId);

                    int paymentResult;
                    bool isAlreadyPaid = existingPayment.Status != null &&
                                         existingPayment.Status.Equals("Paid", StringComparison.OrdinalIgnoreCase);

                    if (isAlreadyPaid)
                    {
                        MessageBox.Show($"Payment for {customer} is already confirmed.", "Already Paid",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (existingPayment.Status != null)
                    {
                        paymentResult = paymentRepository.Add(new Models.Payment
                        {
                            BookingId = bookingId,
                            Amount = totalAmount,
                            PaymentStatus = "Paid",
                            PaymentMethod = paymentMethod
                        });
                    }
                    else
                    {
                        paymentResult = paymentRepository.Add(new Models.Payment
                        {
                            BookingId = bookingId,
                            Amount = totalAmount,
                            PaymentStatus = "Paid",
                            PaymentMethod = paymentMethod
                        });
                    }

                    if (paymentResult >= 1)
                    {
                        bookingRepository.UpdateBookingStatus(bookingId, 2);
                        roomRepository.updateRoomStatus(roomId, false);

                        row.Cells["Status"].Value = "Paid";
                        GenerateInvoice(row);

                        MessageBox.Show("Payment confirmed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to record payment. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            table.Columns.Add("Room ID", typeof(int));
            table.Columns.Add("Room");
            table.Columns.Add("Check-In");
            table.Columns.Add("Check-Out");
            table.Columns.Add("Customer");
            table.Columns.Add("Contact");
            table.Columns.Add("Room Price", typeof(decimal));
            table.Columns.Add("Total", typeof(decimal));
            table.Columns.Add("Status");
            table.Columns.Add("Payment Method");

            var items = orderItemRepository.GetAll();

            var grouped = items
                .Where(i => i.Booking != null && i.Booking.customer != null)
                .GroupBy(i => new
                {
                    i.Booking.bookingId,
                    i.Booking.room.roomId,
                    i.Booking.customer.User.fullName,
                    i.Booking.customer.User.nationality,
                    Room = i.Booking.room?.roomNumber,
                    RoomPrice = i.Booking.roomType?.price ?? 0,
                    Total = i.Booking?.totalAmount ?? 0,
                    CheckIn = i.Booking.checkInDate,
                    CheckOut = i.Booking.checkOutDate
                })
                .Select(g => new
                {
                    g.Key.bookingId,
                    g.Key.roomId,
                    g.Key.CheckIn,
                    g.Key.CheckOut,
                    g.Key.Room,
                    g.Key.fullName,
                    g.Key.nationality,
                    RoomPrice = g.Key.RoomPrice,
                    g.Key.Total
                })
                .ToList();

            foreach (var item in grouped)
            {
                var paymentInfo = paymentRepository.GetPaymentStatus(item.bookingId);

                string paymentMethod = paymentInfo.Method ?? "Cash";
                if (paymentMethod != "Cash" && paymentMethod != "Credit Card" && paymentMethod != "Bank Transfer")
                {
                    paymentMethod = "Cash";
                }

                table.Rows.Add(
                    item.bookingId,
                    item.roomId,
                    item.Room ?? "N/A",
                    item.CheckIn.ToString("yyyy-MM-dd"),
                    item.CheckOut.ToString("yyyy-MM-dd"),
                    item.fullName,
                    item.nationality,
                    item.RoomPrice,
                    item.Total,
                    paymentInfo.Status ?? "Pending",
                    paymentMethod 
                );
            }

            table.Columns["Payment Method"].ReadOnly = false;

            paymentList.DataSource = table;

            int paymentMethodIndex = paymentList.Columns["Payment Method"].Index;
            paymentList.Columns.RemoveAt(paymentMethodIndex);

            DataGridViewComboBoxColumn paymentMethodColumn = new DataGridViewComboBoxColumn
            {
                Name = "Payment Method",
                HeaderText = "Payment Method",
                DataPropertyName = "Payment Method",
                DataSource = new string[] { "Cash", "Credit Card", "Bank Transfer" },
                ValueType = typeof(string),
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            paymentList.Columns.Insert(paymentMethodIndex, paymentMethodColumn);

            foreach (DataGridViewRow row in paymentList.Rows)
            {
                if (row.Cells["Payment Method"].Value == null ||
                    row.Cells["Payment Method"].Value == DBNull.Value ||
                    string.IsNullOrEmpty(row.Cells["Payment Method"].Value.ToString()))
                {
                    row.Cells["Payment Method"].Value = "Cash";
                }
                else
                {
                    string currentValue = row.Cells["Payment Method"].Value.ToString();

                    if (currentValue != "Cash" && currentValue != "Credit Card" && currentValue != "Bank Transfer")
                    {
                        row.Cells["Payment Method"].Value = "Cash";
                    }
                }
            }

            foreach (DataGridViewColumn col in paymentList.Columns)
            {
                col.ReadOnly = col.Name != "Payment Method";
            }

            paymentList.Columns["Booking ID"].Visible = false;
            paymentList.Columns["Room ID"].Visible = false;
            paymentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paymentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentList.MultiSelect = false;
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
                if (item.Food == null) continue;

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

            decimal foodPrice = orderItems.Sum(oi => oi.Food?.Price * oi.Quantity ?? 0);
            decimal roomPrice = row.Cells["Room Price"].Value != null ? Convert.ToDecimal(row.Cells["Room Price"].Value) : 0;

            return new InvoiceData
            {
                CheckIn = row.Cells["Check-In"].Value?.ToString(),
                CheckOut = row.Cells["Check-Out"].Value?.ToString(),
                Room = row.Cells["Room"].Value?.ToString(),
                RoomPrice = roomPrice,
                Customer = row.Cells["Customer"].Value?.ToString(),
                Nationality = row.Cells["Contact"].Value?.ToString(),
                //FoodPrice = foodPrice,
                Total = roomPrice,
                PaymentMethod = row.Cells["Payment Method"].Value?.ToString() ?? "Cash",
                Status = row.Cells["Status"].Value?.ToString(),
                Items = itemsDict,
                InvoiceMode = "payment"
            };
        }
    }
}