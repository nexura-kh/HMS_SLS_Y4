namespace HMS_SLS_Y4.Components
{
    partial class OrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderList));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            OrderTitle = new Label();
            orderList_data = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            invoicePanel = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnPrintOrder = new Button();
            label1 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnDeleteOrder = new Button();
            btnEditOrder = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderList_data).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
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
            tableLayoutPanel1.Padding = new Padding(30, 15, 30, 30);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1100, 703);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(OrderTitle, 0, 0);
            tableLayoutPanel2.Controls.Add(orderList_data, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(33, 18);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.Size = new Size(722, 652);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // OrderTitle
            // 
            OrderTitle.AutoSize = true;
            OrderTitle.Dock = DockStyle.Left;
            OrderTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            OrderTitle.Location = new Point(3, 0);
            OrderTitle.Name = "OrderTitle";
            OrderTitle.Size = new Size(131, 65);
            OrderTitle.TabIndex = 8;
            OrderTitle.Text = "Order List";
            OrderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // orderList_data
            // 
            orderList_data.BackgroundColor = SystemColors.ControlLight;
            orderList_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderList_data.Dock = DockStyle.Fill;
            orderList_data.Location = new Point(3, 68);
            orderList_data.Margin = new Padding(3, 3, 15, 15);
            orderList_data.Name = "orderList_data";
            orderList_data.RowHeadersWidth = 51;
            orderList_data.Size = new Size(704, 569);
            orderList_data.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(invoicePanel, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(761, 18);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.Size = new Size(306, 652);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // invoicePanel
            // 
            invoicePanel.AutoScroll = true;
            invoicePanel.AutoScrollMargin = new Size(0, 50);
            invoicePanel.BackColor = Color.White;
            invoicePanel.Dock = DockStyle.Fill;
            invoicePanel.Location = new Point(15, 80);
            invoicePanel.Margin = new Padding(15);
            invoicePanel.Name = "invoicePanel";
            invoicePanel.Padding = new Padding(0, 50, 0, 50);
            invoicePanel.Size = new Size(276, 491);
            invoicePanel.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(btnPrintOrder, 1, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(300, 59);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // btnPrintOrder
            // 
            btnPrintOrder.Dock = DockStyle.Right;
            btnPrintOrder.Image = (Image)resources.GetObject("btnPrintOrder.Image");
            btnPrintOrder.Location = new Point(221, 3);
            btnPrintOrder.Name = "btnPrintOrder";
            btnPrintOrder.Size = new Size(76, 53);
            btnPrintOrder.TabIndex = 10;
            btnPrintOrder.UseVisualStyleBackColor = true;
            btnPrintOrder.Click += btnPrintOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 59);
            label1.TabIndex = 9;
            label1.Text = "Description";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(btnDeleteOrder, 1, 0);
            tableLayoutPanel5.Controls.Add(btnEditOrder, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 589);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(300, 60);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteOrder.Dock = DockStyle.Fill;
            btnDeleteOrder.FlatStyle = FlatStyle.Popup;
            btnDeleteOrder.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteOrder.ForeColor = Color.White;
            btnDeleteOrder.Location = new Point(165, 15);
            btnDeleteOrder.Margin = new Padding(15);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(120, 30);
            btnDeleteOrder.TabIndex = 1;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = false;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnEditOrder
            // 
            btnEditOrder.BackColor = Color.FromArgb(52, 152, 219);
            btnEditOrder.Dock = DockStyle.Fill;
            btnEditOrder.FlatStyle = FlatStyle.Popup;
            btnEditOrder.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditOrder.ForeColor = Color.White;
            btnEditOrder.Location = new Point(15, 15);
            btnEditOrder.Margin = new Padding(15);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Size = new Size(120, 30);
            btnEditOrder.TabIndex = 0;
            btnEditOrder.Text = "Edit";
            btnEditOrder.UseVisualStyleBackColor = false;
            btnEditOrder.Click += btnEditOrder_Click;
            // 
            // OrderList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "OrderList";
            Size = new Size(1100, 703);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderList_data).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Label OrderTitle;
        private DataGridView orderList_data;
        private Label label1;
        private Button btnPrintOrder;
        private Button btnEditOrder;
        private Button btnDeleteOrder;
        private Panel invoicePanel;
    }
}
