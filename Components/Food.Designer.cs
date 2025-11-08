namespace HMS_SLS_Y4.Components
{
    partial class Food
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            OrderTitle = new Label();
            foodPanel = new FlowLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            drinkPanel = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel6 = new Panel();
            txtFoodPrice = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txtFoodDescription = new TextBox();
            label5 = new Label();
            panel1 = new Panel();
            txtFoodName = new TextBox();
            label3 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            btnDeleteFood = new Button();
            btnAddFood = new Button();
            panel4 = new Panel();
            txtFoodType = new ComboBox();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(30, 31, 30, 31);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1099, 704);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(OrderTitle, 0, 0);
            tableLayoutPanel2.Controls.Add(foodPanel, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.Size = new Size(360, 696);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // OrderTitle
            // 
            OrderTitle.AutoSize = true;
            OrderTitle.Dock = DockStyle.Left;
            OrderTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            OrderTitle.Location = new Point(3, 0);
            OrderTitle.Name = "OrderTitle";
            OrderTitle.Padding = new Padding(30, 0, 0, 0);
            OrderTitle.Size = new Size(103, 69);
            OrderTitle.TabIndex = 7;
            OrderTitle.Text = "Food";
            OrderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // foodPanel
            // 
            foodPanel.AutoScroll = true;
            foodPanel.AutoScrollMargin = new Size(0, 50);
            foodPanel.BackColor = Color.White;
            foodPanel.Dock = DockStyle.Fill;
            foodPanel.Location = new Point(30, 100);
            foodPanel.Margin = new Padding(30, 31, 10, 53);
            foodPanel.Name = "foodPanel";
            foodPanel.Padding = new Padding(30, 31, 30, 49);
            foodPanel.Size = new Size(320, 543);
            foodPanel.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(drinkPanel, 0, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(369, 4);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel3.Size = new Size(360, 696);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // drinkPanel
            // 
            drinkPanel.AutoScroll = true;
            drinkPanel.AutoScrollMargin = new Size(0, 50);
            drinkPanel.BackColor = Color.White;
            drinkPanel.Dock = DockStyle.Fill;
            drinkPanel.Location = new Point(10, 100);
            drinkPanel.Margin = new Padding(10, 31, 10, 53);
            drinkPanel.Name = "drinkPanel";
            drinkPanel.Padding = new Padding(30, 31, 30, 49);
            drinkPanel.Size = new Size(340, 543);
            drinkPanel.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(30, 0, 0, 0);
            label1.Size = new Size(109, 69);
            label1.TabIndex = 7;
            label1.Text = "Drink";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(735, 4);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel4.Size = new Size(361, 696);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(30, 0, 0, 0);
            label2.Size = new Size(154, 69);
            label2.TabIndex = 8;
            label2.Text = "Add New";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(panel6, 0, 3);
            tableLayoutPanel5.Controls.Add(panel5, 0, 2);
            tableLayoutPanel5.Controls.Add(panel1, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 4);
            tableLayoutPanel5.Controls.Add(panel4, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(15, 100);
            tableLayoutPanel5.Margin = new Padding(15, 31, 30, 31);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 5;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.Size = new Size(316, 565);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtFoodPrice);
            panel6.Controls.Add(label6);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 343);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(310, 105);
            panel6.TabIndex = 3;
            // 
            // txtFoodPrice
            // 
            txtFoodPrice.Dock = DockStyle.Top;
            txtFoodPrice.Location = new Point(0, 23);
            txtFoodPrice.Margin = new Padding(3, 4, 21, 4);
            txtFoodPrice.Name = "txtFoodPrice";
            txtFoodPrice.Size = new Size(310, 27);
            txtFoodPrice.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(49, 23);
            label6.TabIndex = 2;
            label6.Text = "Price";
            // 
            // panel5
            // 
            panel5.Controls.Add(txtFoodDescription);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 230);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(310, 105);
            panel5.TabIndex = 2;
            // 
            // txtFoodDescription
            // 
            txtFoodDescription.Dock = DockStyle.Top;
            txtFoodDescription.Location = new Point(0, 23);
            txtFoodDescription.Margin = new Padding(3, 4, 21, 4);
            txtFoodDescription.Name = "txtFoodDescription";
            txtFoodDescription.Size = new Size(310, 27);
            txtFoodDescription.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 23);
            label5.TabIndex = 2;
            label5.Text = "Description";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtFoodName);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 105);
            panel1.TabIndex = 0;
            // 
            // txtFoodName
            // 
            txtFoodName.Dock = DockStyle.Top;
            txtFoodName.Location = new Point(0, 23);
            txtFoodName.Margin = new Padding(3, 4, 21, 4);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(310, 27);
            txtFoodName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(btnDeleteFood, 1, 0);
            tableLayoutPanel6.Controls.Add(btnAddFood, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 456);
            tableLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(310, 105);
            tableLayoutPanel6.TabIndex = 4;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteFood.Dock = DockStyle.Fill;
            btnDeleteFood.FlatStyle = FlatStyle.Popup;
            btnDeleteFood.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnDeleteFood.ForeColor = Color.White;
            btnDeleteFood.Location = new Point(170, 31);
            btnDeleteFood.Margin = new Padding(15, 31, 3, 31);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.Size = new Size(137, 43);
            btnDeleteFood.TabIndex = 1;
            btnDeleteFood.Text = "Delete";
            btnDeleteFood.UseVisualStyleBackColor = false;
            btnDeleteFood.Click += btnDeleteFood_Click;
            // 
            // btnAddFood
            // 
            btnAddFood.BackColor = Color.FromArgb(46, 204, 113);
            btnAddFood.Dock = DockStyle.Fill;
            btnAddFood.FlatStyle = FlatStyle.Popup;
            btnAddFood.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddFood.ForeColor = Color.White;
            btnAddFood.Location = new Point(3, 31);
            btnAddFood.Margin = new Padding(3, 31, 15, 31);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(137, 43);
            btnAddFood.TabIndex = 0;
            btnAddFood.Text = "Add";
            btnAddFood.UseVisualStyleBackColor = false;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtFoodType);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 117);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(310, 105);
            panel4.TabIndex = 5;
            // 
            // txtFoodType
            // 
            txtFoodType.Dock = DockStyle.Fill;
            txtFoodType.FormattingEnabled = true;
            txtFoodType.Location = new Point(0, 23);
            txtFoodType.Margin = new Padding(3, 4, 3, 4);
            txtFoodType.Name = "txtFoodType";
            txtFoodType.Size = new Size(310, 28);
            txtFoodType.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 23);
            label4.TabIndex = 3;
            label4.Text = "Type";
            // 
            // Food
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Food";
            Size = new Size(1099, 704);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label OrderTitle;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel1;
        private Panel panel6;
        private TextBox txtFoodPrice;
        private Label label6;
        private Panel panel5;
        private TextBox txtFoodDescription;
        private Label label5;
        private TextBox txtFoodName;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel6;
        private Button btnDeleteFood;
        private Button btnAddFood;
        private Panel panel4;
        private ComboBox txtFoodType;
        private Label label4;
        private FlowLayoutPanel foodPanel;
        private FlowLayoutPanel drinkPanel;
    }
}
