namespace HMS_SLS_Y4.Forms
{
    partial class UpdateFoodForm
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
            txtFoodName = new TextBox();
            label1 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            numPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // txtFoodName
            // 
            txtFoodName.Location = new Point(247, 70);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(280, 25);
            txtFoodName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 43);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(247, 164);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(280, 25);
            txtDescription.TabIndex = 2;
            txtDescription.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 136);
            label2.Name = "label2";
            label2.Size = new Size(78, 17);
            label2.TabIndex = 3;
            label2.Text = "Description ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 230);
            label3.Name = "label3";
            label3.Size = new Size(36, 17);
            label3.TabIndex = 5;
            label3.Text = "Price";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(252, 314);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(75, 39);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(425, 314);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 39);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(252, 258);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(282, 25);
            numPrice.TabIndex = 8;
            numPrice.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // UpdateFoodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 450);
            Controls.Add(numPrice);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label1);
            Controls.Add(txtFoodName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UpdateFoodForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UpdateFoodForm";
            Load += UpdateFoodForm_Load;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFoodName;
        private Label label1;
        private TextBox txtDescription;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
        private NumericUpDown numPrice;
    }
}