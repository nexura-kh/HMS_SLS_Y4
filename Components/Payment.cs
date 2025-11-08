using HMS_SLS_Y4.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {
        private readonly PaymentRepository _paymentRepo = new PaymentRepository();
        private DataTable _dt;
        private PrintDocument _printDoc;

        public Payment()
        {
            InitializeComponent();

            // Setup events
            SetupEventHandlers();

            // Prepare print document
            _printDoc = new PrintDocument();
            _printDoc.PrintPage += PrintDoc_PrintPage;

            // Load data from DB
            LoadOrdersForPayment();
        }

        private void SetupEventHandlers()
        {
            paymentList.SelectionChanged += PaymentList_SelectionChanged;
            button1.Click += BtnPrint_Click;     // print icon button in designer
            button2.Click += BtnConfirm_Click;   // Confirm
            button3.Click += BtnCancel_Click;    // Cancel/clear
        }

        private void LoadOrdersForPayment()
        {
            try
            {
                _dt = _paymentRepo.GetOrdersForPayment();
                paymentList.DataSource = _dt;

                // Nice header names (if columns exist)
                if (paymentList.Columns["OrderItemID"] != null) paymentList.Columns["OrderItemID"].HeaderText = "Order Item";
                if (paymentList.Columns["OrderID"] != null) paymentList.Columns["OrderID"].HeaderText = "Order ID";
                if (paymentList.Columns["BookingID"] != null) paymentList.Columns["BookingID"].HeaderText = "Booking ID";
                if (paymentList.Columns["CustomerName"] != null) paymentList.Columns["CustomerName"].HeaderText = "Customer";
                if (paymentList.Columns["RoomNumber"] != null) paymentList.Columns["RoomNumber"].HeaderText = "Room";
                if (paymentList.Columns["FoodName"] != null) paymentList.Columns["FoodName"].HeaderText = "Item";
                if (paymentList.Columns["Quantity"] != null) paymentList.Columns["Quantity"].HeaderText = "Qty";
                if (paymentList.Columns["ItemTotal"] != null) paymentList.Columns["ItemTotal"].HeaderText = "Amount";
                if (paymentList.Columns["PaymentID"] != null) paymentList.Columns["PaymentID"].HeaderText = "Payment ID";
                if (paymentList.Columns["PaymentDate"] != null) paymentList.Columns["PaymentDate"].HeaderText = "Paid On";

                // appearance
                paymentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                paymentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                paymentList.MultiSelect = false;
                paymentList.ReadOnly = true;
                paymentList.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PaymentList_SelectionChanged(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count > 0)
            {
                GenerateInvoice(paymentList.SelectedRows[0]);
            }
            else
            {
                invoicePanel.Controls.Clear();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to print.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = _printDoc,
                    Width = 900,
                    Height = 700,
                    StartPosition = FormStartPosition.CenterScreen
                };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed: " + ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (paymentList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order item to confirm payment.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = paymentList.SelectedRows[0];
            int orderItemId = row.Cells["OrderItemID"] != null && row.Cells["OrderItemID"].Value != DBNull.Value
                ? Convert.ToInt32(row.Cells["OrderItemID"].Value)
                : 0;
            int bookingId = row.Cells["BookingID"] != null && row.Cells["BookingID"].Value != DBNull.Value
                ? Convert.ToInt32(row.Cells["BookingID"].Value)
                : 0;
            decimal amount = row.Cells["ItemTotal"] != null && row.Cells["ItemTotal"].Value != DBNull.Value
                ? Convert.ToDecimal(row.Cells["ItemTotal"].Value)
                : 0m;
            object paymentIdObj = row.Cells["PaymentID"]?.Value;

            bool alreadyPaid = paymentIdObj != null && paymentIdObj != DBNull.Value && Convert.ToInt32(paymentIdObj) > 0;

            if (alreadyPaid)
            {
                MessageBox.Show("This item is already paid.", "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Confirm payment of {amount:C} for item #{orderItemId}?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                int newPaymentId = _paymentRepo.InsertPayment(bookingId, orderItemId, amount);

                // Refresh data
                LoadOrdersForPayment();

                // find the row with the new payment and select it
                foreach (DataGridViewRow r in paymentList.Rows)
                {
                    if (r.Cells["OrderItemID"]?.Value != DBNull.Value && Convert.ToInt32(r.Cells["OrderItemID"].Value) == orderItemId)
                    {
                        paymentList.ClearSelection();
                        r.Selected = true;
                        paymentList.FirstDisplayedScrollingRowIndex = r.Index;
                        break;
                    }
                }

                MessageBox.Show("Payment recorded (ID: " + newPaymentId + ")", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            paymentList.ClearSelection();
            invoicePanel.Controls.Clear();
        }

        /// <summary>
        /// Draw invoice preview inside the right-side panel
        /// </summary>
        private void GenerateInvoice(DataGridViewRow row)
        {
            invoicePanel.Controls.Clear();
            invoicePanel.Padding = new Padding(20);

            // Read values safely
            string customer = SafeGetString(row, "CustomerName");
            string room = SafeGetString(row, "RoomNumber");
            string item = SafeGetString(row, "FoodName");
            string qty = SafeGetString(row, "Quantity");
            string amount = SafeGetString(row, "ItemTotal");
            string paymentDate = SafeGetString(row, "PaymentDate");
            string paymentId = SafeGetString(row, "PaymentID");
            string orderDate = SafeGetString(row, "OrderDate");

            int y = 10;

            var title = new Label { Text = "INVOICE", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, y), AutoSize = true };
            invoicePanel.Controls.Add(title);
            y += 40;

            invoicePanel.Controls.Add(new Label { Text = $"Customer: {customer}", Location = new Point(20, y), AutoSize = true });
            y += 22;
            invoicePanel.Controls.Add(new Label { Text = $"Room: {room}", Location = new Point(20, y), AutoSize = true });
            y += 22;
            invoicePanel.Controls.Add(new Label { Text = $"Order Date: {orderDate}", Location = new Point(20, y), AutoSize = true });
            y += 22;
            invoicePanel.Controls.Add(new Label { Text = $"Item: {item} (x{qty})", Location = new Point(20, y), AutoSize = true });
            y += 22;
            invoicePanel.Controls.Add(new Label { Text = $"Amount: {amount}", Location = new Point(20, y), AutoSize = true });
            y += 30;

            invoicePanel.Controls.Add(new Label { Text = $"Payment ID: {paymentId}", Location = new Point(20, y), AutoSize = true });
            y += 22;
            invoicePanel.Controls.Add(new Label { Text = $"Paid On: {paymentDate}", Location = new Point(20, y), AutoSize = true });
        }

        private string SafeGetString(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != DBNull.Value)
                return row.Cells[columnName].Value.ToString();
            return string.Empty;
        }

        /// <summary>
        /// PrintDocument page drawing (simple invoice)
        /// </summary>
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (paymentList.SelectedRows.Count == 0) return;

            var row = paymentList.SelectedRows[0];

            string hotelName = "SLS HOTEL";
            string customer = SafeGetString(row, "CustomerName");
            string room = SafeGetString(row, "RoomNumber");
            string item = SafeGetString(row, "FoodName");
            string qty = SafeGetString(row, "Quantity");
            string amount = SafeGetString(row, "ItemTotal");
            string paymentId = SafeGetString(row, "PaymentID");
            string paymentDate = SafeGetString(row, "PaymentDate");
            string orderDate = SafeGetString(row, "OrderDate");

            Graphics g = e.Graphics;
            int x = 50;
            int y = 60;

            g.DrawString(hotelName, new Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, x, y);
            y += 40;
            g.DrawString($"Invoice for: {customer}", new Font("Segoe UI", 11), Brushes.Black, x, y);
            y += 22;
            g.DrawString($"Room: {room}", new Font("Segoe UI", 11), Brushes.Black, x, y);
            y += 22;
            g.DrawString($"Order date: {orderDate}", new Font("Segoe UI", 11), Brushes.Black, x, y);
            y += 22;
            g.DrawString($"Item: {item} (x{qty})", new Font("Segoe UI", 11), Brushes.Black, x, y);
            y += 22;
            g.DrawString($"Amount: {amount}", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, x, y);
            y += 30;
            g.DrawString($"Payment ID: {paymentId}", new Font("Segoe UI", 10), Brushes.Black, x, y);
            y += 18;
            g.DrawString($"Paid on: {paymentDate}", new Font("Segoe UI", 10), Brushes.Black, x, y);
        }
    }
}
