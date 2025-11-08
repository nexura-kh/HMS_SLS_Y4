using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HMS_SLS_Y4.Utils;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {
        public Payment()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadMockupData();
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

        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Check-In");
            table.Columns.Add("Room");
            table.Columns.Add("Customer");
            table.Columns.Add("Nationality");
            table.Columns.Add("Room Price");
            table.Columns.Add("Food Price");
            table.Columns.Add("Total");
            table.Columns.Add("Payment Method");
            table.Columns.Add("Status");

            table.Rows.Add("2025-11-01", "A101", "John Smith", "USA", 50, 20, 70, "Credit Card", "Paid");
            table.Rows.Add("2025-11-02", "B202", "Sokha Meas", "Cambodia", 40, 15, 55, "Cash", "Paid");
            table.Rows.Add("2025-11-03", "C303", "Maria Lopez", "Spain", 60, 25, 85, "Bank Transfer", "Pending");
            table.Rows.Add("2025-11-01", "A102", "David Kim", "Korea", 55, 10, 65, "Credit Card", "Paid");
            table.Rows.Add("2025-11-04", "B201", "Chan Dara", "Cambodia", 35, 12, 47, "Cash", "Pending");
            table.Rows.Add("2025-10-30", "C101", "Emma Brown", "UK", 70, 30, 100, "Credit Card", "Paid");
            table.Rows.Add("2025-11-02", "D401", "Ahmed Ali", "Malaysia", 45, 20, 65, "Cash", "Pending");
            table.Rows.Add("2025-11-01", "A103", "Sophia Nguyen", "Vietnam", 50, 18, 68, "Bank Transfer", "Paid");
            table.Rows.Add("2025-11-03", "B203", "William Chen", "China", 55, 22, 77, "Credit Card", "Paid");
            table.Rows.Add("2025-11-02", "C201", "Lisa Martin", "France", 60, 15, 75, "Cash", "Pending");

            paymentList.DataSource = table;

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
                Items = new Dictionary<string, (int, decimal, string, string)>
                {
                    { "Coke", (2, 3, "Soft drink", "Cold only") },
                    { "Steak", (1, 15, "Medium rare", "Add sauce") }
                }
            };

            return data;
        }
    }
}