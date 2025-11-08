using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Utils
{
    public class InvoiceData
    {
        public string CheckIn { get; set; }
        public string Room { get; set; }
        public string Customer { get; set; }
        public string Nationality { get; set; }
        public decimal RoomPrice { get; set; }
        public decimal FoodPrice { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public Dictionary<string, int> Items { get; set; }

        public InvoiceData()
        {
            Items = new Dictionary<string, int>();
        }
    }

    public static class Utilities
    {
        #region Invoice Generation for Panel

        /// <summary>
        /// Generates an invoice display in a panel
        /// </summary>
        public static void GenerateInvoiceInPanel(Panel invoicePanel, InvoiceData data)
        {
            invoicePanel.Controls.Clear();
            invoicePanel.Padding = new Padding(20);

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
            yPos = AddStyledDetail(invoicePanel, "Invoice Date:", DateTime.Now.ToString("yyyy-MM-dd"), yPos);
            yPos = AddStyledDetail(invoicePanel, "Check-In Date:", data.CheckIn, yPos);
            yPos = AddStyledDetail(invoicePanel, "Check-Out Date:", DateTime.Now.ToString("yyyy-MM-dd"), yPos);
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

            yPos = AddStyledDetail(invoicePanel, "Name:", data.Customer, yPos);
            yPos = AddStyledDetail(invoicePanel, "Nationality:", data.Nationality, yPos);
            yPos = AddStyledDetail(invoicePanel, "Room:", data.Room, yPos);
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

            yPos = AddStyledDetail(invoicePanel, "Room Amount:", $"${data.RoomPrice}", yPos);
            yPos = AddStyledDetail(invoicePanel, "Food Amount:", $"${data.FoodPrice}", yPos);
            yPos += 15;

            // Items list
            var labels = CreateItemsList(data.Items, new Point(120, yPos));
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

            Label lblTotalValue = CreateLabel($"${data.Total}", new Point(170, 15),
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

            yPos = AddStyledDetail(invoicePanel, "Method:", data.PaymentMethod, yPos);

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
                BackColor = data.Status == "Paid" ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 243, 199)
            };
            invoicePanel.Controls.Add(statusBadge);

            Label lblStatusValue = CreateLabel(data.Status, new Point(15, 3),
                new Font("Segoe UI", 9, FontStyle.Bold));
            lblStatusValue.ForeColor = data.Status == "Paid" ? Color.FromArgb(22, 163, 74) : Color.FromArgb(234, 179, 8);
            statusBadge.Controls.Add(lblStatusValue);

            yPos += 40;

            // === FOOTER ===
            Label lblFooter = CreateLabel("Thank you for your stay!", new Point(130, yPos),
                new Font("Segoe UI", 9, FontStyle.Italic));
            lblFooter.ForeColor = Color.FromArgb(150, 150, 150);
            invoicePanel.Controls.Add(lblFooter);
        }

        #endregion

        #region Invoice Printing

        /// <summary>
        /// Creates a PrintDocument configured to print an invoice
        /// </summary>
        public static PrintDocument CreateInvoicePrintDocument(InvoiceData data)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) => PrintInvoicePage(e, data);
            return printDocument;
        }

        /// <summary>
        /// Shows a print preview dialog for an invoice
        /// </summary>
        public static void ShowInvoicePrintPreview(InvoiceData data)
        {
            try
            {
                PrintDocument printDocument = CreateInvoicePrintDocument(data);
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

        /// <summary>
        /// Directly prints an invoice without preview
        /// </summary>
        public static void PrintInvoiceDirectly(InvoiceData data)
        {
            try
            {
                PrintDocument printDocument = CreateInvoicePrintDocument(data);
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing invoice: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void PrintInvoicePage(PrintPageEventArgs e, InvoiceData data)
        {
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
            g.DrawString($"Check-In Date: {data.CheckIn}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === CUSTOMER INFORMATION ===
            g.DrawString("Customer Information", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Name:          {data.Customer}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Nationality:   {data.Nationality}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Room:          {data.Room}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === CHARGES ===
            g.DrawString("Charges", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Room Charge:   ${data.RoomPrice}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Food Charge:   ${data.FoodPrice}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // === ITEM LIST ===
            g.DrawString("Items:", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            foreach (var item in data.Items)
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
            g.DrawString($"${data.Total}", totalFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin + 520, yPos + 12);
            yPos += 60;

            g.DrawLine(Pens.LightGray, leftMargin, yPos, 720, yPos);
            yPos += 25;

            // === PAYMENT INFORMATION ===
            g.DrawString("Payment Information", sectionFont, new SolidBrush(Color.FromArgb(41, 55, 120)), leftMargin, yPos);
            yPos += 28;
            g.DrawString($"Payment Method: {data.PaymentMethod}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 22;

            Brush statusBrush = data.Status == "Paid" ? new SolidBrush(Color.FromArgb(22, 163, 74)) : new SolidBrush(Color.FromArgb(234, 179, 8));
            g.DrawString($"Status:         {data.Status}", normalFont, statusBrush, leftMargin, yPos);
            yPos += 70;

            // === FOOTER ===
            g.DrawString("Thank you for your stay!", smallFont, Brushes.Gray, leftMargin, yPos);
        }

        #endregion

        #region Helper Methods

        private static Label CreateLabel(string text, Point location, Font font)
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

        private static List<Label> CreateItemsList(Dictionary<string, int> items, Point startLocation)
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

        private static Panel CreateStyledDivider(int yPos, int thickness)
        {
            return new Panel
            {
                Location = new Point(100, yPos),
                Size = new Size(227, thickness),
                BackColor = Color.FromArgb(220, 220, 220)
            };
        }

        private static int AddStyledDetail(Panel panel, string label, string value, int yPos)
        {
            int leftMargin = 100;

            Label lblLabel = CreateLabel(label, new Point(leftMargin, yPos),
                new Font("Segoe UI", 9, FontStyle.Bold));
            lblLabel.ForeColor = Color.FromArgb(80, 80, 80);
            panel.Controls.Add(lblLabel);

            Label lblValue = CreateLabel(value, new Point(leftMargin + 120, yPos),
                new Font("Segoe UI", 9));
            lblValue.ForeColor = Color.FromArgb(50, 50, 50);
            panel.Controls.Add(lblValue);

            return yPos + 20;
        }

        #endregion
    }
}