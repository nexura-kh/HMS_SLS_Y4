namespace HMS_SLS_Y4
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            login_btn = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            close_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(login_btn);
            splitContainer1.Panel1.Controls.Add(textBox2);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = Properties.Resources.Hotel_Image;
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            splitContainer1.Panel2.Controls.Add(close_btn);
            splitContainer1.Size = new Size(1171, 768);
            splitContainer1.SplitterDistance = 581;
            splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Rupp_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(223, 122);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(48, 67, 122);
            login_btn.FlatAppearance.BorderColor = Color.FromArgb(48, 67, 122);
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(209, 558);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(166, 45);
            login_btn.TabIndex = 6;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.FromArgb(48, 67, 122);
            textBox2.Location = new Point(155, 470);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(336, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.FromArgb(48, 67, 122);
            textBox1.Location = new Point(153, 392);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(336, 27);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(48, 67, 122);
            label4.Location = new Point(79, 473);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(48, 67, 122);
            label3.Location = new Point(79, 395);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(48, 67, 122);
            label2.Location = new Point(79, 332);
            label2.Name = "label2";
            label2.Size = new Size(410, 20);
            label2.TabIndex = 1;
            label2.Text = "Please Enter Your Email and Password to Login to the System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(48, 67, 122);
            label1.Location = new Point(241, 266);
            label1.Name = "label1";
            label1.Size = new Size(97, 41);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // close_btn
            // 
            close_btn.BackColor = Color.Transparent;
            close_btn.FlatAppearance.BorderSize = 0;
            close_btn.FlatStyle = FlatStyle.Flat;
            close_btn.Image = Properties.Resources.button5;
            close_btn.Location = new Point(530, 11);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(44, 47);
            close_btn.TabIndex = 0;
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += close_btn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1171, 768);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label label2;
        private Button login_btn;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private Button close_btn;
    }
}
