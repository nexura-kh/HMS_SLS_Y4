using HMS_SLS_Y4.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {
        private PaymentRepository paymentRepo = new PaymentRepository();

        public Payment()
        {
            InitializeComponent();
            LoadPayments();
            button2.Click += Button2_Click; // Confirm
            button3.Click += Button3_Click; // Cancel
        }

        private void LoadPayments()
        {
            try
            {
                DataTable dt = paymentRepo.GetPaymentsWithOrders();
                paymentList.DataSource = dt;

                // Optional: set column headers nicely
                paymentList.Columns["OrderID"].HeaderText = "Order ID";
                paymentList.Columns["CustomerName"].HeaderText = "Customer Name";
                paymentList.Columns["RoomNumber"].HeaderText = "Room Number";
                paymentList.Columns["PaymentID"].HeaderText = "Payment ID";
                paymentList.Columns["Amount"].HeaderText = "Amount";
                paymentList.Columns["PaymentDate"].HeaderText = "Payment Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load payments: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Confirm payment or generate invoice
            if (paymentList.SelectedRows.Count > 0)
            {
                var row = paymentList.SelectedRows[0];

                int paymentId = Convert.ToInt32(row.Cells["PaymentID"].Value);
                if (paymentId != 0)
                {
                    GenerateInvoice(row);
                }
                else
                {
                    MessageBox.Show("This order has no payment yet.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Cancel button action
            invoicePanel.Controls.Clear();
        }

        private void GenerateInvoice(DataGridViewRow row)
        {
            invoicePanel.Controls.Clear();

            Label lbl = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                Text = $"Invoice for Order {row.Cells["OrderID"].Value}\n" +
                       $"Customer: {row.Cells["CustomerName"].Value}\n" +
                       $"Room: {row.Cells["RoomNumber"].Value}\n" +
                       $"Amount: {row.Cells["Amount"].Value}\n" +
                       $"Payment Date: {row.Cells["PaymentDate"].Value}"
            };

            invoicePanel.Controls.Add(lbl);
        }
    }
}
