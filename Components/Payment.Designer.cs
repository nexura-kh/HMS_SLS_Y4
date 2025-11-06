namespace HMS_SLS_Y4.Components
{
    partial class Payment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            paymentList = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            button1 = new Button();
            label1 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            invoicePanel = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)paymentList).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1100, 704);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(paymentList, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(30, 0, 15, 30);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.Size = new Size(764, 698);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(33, 0);
            label2.Name = "label2";
            label2.Size = new Size(286, 66);
            label2.TabIndex = 2;
            label2.Text = "Customer Payment List";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // paymentList
            // 
            paymentList.BackgroundColor = SystemColors.Control;
            paymentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            paymentList.Dock = DockStyle.Fill;
            paymentList.Location = new Point(33, 69);
            paymentList.Name = "paymentList";
            paymentList.RowHeadersWidth = 51;
            paymentList.Size = new Size(713, 596);
            paymentList.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(773, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(0, 0, 0, 30);
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel3.Size = new Size(324, 698);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(button1, 1, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.Padding = new Padding(15, 0, 30, 0);
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(318, 60);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(209, 3);
            button1.Name = "button1";
            button1.Size = new Size(76, 54);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(18, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 60);
            label1.TabIndex = 1;
            label1.Text = "Invoice";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(invoicePanel, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 69);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.Padding = new Padding(15, 0, 30, 0);
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel5.Size = new Size(318, 596);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // invoicePanel
            // 
            invoicePanel.AutoScroll = true;
            invoicePanel.AutoScrollMargin = new Size(0, 50);
            invoicePanel.BackColor = Color.White;
            invoicePanel.Dock = DockStyle.Fill;
            invoicePanel.Location = new Point(18, 3);
            invoicePanel.Margin = new Padding(3, 3, 3, 15);
            invoicePanel.Name = "invoicePanel";
            invoicePanel.Padding = new Padding(0, 50, 0, 50);
            invoicePanel.Size = new Size(267, 518);
            invoicePanel.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(button2, 0, 0);
            tableLayoutPanel6.Controls.Add(button3, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(18, 539);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(267, 54);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(46, 204, 113);
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 15);
            button2.Margin = new Padding(3, 15, 15, 3);
            button2.Name = "button2";
            button2.Size = new Size(115, 36);
            button2.TabIndex = 0;
            button2.Text = "Confirm ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(231, 76, 60);
            button3.Dock = DockStyle.Fill;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(148, 15);
            button3.Margin = new Padding(15, 15, 3, 3);
            button3.Name = "button3";
            button3.Size = new Size(116, 36);
            button3.TabIndex = 1;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = false;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Payment";
            Size = new Size(1100, 704);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)paymentList).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button1;
        private Label label1;
        private Label label2;
        private DataGridView paymentList;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel invoicePanel;
        private TableLayoutPanel tableLayoutPanel6;
        private Button button2;
        private Button button3;
    }
}
