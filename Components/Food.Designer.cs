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
            splitContainer1 = new SplitContainer();
            flowLayoutPanel = new FlowLayoutPanel();
            savebtn = new Button();
            foodPrice = new TextBox();
            priceF = new Label();
            des = new TextBox();
            description = new Label();
            namefood = new TextBox();
            fname = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.AccessibleName = "leftContainer";
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel2.Controls.Add(savebtn);
            splitContainer1.Panel2.Controls.Add(foodPrice);
            splitContainer1.Panel2.Controls.Add(priceF);
            splitContainer1.Panel2.Controls.Add(des);
            splitContainer1.Panel2.Controls.Add(description);
            splitContainer1.Panel2.Controls.Add(namefood);
            splitContainer1.Panel2.Controls.Add(fname);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1292, 883);
            splitContainer1.SplitterDistance = 810;
            splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(0, 3);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel.Size = new Size(807, 880);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.Paint += flowLayoutPanel1_Paint;
            // 
            // savebtn
            // 
            savebtn.BackColor = Color.Lime;
            savebtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            savebtn.ForeColor = SystemColors.ControlLightLight;
            savebtn.Location = new Point(185, 485);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(75, 31);
            savebtn.TabIndex = 6;
            savebtn.Text = "Save";
            savebtn.UseVisualStyleBackColor = false;
            savebtn.Click += savebtn_Click;
            // 
            // foodPrice
            // 
            foodPrice.Location = new Point(115, 409);
            foodPrice.Name = "foodPrice";
            foodPrice.Size = new Size(216, 25);
            foodPrice.TabIndex = 5;
            // 
            // priceF
            // 
            priceF.AutoSize = true;
            priceF.Location = new Point(115, 382);
            priceF.Name = "priceF";
            priceF.Size = new Size(36, 17);
            priceF.TabIndex = 4;
            priceF.Text = "Price";
            // 
            // des
            // 
            des.Location = new Point(115, 318);
            des.Name = "des";
            des.Size = new Size(216, 25);
            des.TabIndex = 3;
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(115, 291);
            description.Name = "description";
            description.Size = new Size(74, 17);
            description.TabIndex = 2;
            description.Text = "Description";
            // 
            // namefood
            // 
            namefood.Location = new Point(115, 234);
            namefood.Name = "namefood";
            namefood.Size = new Size(216, 25);
            namefood.TabIndex = 1;
            // 
            // fname
            // 
            fname.AutoSize = true;
            fname.Location = new Point(115, 207);
            fname.Name = "fname";
            fname.Size = new Size(43, 17);
            fname.TabIndex = 0;
            fname.Text = "Name";
            fname.Click += fname_Click;
            // 
            // Food
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "Food";
            Size = new Size(1292, 883);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox namefood;
        private Label fname;
        private TextBox foodPrice;
        private Label priceF;
        private TextBox des;
        private Label description;
        private Button savebtn;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
