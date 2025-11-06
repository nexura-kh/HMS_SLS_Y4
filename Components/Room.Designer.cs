namespace HMS_SLS_Y4.Components
{
    partial class Room
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
            splitContainer1 = new SplitContainer();
            flowlayoutRoomCard = new FlowLayoutPanel();
            btnSave = new Button();
            cmbRoomType = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            textRoomNum = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(3, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowlayoutRoomCard);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(cmbRoomType);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(textRoomNum);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1407, 845);
            splitContainer1.SplitterDistance = 969;
            splitContainer1.TabIndex = 1;
            // 
            // flowlayoutRoomCard
            // 
            flowlayoutRoomCard.Location = new Point(3, 3);
            flowlayoutRoomCard.Name = "flowlayoutRoomCard";
            flowlayoutRoomCard.Size = new Size(954, 793);
            flowlayoutRoomCard.TabIndex = 0;
            flowlayoutRoomCard.Paint += flowlayoutRoomCard_Paint;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(188, 395);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(81, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbRoomType
            // 
            cmbRoomType.Location = new Point(109, 334);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(235, 25);
            cmbRoomType.TabIndex = 7;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 304);
            label3.Name = "label3";
            label3.Size = new Size(74, 17);
            label3.TabIndex = 5;
            label3.Text = "Room Type";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 204);
            label1.Name = "label1";
            label1.Size = new Size(95, 17);
            label1.TabIndex = 1;
            label1.Text = "Room Number";
            // 
            // textRoomNum
            // 
            textRoomNum.Location = new Point(109, 234);
            textRoomNum.Name = "textRoomNum";
            textRoomNum.Size = new Size(235, 25);
            textRoomNum.TabIndex = 0;
            textRoomNum.TextChanged += textRoomNum_TextChanged;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "Room";
            Size = new Size(1404, 799);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowlayoutRoomCard;
        private Label label1;
        private TextBox textRoomNum;
        private ComboBox cmbRoomType;
        private Label label3;
        private Button btnSave;
    }
}
