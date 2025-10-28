namespace HMS_SLS_Y4
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            reservation_btn = new Button();
            customer_btn = new Button();
            button4 = new Button();
            room_btn = new Button();
            food_btn = new Button();
            payment_btn = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label2 = new Label();
            exit_btn = new Button();
            container = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(48, 67, 122);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(reservation_btn);
            flowLayoutPanel1.Controls.Add(customer_btn);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(room_btn);
            flowLayoutPanel1.Controls.Add(food_btn);
            flowLayoutPanel1.Controls.Add(payment_btn);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(216, 664);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 178);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 129);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 1;
            label1.Text = "G1_HMS";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Rupp_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(60, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 94);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // reservation_btn
            // 
            reservation_btn.BackColor = Color.Transparent;
            reservation_btn.Dock = DockStyle.Top;
            reservation_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            reservation_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            reservation_btn.FlatStyle = FlatStyle.Flat;
            reservation_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reservation_btn.ForeColor = Color.White;
            reservation_btn.Image = (Image)resources.GetObject("reservation_btn.Image");
            reservation_btn.ImageAlign = ContentAlignment.MiddleRight;
            reservation_btn.Location = new Point(0, 178);
            reservation_btn.Margin = new Padding(0);
            reservation_btn.Name = "reservation_btn";
            reservation_btn.Padding = new Padding(35, 0, 0, 0);
            reservation_btn.RightToLeft = RightToLeft.Yes;
            reservation_btn.Size = new Size(216, 68);
            reservation_btn.TabIndex = 1;
            reservation_btn.Text = "Reservation";
            reservation_btn.UseVisualStyleBackColor = false;
            reservation_btn.Click += reservation_btn_Click;
            // 
            // customer_btn
            // 
            customer_btn.BackColor = Color.Transparent;
            customer_btn.Dock = DockStyle.Top;
            customer_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            customer_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            customer_btn.FlatStyle = FlatStyle.Flat;
            customer_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customer_btn.ForeColor = Color.White;
            customer_btn.Image = Properties.Resources.customer;
            customer_btn.ImageAlign = ContentAlignment.MiddleRight;
            customer_btn.Location = new Point(0, 246);
            customer_btn.Margin = new Padding(0);
            customer_btn.Name = "customer_btn";
            customer_btn.Padding = new Padding(35, 0, 0, 0);
            customer_btn.RightToLeft = RightToLeft.Yes;
            customer_btn.Size = new Size(216, 68);
            customer_btn.TabIndex = 4;
            customer_btn.Text = "Customer";
            customer_btn.UseVisualStyleBackColor = false;
            customer_btn.Click += customer_btn_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(0, 314);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Padding = new Padding(35, 0, 0, 0);
            button4.RightToLeft = RightToLeft.Yes;
            button4.Size = new Size(216, 0);
            button4.TabIndex = 7;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = false;
            // 
            // room_btn
            // 
            room_btn.BackColor = Color.Transparent;
            room_btn.Dock = DockStyle.Top;
            room_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            room_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            room_btn.FlatStyle = FlatStyle.Flat;
            room_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            room_btn.ForeColor = Color.White;
            room_btn.Image = Properties.Resources.room;
            room_btn.ImageAlign = ContentAlignment.MiddleRight;
            room_btn.Location = new Point(0, 314);
            room_btn.Margin = new Padding(0);
            room_btn.Name = "room_btn";
            room_btn.Padding = new Padding(35, 0, 0, 0);
            room_btn.RightToLeft = RightToLeft.Yes;
            room_btn.Size = new Size(216, 68);
            room_btn.TabIndex = 8;
            room_btn.Text = "Room";
            room_btn.UseVisualStyleBackColor = false;
            room_btn.Click += room_btn_Click;
            // 
            // food_btn
            // 
            food_btn.BackColor = Color.Transparent;
            food_btn.Dock = DockStyle.Top;
            food_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            food_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            food_btn.FlatStyle = FlatStyle.Flat;
            food_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            food_btn.ForeColor = Color.White;
            food_btn.Image = Properties.Resources.food;
            food_btn.ImageAlign = ContentAlignment.MiddleRight;
            food_btn.Location = new Point(0, 382);
            food_btn.Margin = new Padding(0);
            food_btn.Name = "food_btn";
            food_btn.Padding = new Padding(35, 0, 0, 0);
            food_btn.RightToLeft = RightToLeft.Yes;
            food_btn.Size = new Size(216, 68);
            food_btn.TabIndex = 9;
            food_btn.Text = "Food";
            food_btn.UseVisualStyleBackColor = false;
            food_btn.Click += food_btn_Click;
            // 
            // payment_btn
            // 
            payment_btn.BackColor = Color.Transparent;
            payment_btn.Dock = DockStyle.Top;
            payment_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            payment_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            payment_btn.FlatStyle = FlatStyle.Flat;
            payment_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payment_btn.ForeColor = Color.White;
            payment_btn.Image = Properties.Resources.wallet;
            payment_btn.ImageAlign = ContentAlignment.MiddleRight;
            payment_btn.Location = new Point(0, 450);
            payment_btn.Margin = new Padding(0);
            payment_btn.Name = "payment_btn";
            payment_btn.Padding = new Padding(35, 0, 0, 0);
            payment_btn.RightToLeft = RightToLeft.Yes;
            payment_btn.Size = new Size(216, 68);
            payment_btn.TabIndex = 10;
            payment_btn.Text = "Payment";
            payment_btn.UseVisualStyleBackColor = false;
            payment_btn.Click += payment_btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(216, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(963, 664);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(container, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(963, 664);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(exit_btn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(963, 66);
            panel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(48, 67, 122);
            label2.Location = new Point(18, 16);
            label2.Name = "label2";
            label2.Size = new Size(294, 30);
            label2.TabIndex = 1;
            label2.Text = "Hotel Management System";
            // 
            // exit_btn
            // 
            exit_btn.Dock = DockStyle.Right;
            exit_btn.FlatAppearance.BorderSize = 0;
            exit_btn.FlatStyle = FlatStyle.Flat;
            exit_btn.Image = Properties.Resources.logout;
            exit_btn.Location = new Point(880, 0);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(83, 66);
            exit_btn.TabIndex = 0;
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // container
            // 
            container.Dock = DockStyle.Fill;
            container.Location = new Point(0, 66);
            container.Margin = new Padding(0);
            container.Name = "container";
            container.Size = new Size(963, 598);
            container.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 664);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(898, 618);
            Name = "Main";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button reservation_btn;
        private Button customer_btn;
        private Button button4;
        private PictureBox pictureBox1;
        private Label label1;
        private Button room_btn;
        private Button food_btn;
        private Button payment_btn;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Button exit_btn;
        private Label label2;
        private Panel container;
    }
}