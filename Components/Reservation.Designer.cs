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
            textBox1 = new TextBox();
            first_name_label = new Label();
            textBox2 = new TextBox();
            last_name_label = new Label();
            splitContainer3 = new SplitContainer();
            textBox3 = new TextBox();
            age_label = new Label();
            textBox4 = new TextBox();
            nationality_label = new Label();
            splitContainer4 = new SplitContainer();
            textBox5 = new TextBox();
            id_card_label = new Label();
            status = new ComboBox();
            status_label = new Label();
            splitContainer5 = new SplitContainer();
            check_in = new DateTimePicker();
            check_in_label = new Label();
            check_out = new DateTimePicker();
            check_out_label = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            delete_btn = new Button();
            button1 = new Button();
            add_btn = new Button();
            panel1 = new Panel();
            reservation_title = new Label();
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
            panel1.SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(1100, 703);
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
            booked_list.Location = new Point(30, 522);
            booked_list.Margin = new Padding(30);
            booked_list.Name = "booked_list";
            booked_list.RowHeadersWidth = 51;
            booked_list.ScrollBars = ScrollBars.Vertical;
            booked_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booked_list.Size = new Size(1040, 151);
            booked_list.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(30, 30);
            splitContainer1.Margin = new Padding(30, 30, 30, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(available_room);
            splitContainer1.Panel1.Margin = new Padding(0, 0, 0, 7);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(reservation_form);
            splitContainer1.Panel2.Margin = new Padding(7, 0, 0, 0);
            splitContainer1.Size = new Size(1040, 462);
            splitContainer1.SplitterDistance = 465;
            splitContainer1.TabIndex = 1;
            // 
            // available_room
            // 
            available_room.Dock = DockStyle.Fill;
            available_room.Location = new Point(0, 0);
            available_room.Name = "available_room";
            available_room.Size = new Size(465, 462);
            available_room.TabIndex = 0;
            // 
            // reservation_form
            // 
            reservation_form.Controls.Add(tableLayoutPanel2);
            reservation_form.Dock = DockStyle.Fill;
            reservation_form.Location = new Point(0, 0);
            reservation_form.Name = "reservation_form";
            reservation_form.Size = new Size(571, 462);
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
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
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
            tableLayoutPanel2.Size = new Size(571, 462);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 80);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(textBox1);
            splitContainer2.Panel1.Controls.Add(first_name_label);
            splitContainer2.Panel1.Padding = new Padding(20, 10, 20, 10);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(textBox2);
            splitContainer2.Panel2.Controls.Add(last_name_label);
            splitContainer2.Panel2.Padding = new Padding(20, 10, 20, 10);
            splitContainer2.Size = new Size(565, 71);
            splitContainer2.SplitterDistance = 283;
            splitContainer2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(20, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 27);
            textBox1.TabIndex = 1;
            // 
            // first_name_label
            // 
            first_name_label.AutoSize = true;
            first_name_label.Dock = DockStyle.Top;
            first_name_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            first_name_label.Location = new Point(20, 10);
            first_name_label.Name = "first_name_label";
            first_name_label.Size = new Size(97, 23);
            first_name_label.TabIndex = 0;
            first_name_label.Text = "First Name";
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(20, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 27);
            textBox2.TabIndex = 2;
            // 
            // last_name_label
            // 
            last_name_label.AutoSize = true;
            last_name_label.Dock = DockStyle.Top;
            last_name_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            last_name_label.Location = new Point(20, 10);
            last_name_label.Name = "last_name_label";
            last_name_label.Size = new Size(94, 23);
            last_name_label.TabIndex = 1;
            last_name_label.Text = "Last Name";
            last_name_label.Click += label1_Click_1;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 157);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(textBox3);
            splitContainer3.Panel1.Controls.Add(age_label);
            splitContainer3.Panel1.Padding = new Padding(20, 10, 20, 10);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(textBox4);
            splitContainer3.Panel2.Controls.Add(nationality_label);
            splitContainer3.Panel2.Padding = new Padding(20, 10, 20, 10);
            splitContainer3.Size = new Size(565, 71);
            splitContainer3.SplitterDistance = 283;
            splitContainer3.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(20, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(243, 27);
            textBox3.TabIndex = 2;
            // 
            // age_label
            // 
            age_label.AutoSize = true;
            age_label.Dock = DockStyle.Top;
            age_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            age_label.Location = new Point(20, 10);
            age_label.Name = "age_label";
            age_label.Size = new Size(42, 23);
            age_label.TabIndex = 1;
            age_label.Text = "Age";
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(20, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(238, 27);
            textBox4.TabIndex = 3;
            // 
            // nationality_label
            // 
            nationality_label.AutoSize = true;
            nationality_label.Dock = DockStyle.Top;
            nationality_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nationality_label.Location = new Point(20, 10);
            nationality_label.Name = "nationality_label";
            nationality_label.Size = new Size(99, 23);
            nationality_label.TabIndex = 2;
            nationality_label.Text = "Nationality";
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(3, 234);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(textBox5);
            splitContainer4.Panel1.Controls.Add(id_card_label);
            splitContainer4.Panel1.Padding = new Padding(20, 10, 20, 10);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(status);
            splitContainer4.Panel2.Controls.Add(status_label);
            splitContainer4.Panel2.Padding = new Padding(20, 10, 20, 10);
            splitContainer4.Size = new Size(565, 71);
            splitContainer4.SplitterDistance = 283;
            splitContainer4.TabIndex = 2;
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(20, 33);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(243, 27);
            textBox5.TabIndex = 3;
            // 
            // id_card_label
            // 
            id_card_label.AutoSize = true;
            id_card_label.Dock = DockStyle.Top;
            id_card_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            id_card_label.Location = new Point(20, 10);
            id_card_label.Name = "id_card_label";
            id_card_label.Size = new Size(71, 23);
            id_card_label.TabIndex = 2;
            id_card_label.Text = "ID Card";
            // 
            // status
            // 
            status.Dock = DockStyle.Fill;
            status.FormattingEnabled = true;
            status.Items.AddRange(new object[] { "Booked", "Cancelled" });
            status.Location = new Point(20, 33);
            status.Name = "status";
            status.Size = new Size(238, 28);
            status.TabIndex = 3;
            // 
            // status_label
            // 
            status_label.AutoSize = true;
            status_label.Dock = DockStyle.Top;
            status_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            status_label.Location = new Point(20, 10);
            status_label.Name = "status_label";
            status_label.Size = new Size(48, 23);
            status_label.TabIndex = 2;
            status_label.Text = "Type";
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(3, 311);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(check_in);
            splitContainer5.Panel1.Controls.Add(check_in_label);
            splitContainer5.Panel1.Padding = new Padding(20, 10, 20, 10);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(check_out);
            splitContainer5.Panel2.Controls.Add(check_out_label);
            splitContainer5.Panel2.Padding = new Padding(20, 10, 20, 10);
            splitContainer5.Size = new Size(565, 71);
            splitContainer5.SplitterDistance = 283;
            splitContainer5.TabIndex = 3;
            // 
            // check_in
            // 
            check_in.Dock = DockStyle.Fill;
            check_in.Location = new Point(20, 33);
            check_in.Name = "check_in";
            check_in.Size = new Size(243, 27);
            check_in.TabIndex = 3;
            // 
            // check_in_label
            // 
            check_in_label.AutoSize = true;
            check_in_label.Dock = DockStyle.Top;
            check_in_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            check_in_label.Location = new Point(20, 10);
            check_in_label.Name = "check_in_label";
            check_in_label.Size = new Size(78, 23);
            check_in_label.TabIndex = 2;
            check_in_label.Text = "Check In";
            // 
            // check_out
            // 
            check_out.Dock = DockStyle.Fill;
            check_out.Location = new Point(20, 33);
            check_out.Name = "check_out";
            check_out.Size = new Size(238, 27);
            check_out.TabIndex = 4;
            // 
            // check_out_label
            // 
            check_out_label.AutoSize = true;
            check_out_label.Dock = DockStyle.Top;
            check_out_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            check_out_label.Location = new Point(20, 10);
            check_out_label.Name = "check_out_label";
            check_out_label.Size = new Size(93, 23);
            check_out_label.TabIndex = 2;
            check_out_label.Text = "Check Out";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(delete_btn, 2, 0);
            tableLayoutPanel3.Controls.Add(button1, 1, 0);
            tableLayoutPanel3.Controls.Add(add_btn, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 388);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(20);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(565, 71);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(231, 76, 60);
            delete_btn.Dock = DockStyle.Fill;
            delete_btn.FlatStyle = FlatStyle.Popup;
            delete_btn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            delete_btn.ForeColor = Color.White;
            delete_btn.Location = new Point(373, 23);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(169, 25);
            delete_btn.TabIndex = 2;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(198, 23);
            button1.Name = "button1";
            button1.Size = new Size(169, 25);
            button1.TabIndex = 1;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.FromArgb(46, 204, 113);
            add_btn.Dock = DockStyle.Fill;
            add_btn.FlatStyle = FlatStyle.Popup;
            add_btn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add_btn.ForeColor = Color.White;
            add_btn.Location = new Point(23, 23);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(169, 25);
            add_btn.TabIndex = 0;
            add_btn.Text = "Add";
            add_btn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(reservation_title);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(565, 71);
            panel1.TabIndex = 5;
            // 
            // reservation_title
            // 
            reservation_title.AutoSize = true;
            reservation_title.Dock = DockStyle.Top;
            reservation_title.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reservation_title.Location = new Point(20, 20);
            reservation_title.Name = "reservation_title";
            reservation_title.Size = new Size(276, 31);
            reservation_title.TabIndex = 1;
            reservation_title.Text = "Reservation Information";
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Reservation";
            Size = new Size(1100, 703);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox textBox1;
        private Label first_name_label;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox2;
        private Label last_name_label;
        private Label age_label;
        private Label nationality_label;
        private Label id_card_label;
        private Label status_label;
        private Label check_in_label;
        private Label check_out_label;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Panel panel1;
        private Label reservation_title;
        private DateTimePicker check_in;
        private DateTimePicker check_out;
        private ComboBox status;
        private Button add_btn;
        private Button delete_btn;
        private Button button1;
    }
}
