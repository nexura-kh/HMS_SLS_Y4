namespace HMS_SLS_Y4.Forms
{
    partial class RoomDetailForm
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
            txtPrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtDescription = new TextBox();
            saveBtn = new Button();
            deleteBtn = new Button();
            SuspendLayout();
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(108, 85);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(223, 25);
            txtPrice.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 56);
            label1.Name = "label1";
            label1.Size = new Size(95, 17);
            label1.TabIndex = 1;
            label1.Text = "Price Per Night";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 135);
            label2.Name = "label2";
            label2.Size = new Size(74, 17);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(108, 163);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(223, 25);
            txtDescription.TabIndex = 3;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.Lime;
            saveBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            saveBtn.ForeColor = SystemColors.ControlLightLight;
            saveBtn.Location = new Point(239, 235);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 33);
            saveBtn.TabIndex = 4;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.FromArgb(255, 128, 128);
            deleteBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            deleteBtn.ForeColor = SystemColors.ButtonHighlight;
            deleteBtn.Location = new Point(107, 235);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 33);
            deleteBtn.TabIndex = 5;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // RoomDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(deleteBtn);
            Controls.Add(saveBtn);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPrice);
            Name = "RoomDetailForm";
            Text = "RoomDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrice;
        private Label label1;
        private Label label2;
        private TextBox txtDescription;
        private Button saveBtn;
        private Button deleteBtn;
    }
}