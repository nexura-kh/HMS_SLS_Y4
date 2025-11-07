namespace HMS_SLS_Y4.Components
{
    partial class Reservation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel roomDisplayPanel;

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
            booked_list = new DataGridView();
            splitContainer1 = new SplitContainer();
            available_room = new Panel();
            reservation_form = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            splitContainer2 = new SplitContainer();
            txtFirstName = new TextBox();
            first_name_label = new Label();
            txtLastName = new TextBox();
            last_name_label = new Label();
            splitContainer3 = new SplitContainer();
            txtDob = new DateTimePicker();
            age_label = new Label();
            txtNationality = new TextBox();
            nationality_label = new Label();
            splitContainer4 = new SplitContainer();
            txtIdCard = new TextBox();
            id_card_label = new Label();
            txtIdType = new ComboBox();
            status_label = new Label();
            splitContainer5 = new SplitContainer();
            txtCheckIn = new DateTimePicker();
            check_in_label = new Label();
            txtCheckOut = new DateTimePicker();
            check_out_label = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel10 = new Panel();
            addOrderBtn = new Button();
            panel11 = new Panel();
            editOrderBtn = new Button();
            panel12 = new Panel();
            deleteOrderBtn = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            OrderTitle = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            roomNumberValue = new Label();
            roomLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booked_list).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            reservation_form.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(booked_list, 0, 1);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(962, 598);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // booked_list
            // 
            booked_list.AllowUserToResizeColumns = false;
            booked_list.AllowUserToResizeRows = false;
            booked_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            booked_list.BackgroundColor = Color.FromArgb(224, 224, 224);
            booked_list.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booked_list.Dock = DockStyle.Fill;
            booked_list.GridColor = SystemColors.InactiveCaption;
            booked_list.Location = new Point(26, 444);
            booked_list.Margin = new Padding(26);
            booked_list.Name = "booked_list";
            booked_list.RowHeadersWidth = 51;
            booked_list.ScrollBars = ScrollBars.Vertical;
            booked_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booked_list.Size = new Size(910, 128);
            booked_list.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(26, 26);
            splitContainer1.Margin = new Padding(26, 26, 26, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(available_room);
            splitContainer1.Panel1.Margin = new Padding(0, 0, 0, 6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(reservation_form);
            splitContainer1.Panel2.Margin = new Padding(6, 0, 0, 0);
            splitContainer1.Size = new Size(910, 392);
            splitContainer1.SplitterDistance = 406;
            splitContainer1.TabIndex = 1;
            // 
            // available_room
            // 
            available_room.Dock = DockStyle.Fill;
            available_room.Location = new Point(0, 0);
            available_room.Name = "available_room";
            available_room.Size = new Size(406, 392);
            available_room.TabIndex = 0;
            // 
            // reservation_form
            // 
            reservation_form.Controls.Add(tableLayoutPanel2);
            reservation_form.Dock = DockStyle.Fill;
            reservation_form.Location = new Point(0, 0);
            reservation_form.Name = "reservation_form";
            reservation_form.Size = new Size(500, 392);
            reservation_form.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(splitContainer2, 0, 1);
            tableLayoutPanel2.Controls.Add(splitContainer3, 0, 2);
            tableLayoutPanel2.Controls.Add(splitContainer4, 0, 3);
            tableLayoutPanel2.Controls.Add(splitContainer5, 0, 4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 5);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(571, 462);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 68);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(txtFirstName);
            splitContainer2.Panel1.Controls.Add(first_name_label);
            splitContainer2.Panel1.Padding = new Padding(18, 8, 18, 8);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtLastName);
            splitContainer2.Panel2.Controls.Add(last_name_label);
            splitContainer2.Panel2.Padding = new Padding(18, 8, 18, 8);
            splitContainer2.Size = new Size(494, 59);
            splitContainer2.SplitterDistance = 247;
            splitContainer2.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Dock = DockStyle.Bottom;
            txtFirstName.Location = new Point(20, 34);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(243, 27);
            txtFirstName.TabIndex = 1;
            // 
            // first_name_label
            // 
            first_name_label.AutoSize = true;
            first_name_label.Dock = DockStyle.Top;
            first_name_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            first_name_label.Location = new Point(18, 8);
            first_name_label.Name = "first_name_label";
            first_name_label.Size = new Size(81, 19);
            first_name_label.TabIndex = 0;
            first_name_label.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Dock = DockStyle.Bottom;
            txtLastName.Location = new Point(20, 34);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(238, 27);
            txtLastName.TabIndex = 2;
            // 
            // last_name_label
            // 
            last_name_label.AutoSize = true;
            last_name_label.Dock = DockStyle.Top;
            last_name_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            last_name_label.Location = new Point(18, 8);
            last_name_label.Name = "last_name_label";
            last_name_label.Size = new Size(79, 19);
            last_name_label.TabIndex = 1;
            last_name_label.Text = "Last Name";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 133);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(txtDob);
            splitContainer3.Panel1.Controls.Add(age_label);
            splitContainer3.Panel1.Padding = new Padding(18, 8, 18, 8);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(txtNationality);
            splitContainer3.Panel2.Controls.Add(nationality_label);
            splitContainer3.Panel2.Padding = new Padding(18, 8, 18, 8);
            splitContainer3.Size = new Size(494, 59);
            splitContainer3.SplitterDistance = 247;
            splitContainer3.TabIndex = 1;
            // 
            // txtDob
            // 
            txtDob.Dock = DockStyle.Bottom;
            txtDob.Location = new Point(20, 34);
            txtDob.Name = "txtDob";
            txtDob.Size = new Size(243, 27);
            txtDob.TabIndex = 4;
            // 
            // age_label
            // 
            age_label.AutoSize = true;
            age_label.Dock = DockStyle.Top;
            age_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            age_label.Location = new Point(18, 8);
            age_label.Name = "age_label";
            age_label.Size = new Size(115, 23);
            age_label.TabIndex = 1;
            age_label.Text = "Date of Birth";
            // 
            // txtNationality
            // 
            txtNationality.Dock = DockStyle.Bottom;
            txtNationality.Location = new Point(20, 34);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(238, 27);
            txtNationality.TabIndex = 3;
            // 
            // nationality_label
            // 
            nationality_label.AutoSize = true;
            nationality_label.Dock = DockStyle.Top;
            nationality_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nationality_label.Location = new Point(18, 8);
            nationality_label.Name = "nationality_label";
            nationality_label.Size = new Size(83, 19);
            nationality_label.TabIndex = 2;
            nationality_label.Text = "Nationality";
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(3, 198);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(txtIdCard);
            splitContainer4.Panel1.Controls.Add(id_card_label);
            splitContainer4.Panel1.Padding = new Padding(18, 8, 18, 8);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(txtIdType);
            splitContainer4.Panel2.Controls.Add(status_label);
            splitContainer4.Panel2.Padding = new Padding(18, 8, 18, 8);
            splitContainer4.Size = new Size(494, 59);
            splitContainer4.SplitterDistance = 247;
            splitContainer4.TabIndex = 2;
            // 
            // txtIdCard
            // 
            txtIdCard.Dock = DockStyle.Bottom;
            txtIdCard.Location = new Point(20, 34);
            txtIdCard.Name = "txtIdCard";
            txtIdCard.Size = new Size(243, 27);
            txtIdCard.TabIndex = 3;
            // 
            // id_card_label
            // 
            id_card_label.AutoSize = true;
            id_card_label.Dock = DockStyle.Top;
            id_card_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            id_card_label.Location = new Point(18, 8);
            id_card_label.Name = "id_card_label";
            id_card_label.Size = new Size(59, 19);
            id_card_label.TabIndex = 2;
            id_card_label.Text = "ID Card";
            // 
            // txtIdType
            // 
            txtIdType.Dock = DockStyle.Bottom;
            txtIdType.FormattingEnabled = true;
            var idTypes = new[]
            {
                new { Value = 1, Text = "Passport" },
                new { Value = 2, Text = "ID Card" },
                new { Value = 3, Text = "Driver's License" },
                new { Value = 4, Text = "Military ID" }
            };
            txtIdType.DataSource = idTypes.ToList();
            txtIdType.DisplayMember = "Text"; // what the user sees
            txtIdType.ValueMember = "Value";
            txtIdType.Location = new Point(20, 33);
            txtIdType.Name = "txtIdType";
            txtIdType.Size = new Size(238, 28);
            txtIdType.TabIndex = 3;
            // 
            // status_label
            // 
            status_label.AutoSize = true;
            status_label.Dock = DockStyle.Top;
            status_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            status_label.Location = new Point(18, 8);
            status_label.Name = "status_label";
            status_label.Size = new Size(41, 19);
            status_label.TabIndex = 2;
            status_label.Text = "Type";
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(3, 263);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(txtCheckIn);
            splitContainer5.Panel1.Controls.Add(check_in_label);
            splitContainer5.Panel1.Padding = new Padding(18, 8, 18, 8);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(txtCheckOut);
            splitContainer5.Panel2.Controls.Add(check_out_label);
            splitContainer5.Panel2.Padding = new Padding(18, 8, 18, 8);
            splitContainer5.Size = new Size(494, 59);
            splitContainer5.SplitterDistance = 247;
            splitContainer5.TabIndex = 3;
            // 
            // txtCheckIn
            // 
            txtCheckIn.Dock = DockStyle.Bottom;
            txtCheckIn.Location = new Point(20, 34);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.Size = new Size(243, 27);
            txtCheckIn.TabIndex = 3;
            // 
            // check_in_label
            // 
            check_in_label.AutoSize = true;
            check_in_label.Dock = DockStyle.Top;
            check_in_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            check_in_label.Location = new Point(18, 8);
            check_in_label.Name = "check_in_label";
            check_in_label.Size = new Size(65, 19);
            check_in_label.TabIndex = 2;
            check_in_label.Text = "Check In";
            // 
            // txtCheckOut
            // 
            txtCheckOut.Dock = DockStyle.Bottom;
            txtCheckOut.Location = new Point(20, 34);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.Size = new Size(238, 27);
            txtCheckOut.TabIndex = 4;
            // 
            // check_out_label
            // 
            check_out_label.AutoSize = true;
            check_out_label.Dock = DockStyle.Top;
            check_out_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            check_out_label.Location = new Point(18, 8);
            check_out_label.Name = "check_out_label";
            check_out_label.Size = new Size(77, 19);
            check_out_label.TabIndex = 2;
            check_out_label.Text = "Check Out";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(panel10, 0, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 0);
            tableLayoutPanel3.Controls.Add(panel12, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 328);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(565, 71);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // panel10
            // 
            panel10.Controls.Add(addOrderBtn);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 3);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(30, 15, 15, 0);
            panel10.Size = new Size(182, 65);
            panel10.TabIndex = 6;
            // 
            // addOrderBtn
            // 
            addOrderBtn.BackColor = Color.FromArgb(46, 204, 113);
            addOrderBtn.Dock = DockStyle.Bottom;
            addOrderBtn.FlatStyle = FlatStyle.Popup;
            addOrderBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            addOrderBtn.ForeColor = Color.White;
            addOrderBtn.Location = new Point(30, 21);
            addOrderBtn.Name = "addOrderBtn";
            addOrderBtn.Size = new Size(137, 44);
            addOrderBtn.TabIndex = 1;
            addOrderBtn.Text = "Add";
            addOrderBtn.UseVisualStyleBackColor = false;
            addOrderBtn.Click += addOrderBtn_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(editOrderBtn);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(191, 3);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(30, 15, 15, 0);
            panel11.Size = new Size(182, 65);
            panel11.TabIndex = 7;
            // 
            // editOrderBtn
            // 
            editOrderBtn.BackColor = Color.FromArgb(52, 152, 219);
            editOrderBtn.Dock = DockStyle.Bottom;
            editOrderBtn.FlatStyle = FlatStyle.Popup;
            editOrderBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editOrderBtn.ForeColor = Color.White;
            editOrderBtn.Location = new Point(30, 21);
            editOrderBtn.Name = "editOrderBtn";
            editOrderBtn.Size = new Size(137, 44);
            editOrderBtn.TabIndex = 2;
            editOrderBtn.Text = "Edit";
            editOrderBtn.UseVisualStyleBackColor = false;
            editOrderBtn.Click += btnEdit_Click;
            // 
            // panel12
            // 
            panel12.Controls.Add(deleteOrderBtn);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(379, 3);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(15, 15, 30, 0);
            panel12.Size = new Size(183, 65);
            panel12.TabIndex = 8;
            // 
            // deleteOrderBtn
            // 
            deleteOrderBtn.BackColor = Color.FromArgb(231, 76, 60);
            deleteOrderBtn.Dock = DockStyle.Bottom;
            deleteOrderBtn.FlatStyle = FlatStyle.Popup;
            deleteOrderBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteOrderBtn.ForeColor = Color.White;
            deleteOrderBtn.Location = new Point(15, 21);
            deleteOrderBtn.Name = "deleteOrderBtn";
            deleteOrderBtn.Size = new Size(138, 44);
            deleteOrderBtn.TabIndex = 3;
            deleteOrderBtn.Text = "Delete";
            deleteOrderBtn.UseVisualStyleBackColor = false;
            deleteOrderBtn.Click += btnDelete_Click;   
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(OrderTitle, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(565, 71);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // OrderTitle
            // 
            OrderTitle.AutoSize = true;
            OrderTitle.Dock = DockStyle.Left;
            OrderTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            OrderTitle.Location = new Point(3, 0);
            OrderTitle.Name = "OrderTitle";
            OrderTitle.Padding = new Padding(20, 0, 0, 0);
            OrderTitle.Size = new Size(176, 71);
            OrderTitle.TabIndex = 8;
            OrderTitle.Text = "Reservation Information";
            OrderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(roomNumberValue, 1, 0);
            tableLayoutPanel5.Controls.Add(roomLabel, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(285, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(277, 65);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // roomNumberValue
            // 
            roomNumberValue.AutoSize = true;
            roomNumberValue.Dock = DockStyle.Right;
            roomNumberValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            roomNumberValue.Location = new Point(182, 0);
            roomNumberValue.Margin = new Padding(3, 0, 30, 0);
            roomNumberValue.Name = "roomNumberValue";
            roomNumberValue.Padding = new Padding(20, 0, 0, 0);
            roomNumberValue.Size = new Size(65, 65);
            roomNumberValue.TabIndex = 11;
            roomNumberValue.Text = "---";
            roomNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // roomLabel
            // 
            roomLabel.AutoSize = true;
            roomLabel.Dock = DockStyle.Left;
            roomLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            roomLabel.Location = new Point(3, 0);
            roomLabel.Name = "roomLabel";
            roomLabel.Padding = new Padding(20, 0, 0, 0);
            roomLabel.Size = new Size(124, 65);
            roomLabel.TabIndex = 10;
            roomLabel.Text = "Room : ";
            roomLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Reservation";
            Size = new Size(962, 598);
            Load += UserControl1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booked_list).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            reservation_form.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel1.PerformLayout();
            splitContainer4.Panel2.ResumeLayout(false);
            splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView booked_list;
        private SplitContainer splitContainer1;
        private Panel available_room;
        private Panel reservation_form;
        private TableLayoutPanel tableLayoutPanel2;
        private SplitContainer splitContainer2;
        private TextBox txtFirstName;
        private Label first_name_label;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private TextBox txtLastName;
        private Label last_name_label;
        private Label age_label;
        private Label nationality_label;
        private Label id_card_label;
        private Label status_label;
        private Label check_in_label;
        private Label check_out_label;
        private TextBox txtNationality;
        private TextBox txtIdCard;
        private DateTimePicker txtCheckIn;
        private DateTimePicker txtCheckOut;
        private ComboBox txtIdType;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel10;
        private Button addOrderBtn;
        private Panel panel11;
        private Button editOrderBtn;
        private Panel panel12;
        private Button deleteOrderBtn;
        private DateTimePicker txtDob;
        private TableLayoutPanel tableLayoutPanel4;
        private Label OrderTitle;
        private TableLayoutPanel tableLayoutPanel5;
        private Label roomNumberValue;
        private Label roomLabel;
    }
}
