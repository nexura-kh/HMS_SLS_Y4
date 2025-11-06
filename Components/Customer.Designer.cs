namespace HMS_SLS_Y4.Components
{
    partial class Customer
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
            pnlMainLayout = new Panel();
            pnlContentContainer = new TableLayoutPanel();
            pnlListsContainer = new TableLayoutPanel();
            pnlRecentActivity = new Panel();
            pnlRecentCard3 = new Panel();
            lblRecentDate3 = new Label();
            lblRecentTitle3 = new Label();
            pnlRecentCard2 = new Panel();
            lblRecentDate2 = new Label();
            lblRecentTitle2 = new Label();
            pnlRecentCard1 = new Panel();
            lblRecentDate1 = new Label();
            lblRecentTitle1 = new Label();
            lblRecentActivityTitle = new Label();
            pnlCustomerList = new Panel();
            dgvCustomers = new DataGridView();
            lblCustomerListTitle = new Label();
            pnlStatsRow = new TableLayoutPanel();
            pnlStat4 = new Panel();
            lblStatValue4 = new Label();
            lblStatTitle4 = new Label();
            pbStatIcon4 = new PictureBox();
            pnlStat3 = new Panel();
            lblStatValue3 = new Label();
            lblStatTitle3 = new Label();
            pbStatIcon3 = new PictureBox();
            pnlStat2 = new Panel();
            lblStatValue2 = new Label();
            lblStatTitle2 = new Label();
            pbStatIcon2 = new PictureBox();
            pnlStat1 = new Panel();
            lblStatValue1 = new Label();
            lblStatTitle1 = new Label();
            pbStatIcon1 = new PictureBox();
            pnlHeader = new Panel();
            pnlSearchBar = new Panel();
            pbSearchIcon = new PictureBox();
            txtSearch = new TextBox();
            lblWelcome = new Label();
            lblHeaderTitle = new Label();
            pnlMainLayout.SuspendLayout();
            pnlContentContainer.SuspendLayout();
            pnlListsContainer.SuspendLayout();
            pnlRecentActivity.SuspendLayout();
            pnlRecentCard3.SuspendLayout();
            pnlRecentCard2.SuspendLayout();
            pnlRecentCard1.SuspendLayout();
            pnlCustomerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            pnlStatsRow.SuspendLayout();
            pnlStat4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon4).BeginInit();
            pnlStat3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon3).BeginInit();
            pnlStat2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon2).BeginInit();
            pnlStat1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon1).BeginInit();
            pnlHeader.SuspendLayout();
            pnlSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearchIcon).BeginInit();
            SuspendLayout();
            // 
            // pnlMainLayout
            // 
            pnlMainLayout.BackColor = Color.FromArgb(240, 242, 245);
            pnlMainLayout.Controls.Add(pnlContentContainer);
            pnlMainLayout.Controls.Add(pnlHeader);
            pnlMainLayout.Dock = DockStyle.Fill;
            pnlMainLayout.Location = new Point(0, 0);
            pnlMainLayout.Name = "pnlMainLayout";
            pnlMainLayout.Size = new Size(1200, 750);
            pnlMainLayout.TabIndex = 0;
            // 
            // pnlContentContainer
            // 
            pnlContentContainer.BackColor = Color.Transparent;
            pnlContentContainer.ColumnCount = 1;
            pnlContentContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlContentContainer.Controls.Add(pnlListsContainer, 0, 1);
            pnlContentContainer.Controls.Add(pnlStatsRow, 0, 0);
            pnlContentContainer.Dock = DockStyle.Fill;
            pnlContentContainer.Location = new Point(0, 100);
            pnlContentContainer.Name = "pnlContentContainer";
            pnlContentContainer.Padding = new Padding(20, 10, 20, 20);
            pnlContentContainer.RowCount = 2;
            pnlContentContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            pnlContentContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlContentContainer.Size = new Size(1200, 650);
            pnlContentContainer.TabIndex = 2;
            // 
            // pnlListsContainer
            // 
            pnlListsContainer.ColumnCount = 2;
            pnlListsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            pnlListsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            pnlListsContainer.Controls.Add(pnlRecentActivity, 1, 0);
            pnlListsContainer.Controls.Add(pnlCustomerList, 0, 0);
            pnlListsContainer.Dock = DockStyle.Fill;
            pnlListsContainer.Location = new Point(23, 133);
            pnlListsContainer.Name = "pnlListsContainer";
            pnlListsContainer.RowCount = 1;
            pnlListsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlListsContainer.Size = new Size(1154, 494);
            pnlListsContainer.TabIndex = 1;
            // 
            // pnlRecentActivity
            // 
            pnlRecentActivity.BackColor = Color.White;
            pnlRecentActivity.Controls.Add(pnlRecentCard3);
            pnlRecentActivity.Controls.Add(pnlRecentCard2);
            pnlRecentActivity.Controls.Add(pnlRecentCard1);
            pnlRecentActivity.Controls.Add(lblRecentActivityTitle);
            pnlRecentActivity.Dock = DockStyle.Fill;
            pnlRecentActivity.Location = new Point(810, 3);
            pnlRecentActivity.Name = "pnlRecentActivity";
            pnlRecentActivity.Padding = new Padding(15);
            pnlRecentActivity.Size = new Size(341, 488);
            pnlRecentActivity.TabIndex = 1;
            // 
            // pnlRecentCard3
            // 
            pnlRecentCard3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRecentCard3.BackColor = Color.FromArgb(230, 236, 255);
            pnlRecentCard3.Controls.Add(lblRecentDate3);
            pnlRecentCard3.Controls.Add(lblRecentTitle3);
            pnlRecentCard3.Location = new Point(15, 230);
            pnlRecentCard3.Name = "pnlRecentCard3";
            pnlRecentCard3.Padding = new Padding(10);
            pnlRecentCard3.Size = new Size(311, 65);
            pnlRecentCard3.TabIndex = 3;
            // 
            // lblRecentDate3
            // 
            lblRecentDate3.AutoSize = true;
            lblRecentDate3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecentDate3.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentDate3.Location = new Point(70, 10);
            lblRecentDate3.Name = "lblRecentDate3";
            lblRecentDate3.Size = new Size(75, 20);
            lblRecentDate3.TabIndex = 1;
            lblRecentDate3.Text = "15 March";
            // 
            // lblRecentTitle3
            // 
            lblRecentTitle3.AutoSize = true;
            lblRecentTitle3.Font = new Font("Segoe UI", 9F);
            lblRecentTitle3.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentTitle3.Location = new Point(70, 35);
            lblRecentTitle3.Name = "lblRecentTitle3";
            lblRecentTitle3.Size = new Size(107, 20);
            lblRecentTitle3.TabIndex = 0;
            lblRecentTitle3.Text = "Ms. Kong Chan";
            // 
            // pnlRecentCard2
            // 
            pnlRecentCard2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRecentCard2.BackColor = Color.FromArgb(230, 236, 255);
            pnlRecentCard2.Controls.Add(lblRecentDate2);
            pnlRecentCard2.Controls.Add(lblRecentTitle2);
            pnlRecentCard2.Location = new Point(15, 155);
            pnlRecentCard2.Name = "pnlRecentCard2";
            pnlRecentCard2.Padding = new Padding(10);
            pnlRecentCard2.Size = new Size(311, 65);
            pnlRecentCard2.TabIndex = 2;
            // 
            // lblRecentDate2
            // 
            lblRecentDate2.AutoSize = true;
            lblRecentDate2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecentDate2.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentDate2.Location = new Point(70, 10);
            lblRecentDate2.Name = "lblRecentDate2";
            lblRecentDate2.Size = new Size(104, 20);
            lblRecentDate2.TabIndex = 1;
            lblRecentDate2.Text = "05-Nov-2025";
            // 
            // lblRecentTitle2
            // 
            lblRecentTitle2.AutoSize = true;
            lblRecentTitle2.Font = new Font("Segoe UI", 9F);
            lblRecentTitle2.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentTitle2.Location = new Point(70, 35);
            lblRecentTitle2.Name = "lblRecentTitle2";
            lblRecentTitle2.Size = new Size(110, 20);
            lblRecentTitle2.TabIndex = 0;
            lblRecentTitle2.Text = "Ms. Saroth Tola";
            // 
            // pnlRecentCard1
            // 
            pnlRecentCard1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRecentCard1.BackColor = Color.FromArgb(255, 238, 230);
            pnlRecentCard1.Controls.Add(lblRecentDate1);
            pnlRecentCard1.Controls.Add(lblRecentTitle1);
            pnlRecentCard1.Location = new Point(15, 80);
            pnlRecentCard1.Name = "pnlRecentCard1";
            pnlRecentCard1.Padding = new Padding(10);
            pnlRecentCard1.Size = new Size(311, 65);
            pnlRecentCard1.TabIndex = 1;
            // 
            // lblRecentDate1
            // 
            lblRecentDate1.AutoSize = true;
            lblRecentDate1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecentDate1.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentDate1.Location = new Point(70, 10);
            lblRecentDate1.Name = "lblRecentDate1";
            lblRecentDate1.Size = new Size(104, 20);
            lblRecentDate1.TabIndex = 1;
            lblRecentDate1.Text = "06-Nov-2025";
            // 
            // lblRecentTitle1
            // 
            lblRecentTitle1.AutoSize = true;
            lblRecentTitle1.Font = new Font("Segoe UI", 9F);
            lblRecentTitle1.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentTitle1.Location = new Point(70, 35);
            lblRecentTitle1.Name = "lblRecentTitle1";
            lblRecentTitle1.Size = new Size(93, 20);
            lblRecentTitle1.TabIndex = 0;
            lblRecentTitle1.Text = "Ms. Em Pisey";
            // 
            // lblRecentActivityTitle
            // 
            lblRecentActivityTitle.AutoSize = true;
            lblRecentActivityTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecentActivityTitle.ForeColor = Color.FromArgb(46, 61, 83);
            lblRecentActivityTitle.Location = new Point(15, 30);
            lblRecentActivityTitle.Name = "lblRecentActivityTitle";
            lblRecentActivityTitle.Size = new Size(161, 28);
            lblRecentActivityTitle.TabIndex = 0;
            lblRecentActivityTitle.Text = "Recent Booking";
            // 
            // pnlCustomerList
            // 
            pnlCustomerList.BackColor = Color.White;
            pnlCustomerList.Controls.Add(dgvCustomers);
            pnlCustomerList.Controls.Add(lblCustomerListTitle);
            pnlCustomerList.Dock = DockStyle.Fill;
            pnlCustomerList.Location = new Point(3, 3);
            pnlCustomerList.Name = "pnlCustomerList";
            pnlCustomerList.Padding = new Padding(15);
            pnlCustomerList.Size = new Size(801, 488);
            pnlCustomerList.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(15, 75);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(771, 398);
            dgvCustomers.TabIndex = 1;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // lblCustomerListTitle
            // 
            lblCustomerListTitle.AutoSize = true;
            lblCustomerListTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerListTitle.ForeColor = Color.FromArgb(46, 61, 83);
            lblCustomerListTitle.Location = new Point(15, 30);
            lblCustomerListTitle.Name = "lblCustomerListTitle";
            lblCustomerListTitle.Size = new Size(177, 28);
            lblCustomerListTitle.TabIndex = 0;
            lblCustomerListTitle.Text = "Active Customers";
            // 
            // pnlStatsRow
            // 
            pnlStatsRow.ColumnCount = 4;
            pnlStatsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsRow.Controls.Add(pnlStat4, 3, 0);
            pnlStatsRow.Controls.Add(pnlStat3, 2, 0);
            pnlStatsRow.Controls.Add(pnlStat2, 1, 0);
            pnlStatsRow.Controls.Add(pnlStat1, 0, 0);
            pnlStatsRow.Dock = DockStyle.Fill;
            pnlStatsRow.Location = new Point(23, 13);
            pnlStatsRow.Name = "pnlStatsRow";
            pnlStatsRow.RowCount = 1;
            pnlStatsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsRow.Size = new Size(1154, 114);
            pnlStatsRow.TabIndex = 0;
            // 
            // pnlStat4
            // 
            pnlStat4.BackColor = Color.White;
            pnlStat4.Controls.Add(lblStatValue4);
            pnlStat4.Controls.Add(lblStatTitle4);
            pnlStat4.Controls.Add(pbStatIcon4);
            pnlStat4.Dock = DockStyle.Fill;
            pnlStat4.Location = new Point(867, 3);
            pnlStat4.Name = "pnlStat4";
            pnlStat4.Padding = new Padding(15);
            pnlStat4.Size = new Size(284, 108);
            pnlStat4.TabIndex = 3;
            // 
            // lblStatValue4
            // 
            lblStatValue4.AutoSize = true;
            lblStatValue4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblStatValue4.ForeColor = Color.FromArgb(46, 61, 83);
            lblStatValue4.Location = new Point(100, 20);
            lblStatValue4.Name = "lblStatValue4";
            lblStatValue4.Size = new Size(81, 38);
            lblStatValue4.TabIndex = 2;
            lblStatValue4.Text = "$950";
            // 
            // lblStatTitle4
            // 
            lblStatTitle4.AutoSize = true;
            lblStatTitle4.Font = new Font("Segoe UI", 9F);
            lblStatTitle4.ForeColor = Color.Gray;
            lblStatTitle4.Location = new Point(100, 65);
            lblStatTitle4.Name = "lblStatTitle4";
            lblStatTitle4.Size = new Size(117, 20);
            lblStatTitle4.TabIndex = 1;
            lblStatTitle4.Text = "Avg Spend (Mo)";
            // 
            // pbStatIcon4
            // 
            pbStatIcon4.BackColor = Color.FromArgb(82, 190, 128);
            pbStatIcon4.Location = new Point(20, 20);
            pbStatIcon4.Name = "pbStatIcon4";
            pbStatIcon4.Size = new Size(60, 60);
            pbStatIcon4.TabIndex = 0;
            pbStatIcon4.TabStop = false;
            // 
            // pnlStat3
            // 
            pnlStat3.BackColor = Color.White;
            pnlStat3.Controls.Add(lblStatValue3);
            pnlStat3.Controls.Add(lblStatTitle3);
            pnlStat3.Controls.Add(pbStatIcon3);
            pnlStat3.Dock = DockStyle.Fill;
            pnlStat3.Location = new Point(579, 3);
            pnlStat3.Name = "pnlStat3";
            pnlStat3.Padding = new Padding(15);
            pnlStat3.Size = new Size(282, 108);
            pnlStat3.TabIndex = 2;
            // 
            // lblStatValue3
            // 
            lblStatValue3.AutoSize = true;
            lblStatValue3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblStatValue3.ForeColor = Color.FromArgb(46, 61, 83);
            lblStatValue3.Location = new Point(100, 20);
            lblStatValue3.Name = "lblStatValue3";
            lblStatValue3.Size = new Size(49, 38);
            lblStatValue3.TabIndex = 2;
            lblStatValue3.Text = "12";
            // 
            // lblStatTitle3
            // 
            lblStatTitle3.AutoSize = true;
            lblStatTitle3.Font = new Font("Segoe UI", 9F);
            lblStatTitle3.ForeColor = Color.Gray;
            lblStatTitle3.Location = new Point(100, 65);
            lblStatTitle3.Name = "lblStatTitle3";
            lblStatTitle3.Size = new Size(87, 20);
            lblStatTitle3.TabIndex = 1;
            lblStatTitle3.Text = "Checkouted";
            // 
            // pbStatIcon3
            // 
            pbStatIcon3.BackColor = Color.FromArgb(26, 188, 156);
            pbStatIcon3.Location = new Point(20, 20);
            pbStatIcon3.Name = "pbStatIcon3";
            pbStatIcon3.Size = new Size(60, 60);
            pbStatIcon3.TabIndex = 0;
            pbStatIcon3.TabStop = false;
            // 
            // pnlStat2
            // 
            pnlStat2.BackColor = Color.White;
            pnlStat2.Controls.Add(lblStatValue2);
            pnlStat2.Controls.Add(lblStatTitle2);
            pnlStat2.Controls.Add(pbStatIcon2);
            pnlStat2.Dock = DockStyle.Fill;
            pnlStat2.Location = new Point(291, 3);
            pnlStat2.Name = "pnlStat2";
            pnlStat2.Padding = new Padding(15);
            pnlStat2.Size = new Size(282, 108);
            pnlStat2.TabIndex = 1;
            // 
            // lblStatValue2
            // 
            lblStatValue2.AutoSize = true;
            lblStatValue2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblStatValue2.ForeColor = Color.FromArgb(46, 61, 83);
            lblStatValue2.Location = new Point(100, 20);
            lblStatValue2.Name = "lblStatValue2";
            lblStatValue2.Size = new Size(49, 38);
            lblStatValue2.TabIndex = 2;
            lblStatValue2.Text = "85";
            // 
            // lblStatTitle2
            // 
            lblStatTitle2.AutoSize = true;
            lblStatTitle2.Font = new Font("Segoe UI", 9F);
            lblStatTitle2.ForeColor = Color.Gray;
            lblStatTitle2.Location = new Point(100, 65);
            lblStatTitle2.Name = "lblStatTitle2";
            lblStatTitle2.Size = new Size(115, 20);
            lblStatTitle2.TabIndex = 1;
            lblStatTitle2.Text = "Active Bookings";
            // 
            // pbStatIcon2
            // 
            pbStatIcon2.BackColor = Color.FromArgb(230, 126, 34);
            pbStatIcon2.Location = new Point(20, 20);
            pbStatIcon2.Name = "pbStatIcon2";
            pbStatIcon2.Size = new Size(60, 60);
            pbStatIcon2.TabIndex = 0;
            pbStatIcon2.TabStop = false;
            // 
            // pnlStat1
            // 
            pnlStat1.BackColor = Color.White;
            pnlStat1.Controls.Add(lblStatValue1);
            pnlStat1.Controls.Add(lblStatTitle1);
            pnlStat1.Controls.Add(pbStatIcon1);
            pnlStat1.Dock = DockStyle.Fill;
            pnlStat1.Location = new Point(3, 3);
            pnlStat1.Name = "pnlStat1";
            pnlStat1.Padding = new Padding(15);
            pnlStat1.Size = new Size(282, 108);
            pnlStat1.TabIndex = 0;
            // 
            // lblStatValue1
            // 
            lblStatValue1.AutoSize = true;
            lblStatValue1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblStatValue1.ForeColor = Color.FromArgb(46, 61, 83);
            lblStatValue1.Location = new Point(100, 20);
            lblStatValue1.Name = "lblStatValue1";
            lblStatValue1.Size = new Size(81, 38);
            lblStatValue1.TabIndex = 2;
            lblStatValue1.Text = "1200";
            // 
            // lblStatTitle1
            // 
            lblStatTitle1.AutoSize = true;
            lblStatTitle1.Font = new Font("Segoe UI", 9F);
            lblStatTitle1.ForeColor = Color.Gray;
            lblStatTitle1.Location = new Point(100, 65);
            lblStatTitle1.Name = "lblStatTitle1";
            lblStatTitle1.Size = new Size(115, 20);
            lblStatTitle1.TabIndex = 1;
            lblStatTitle1.Text = "Total Customers";
            // 
            // pbStatIcon1
            // 
            pbStatIcon1.BackColor = Color.FromArgb(52, 152, 219);
            pbStatIcon1.Location = new Point(20, 20);
            pbStatIcon1.Name = "pbStatIcon1";
            pbStatIcon1.Size = new Size(60, 60);
            pbStatIcon1.TabIndex = 0;
            pbStatIcon1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(pnlSearchBar);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(1200, 100);
            pnlHeader.TabIndex = 1;
            // 
            // pnlSearchBar
            // 
            pnlSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlSearchBar.BackColor = Color.FromArgb(240, 242, 245);
            pnlSearchBar.Controls.Add(pbSearchIcon);
            pnlSearchBar.Controls.Add(txtSearch);
            pnlSearchBar.Location = new Point(900, 35);
            pnlSearchBar.Name = "pnlSearchBar";
            pnlSearchBar.Size = new Size(280, 40);
            pnlSearchBar.TabIndex = 2;
            // 
            // pbSearchIcon
            // 
            pbSearchIcon.Dock = DockStyle.Left;
            pbSearchIcon.Location = new Point(0, 0);
            pbSearchIcon.Name = "pbSearchIcon";
            pbSearchIcon.Size = new Size(40, 40);
            pbSearchIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pbSearchIcon.TabIndex = 1;
            pbSearchIcon.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(240, 242, 245);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(0, 0);
            txtSearch.Margin = new Padding(0, 10, 0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search customers...";
            txtSearch.Size = new Size(280, 27);
            txtSearch.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10.2F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(20, 55);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(318, 23);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Manage and view customer information.";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(46, 61, 83);
            lblHeaderTitle.Location = new Point(20, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(210, 41);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Customer List";
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMainLayout);
            Name = "Customer";
            Size = new Size(1200, 750);
            pnlMainLayout.ResumeLayout(false);
            pnlContentContainer.ResumeLayout(false);
            pnlListsContainer.ResumeLayout(false);
            pnlRecentActivity.ResumeLayout(false);
            pnlRecentActivity.PerformLayout();
            pnlRecentCard3.ResumeLayout(false);
            pnlRecentCard3.PerformLayout();
            pnlRecentCard2.ResumeLayout(false);
            pnlRecentCard2.PerformLayout();
            pnlRecentCard1.ResumeLayout(false);
            pnlRecentCard1.PerformLayout();
            pnlCustomerList.ResumeLayout(false);
            pnlCustomerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            pnlStatsRow.ResumeLayout(false);
            pnlStat4.ResumeLayout(false);
            pnlStat4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon4).EndInit();
            pnlStat3.ResumeLayout(false);
            pnlStat3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon3).EndInit();
            pnlStat2.ResumeLayout(false);
            pnlStat2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon2).EndInit();
            pnlStat1.ResumeLayout(false);
            pnlStat1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatIcon1).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearchBar.ResumeLayout(false);
            pnlSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearchIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlMainLayout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.PictureBox pbSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel pnlContentContainer;
        private System.Windows.Forms.TableLayoutPanel pnlStatsRow;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblStatTitle1;
        private System.Windows.Forms.PictureBox pbStatIcon1;
        private System.Windows.Forms.Panel pnlStat4;
        private System.Windows.Forms.Label lblStatValue4;
        private System.Windows.Forms.Label lblStatTitle4;
        private System.Windows.Forms.PictureBox pbStatIcon4;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Label lblStatValue3;
        private System.Windows.Forms.Label lblStatTitle3;
        private System.Windows.Forms.PictureBox pbStatIcon3;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Label lblStatValue2;
        private System.Windows.Forms.Label lblStatTitle2;
        private System.Windows.Forms.PictureBox pbStatIcon2;
        private System.Windows.Forms.Label lblStatValue1;
        private System.Windows.Forms.TableLayoutPanel pnlListsContainer;
        private System.Windows.Forms.Panel pnlRecentActivity;
        private System.Windows.Forms.Panel pnlCustomerList;
        private System.Windows.Forms.Label lblCustomerListTitle;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlRecentCard1;
        private System.Windows.Forms.Label lblRecentTitle1;
        private System.Windows.Forms.Label lblRecentActivityTitle;
        private System.Windows.Forms.Label lblRecentDate1;
        private System.Windows.Forms.Panel pnlRecentCard3;
        private System.Windows.Forms.Label lblRecentDate3;
        private System.Windows.Forms.Label lblRecentTitle3;
        private System.Windows.Forms.Panel pnlRecentCard2;
        private System.Windows.Forms.Label lblRecentDate2;
        private System.Windows.Forms.Label lblRecentTitle2;
    }
}