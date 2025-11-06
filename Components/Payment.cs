using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Payment : UserControl
    {
        private PrintDocument printDocument;

        public Payment()
        {
            InitializeComponent();
            SetupPrintDocument();
            SetupEventHandlers();
            LoadMockupData();
        }

        private void SetupPrintDocument()
        {
            // Initialize PrintDocument for printing invoices
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void SetupEventHandlers()
        {
            // Connect the DataGridView selection event to generate invoice
            paymentList.SelectionChanged += PaymentList_SelectionChanged;

            // Connect print button (button1)
            button1.Click += BtnPrint_Click;

            // Optional: Connect Confirm and Cancel buttons
            button2.Click += BtnConfirm_Click;
            button3.Click += BtnCancel_Click;
        }

        private void PaymentList_SelectionChanged(object sender, EventArgs e)
        {
            // Generate invoice when a row is selected
            if (paymentList.SelectedRows.Count > 0)
            {
                GenerateInvoice(paymentList.SelectedRows[0]);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            // Print the invoice
            if (paymentList.SelectedRows.Count > 0)
            {
                try
                {
                    PrintPreviewDialog printPreview = new PrintPreviewDialog
                    {
                        Document = printDocument,
                        Width = 900,
                        Height = 700,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    printPreview.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error printing invoice: {ex.Message}", "Print Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a payment record to print.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Handle confirm action
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
                        GenerateInvoice(row); // Refresh invoice
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
            // Clear selection and invoice
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

            // Optional: Improve DataGridView appearance
            paymentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paymentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentList.MultiSelect = false;
            paymentList.ReadOnly = true;
            paymentList.AllowUserToAddRows = false;
        }

        private void GenerateInvoice(DataGridViewRow row)
        {
            invoicePanel.Controls.Clear();
            invoicePanel.Padding = new Padding(20);

            // Extract data from selected row
            string checkIn = row.Cells["Check-In"].Value?.ToString();
            string room = row.Cells["Room"].Value?.ToString();
            string customer = row.Cells["Customer"].Value?.ToString();
            string nationality = row.Cells["Nationality"].Value?.ToString();
            string roomPrice = row.Cells["Room Price"].Value?.ToString();
            string foodPrice = row.Cells["Food Price"].Value?.ToString();
            string total = row.Cells["Total"].Value?.ToString();
            string paymentMethod = row.Cells["Payment Method"].Value?.ToString();
            string status = row.Cells["Status"].Value?.ToString();

            int yPos = 15;
            int leftMargin = 150;

            // === HOTEL HEADER SECTION ===
            Label lblHeader = CreateLabel("SLS HOTEL", new Point(leftMargin, yPos),
                new Font("Segoe UI", 15, FontStyle.Bold));
            lblHeader.ForeColor = Color.FromArgb(41, 55, 120);
            invoicePanel.Controls.Add(lblHeader);
            yPos += 35;

            Label lblSubHeader = CreateLabel("Hotel Management System", new Point(125, yPos),
                new Font("Segoe UI", 9));
            lblSubHeader.ForeColor = Color.FromArgb(100, 100, 100);
            invoicePanel.Controls.Add(lblSubHeader);
            yPos += 20;

            // Stylish divider
            Panel divider1 = CreateStyledDivider(yPos, 3);
            invoicePanel.Controls.Add(divider1);
            yPos += 10;

            // === INVOICE TITLE ===
            Label lblInvoice = CreateLabel("INVOICE", new Point(leftMargin, yPos),
                new Font("Segoe UI", 18, FontStyle.Bold));
            lblInvoice.ForeColor = Color.FromArgb(41, 55, 120);
            invoicePanel.Controls.Add(lblInvoice);
            yPos += 45;

            // === DATE SECTION ===
            yPos = AddStyledDetail("Invoice Date:", DateTime.Now.ToString("yyyy-MM-dd"), yPos);
            yPos = AddStyledDetail("Check-In Date:", checkIn, yPos);
            yPos = AddStyledDetail("Check-Out Date:", DateTime.Now.ToString("yyyy-MM-dd"), yPos);
            yPos += 20;

            // Light divider
            Panel divider2 = CreateStyledDivider(yPos, 1);
            invoicePanel.Controls.Add(divider2);
            yPos += 18;

            // === CUSTOMER INFORMATION SECTION ===
            Label lblCustomerInfo = CreateLabel("Customer Information", new Point(100, yPos),
                new Font("Segoe UI", 11, FontStyle.Bold));
            lblCustomerInfo.ForeColor = Color.FromArgb(41, 55, 120);
            invoicePanel.Controls.Add(lblCustomerInfo);
            yPos += 35;

            yPos = AddStyledDetail("Name:", customer, yPos);
            yPos = AddStyledDetail("Nationality:", nationality, yPos);
            yPos = AddStyledDetail("Room:", room, yPos);
            yPos += 15;

            // Light divider
            Panel divider3 = CreateStyledDivider(yPos, 1);
            invoicePanel.Controls.Add(divider3);
            yPos += 18;

            // === AMOUNT SECTION ===
            Label lblCharges = CreateLabel("Amount", new Point(160, yPos),
                new Font("Segoe UI", 11, FontStyle.Bold));
            lblCharges.ForeColor = Color.FromArgb(41, 55, 120);
            invoicePanel.Controls.Add(lblCharges);
            yPos += 35;

            yPos = AddStyledDetail("Room Amount:", $"${roomPrice}", yPos);
            yPos = AddStyledDetail("Food Amount:", $"${foodPrice}", yPos);
            yPos += 15;

            var labels = CreateItemsList(
                new Dictionary<string, int>
                {
                    { "Beef Steak", 1 },
                    { "Coke", 2 }
                },
                new Point(120, yPos)
            );

            foreach (var lbl in labels)
            {
                invoicePanel.Controls.Add(lbl);
            }

            yPos += labels.Count * 25 + 10;

            // Thick divider before total
            Panel divider4 = CreateStyledDivider(yPos, 1);
            invoicePanel.Controls.Add(divider4);
            yPos += 20;

            // === TOTAL SECTION (HIGHLIGHTED) ===
            Panel totalPanel = new Panel
            {
                Location = new Point(100, yPos),
                Size = new Size(227, 50),
                BackColor = Color.FromArgb(240, 244, 255),
                BorderStyle = BorderStyle.None
            };
            invoicePanel.Controls.Add(totalPanel);

            Label lblTotalText = CreateLabel("TOTAL AMOUNT", new Point(10, 15),
                new Font("Segoe UI", 12, FontStyle.Bold));
            lblTotalText.ForeColor = Color.FromArgb(41, 55, 120);
            totalPanel.Controls.Add(lblTotalText);

            Label lblTotalValue = CreateLabel($"${total}", new Point(170, 15),
                new Font("Segoe UI", 12, FontStyle.Bold));
            lblTotalValue.ForeColor = Color.FromArgb(41, 55, 120);
            totalPanel.Controls.Add(lblTotalValue);
            yPos += 65;

            // Light divider
            Panel divider5 = CreateStyledDivider(yPos, 1);
            invoicePanel.Controls.Add(divider5);
            yPos += 18;

            // === PAYMENT INFORMATION SECTION ===
            Label lblPaymentInfo = CreateLabel("Payment Information", new Point(100, yPos),
                new Font("Segoe UI", 11, FontStyle.Bold));
            lblPaymentInfo.ForeColor = Color.FromArgb(41, 55, 120);
            invoicePanel.Controls.Add(lblPaymentInfo);
            yPos += 35;

            yPos = AddStyledDetail("Method:", paymentMethod, yPos);

            // Status with styled badge
            Label lblStatusLabel = CreateLabel("Status:", new Point(100, yPos),
                new Font("Segoe UI", 9, FontStyle.Bold));
            lblStatusLabel.ForeColor = Color.FromArgb(80, 80, 80);
            invoicePanel.Controls.Add(lblStatusLabel);

            // Create status badge
            Panel statusBadge = new Panel
            {
                Location = new Point(leftMargin + 60, yPos - 2),
                Size = new Size(70, 22),
                BackColor = status == "Paid" ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 243, 199)
            };
            invoicePanel.Controls.Add(statusBadge);

            Label lblStatusValue = CreateLabel(status, new Point(15, 3),
                new Font("Segoe UI", 9, FontStyle.Bold));
            lblStatusValue.ForeColor = status == "Paid" ? Color.FromArgb(22, 163, 74) : Color.FromArgb(234, 179, 8);
            statusBadge.Controls.Add(lblStatusValue);

            yPos += 40;

            // === FOOTER ===
            Label lblFooter = CreateLabel("Thank you for your stay!", new Point(130, yPos),
                new Font("Segoe UI", 9, FontStyle.Italic));
            lblFooter.ForeColor = Color.FromArgb(150, 150, 150);
            invoicePanel.Controls.Add(lblFooter);
        }

        private Label CreateLabel(string text, Point location, Font font)
        {
            return new Label
            {
                Text = text,
                Location = location,
                Font = font,
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private List<Label> CreateItemsList(Dictionary<string, int> items, Point startLocation)
        {
            List<Label> labels = new List<Label>();
            Font font = new Font("Segoe UI", 9, FontStyle.Italic);
            int offsetY = 0;

            foreach (var pair in items)
            {
                Label label = new Label
                {
                    Text = $"- {pair.Key} : {pair.Value}",
                    Location = new Point(startLocation.X, startLocation.Y + offsetY),
                    Font = font,
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                labels.Add(label);
                offsetY += 25; 
            }

            return labels;
        }

        private Panel CreateStyledDivider(int yPos, int thickness)
        {
            return new Panel
            {
                Location = new Point(100, yPos),
                Size = new Size(227, thickness),
                BackColor = Color.FromArgb(220, 220, 220)
            };
        }

        private int AddStyledDetail(string label, string value, int yPos)
        {
            int leftMargin = 100;

            Label lblLabel = CreateLabel(label, new Point(leftMargin, yPos),
                new Font("Segoe UI", 9, FontStyle.Bold));
            lblLabel.ForeColor = Color.FromArgb(80, 80, 80);
            invoicePanel.Controls.Add(lblLabel);

            Label lblValue = CreateLabel(value, new Point(leftMargin + 120, yPos),
                new Font("Segoe UI", 9));
            lblValue.ForeColor = Color.FromArgb(50, 50, 50);
            invoicePanel.Controls.Add(lblValue);

            return yPos + 20;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (paymentList.SelectedRows.Count == 0) return;

            DataGridViewRow row = paymentList.SelectedRows[0];
            Graphics g = e.Graphics;

            // Define fonts
            Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font subtitleFont = new Font("Segoe UI", 10);
            Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font sectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            Font smallFont = new Font("Segoe UI", 9, FontStyle.Italic);
            Font itemFont = new Font("Segoe UI", 9, FontStyle.Italic);

            int yPos = 80;
            int leftMargin = 80;

            // === HEADER ===
            g.DrawString("G1_HMS", titleFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 38;
            g.DrawString("Hotel Management System", subtitleFont, Brushes.Gray, leftMargin, yPos);
            yPos += 35;

            g.DrawLine(new Pen(Color.FromArgb(41, 55, 120), 3), leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === INVOICE TITLE ===
            g.DrawString("INVOICE", headerFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 35;

            // Dates
            g.DrawString($"Invoice Date:  {DateTime.Now:yyyy-MM-dd}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Check-In Date: {row.Cells["Check-In"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === CUSTOMER INFORMATION ===
            g.DrawString("Customer Information", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Name:          {row.Cells["Customer"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Nationality:   {row.Cells["Nationality"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Room:          {row.Cells["Room"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === CHARGES ===
            g.DrawString("Charges", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Room Charge:   ${row.Cells["Room Price"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Food Charge:   ${row.Cells["Food Price"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // === ITEM LIST ===
            Dictionary<string, int> items = new Dictionary<string, int>
    {
        { "Beef Steak", 1 },
        { "Coke", 2 }
    };

            g.DrawString("Items:", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            foreach (var item in items)
            {
                g.DrawString($"- {item.Key} : {item.Value}", itemFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += 18;
            }

            yPos += 10;
            g.DrawLine(new Pen(Color.Gray, 2), leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === TOTAL (HIGHLIGHTED) ===
            Rectangle totalRect = new Rectangle(leftMargin, yPos, 640, 45);
            g.FillRectangle(new SolidBrush(Color.FromArgb(240, 244, 255)), totalRect);

            Font totalFont = new Font("Segoe UI", 14, FontStyle.Bold);
            g.DrawString("TOTAL AMOUNT:", totalFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin + 15, yPos + 12);
            g.DrawString($"${row.Cells["Total"].Value}", totalFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin + 520, yPos + 12);
            yPos += 60;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === PAYMENT INFORMATION ===
            g.DrawString("Payment Information", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Payment Method: {row.Cells["Payment Method"].Value}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;

            string status = row.Cells["Status"].Value?.ToString();
            Brush statusBrush = status == "Paid" ? new SolidBrush(Color.FromArgb(22, 163, 74)) : new SolidBrush(Color.FromArgb(234, 179, 8));
            g.DrawString($"Status:         {status}", normalFont, statusBrush, leftMargin, yPos);
            yPos += 70;

            // === FOOTER ===
            g.DrawString("Thank you for your stay!", smallFont, Brushes.Gray, leftMargin, yPos);
        }

    }
}