using HMS_SLS_Y4.Forms;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Room : UserControl
    {
        public RoomTypeRepository roomTypeRepository { get; }
        public RoomRepository roomRepository { get; set; }

        public Room(RoomTypeRepository roomType, RoomRepository roomRepo)
        {
            InitializeComponent();

            this.roomTypeRepository = roomType ?? throw new ArgumentNullException(nameof(roomType));
            this.roomRepository = roomRepo ?? throw new ArgumentNullException(nameof(roomRepo));

            // ensure the left panel uses the designer flowlayoutRoomCard (designer already adds it)
            // but keep compatibility: if designer didn't add it, create and add one
            if (flowlayoutRoomCard == null)
            {
                var flow = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel1.Controls.Add(flow);
            }

            // wire events
            this.Load += room_Load;
            btnSave.Click += btnSave_Click;
        }

        private void room_Load(object sender, EventArgs e)
        {
            var roomTypes = roomTypeRepository.GetAllRoomTypes() ?? new System.Collections.Generic.List<RoomType>();

            // DisplayMember / ValueMember must match property names in RoomType (case-sensitive for DataBinding)
            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.DisplayMember = "typeName";
            cmbRoomType.ValueMember = "roomTypeId";
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadRooms();
        }

        private Panel CreateRoomCard(
            string roomNumber,
            string roomTypeName,
            bool isAvailable,
            string description,
            decimal pricePerNight,
            int roomTypeId,
            int roomId,
            Action refreshCardsCallback)
        {
            Panel card = new Panel
            {
                Width = 120,
                Height = 120,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = new { RoomId = roomId, RoomNumber = roomNumber, RoomTypeId = roomTypeId }
            };

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(240, 248, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            // Room number label
            Label lblNumber = new Label
            {
                Text = roomNumber,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 32
            };

            // Type / price label
            Label lblType = new Label
            {
                Text = $"{roomTypeName} - ${pricePerNight:F2}",
                Font = new Font("Segoe UI", 8),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 28,
                ForeColor = isAvailable ? Color.Green : Color.Red
            };

            // Description (small)
            Label lblDesc = new Label
            {
                Text = description ?? string.Empty,
                Font = new Font("Segoe UI", 7),
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(4)
            };

            // click -> open detail
            void OpenDetail()
            {
                try
                {
                    // try to open RoomDetailForm with the same parameters used previously
                    var detailForm = new RoomDetailForm(
                        refreshCardsCallback,
                        roomTypeRepository,
                        roomRepository,
                        pricePerNight,
                        description,
                        roomTypeId,
                        roomId
                    );
                    detailForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to open room detail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            card.Click += (s, e) => OpenDetail();
            lblNumber.Click += (s, e) => OpenDetail();
            lblType.Click += (s, e) => OpenDetail();
            lblDesc.Click += (s, e) => OpenDetail();

            card.Controls.Add(lblDesc);
            card.Controls.Add(lblType);
            card.Controls.Add(lblNumber);

            return card;
        }

        public void LoadRooms()
        {
            flowlayoutRoomCard.Controls.Clear();

            var rooms = roomRepository.GetRoomList() ?? new System.Collections.Generic.List<Models.Room>();

            foreach (var r in rooms)
            {
                // defensive: some repository implementations use different property names / null RoomType
                var rt = r.RoomType ?? r.roomType;
                string typeName = rt?.typeName ?? rt?.typeName ?? "Unknown";
                string desc = rt?.description ?? rt?.description ?? string.Empty;
                decimal price = 0m;
                try { price = rt?.price ?? 0m; } catch { price = 0m; }

                Panel card = CreateRoomCard(
                    r.roomNumber,
                    typeName,
                    r.isAvailable,
                    desc,
                    price,
                    rt?.roomTypeId ?? rt?.roomTypeId ?? 0,
                    r.roomId,
                    LoadRooms);

                flowlayoutRoomCard.Controls.Add(card);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textRoomNum.Text))
            {
                MessageBox.Show("Please enter a valid room number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // optional numeric validation kept but room numbers may be non-numeric; keep parse but not required:
            // if numeric is required:
            if (!int.TryParse(textRoomNum.Text.Trim(), out _))
            {
                MessageBox.Show("Room number must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbRoomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RoomType selectedRoomType = (RoomType)cmbRoomType.SelectedItem;

            var newRoom = new Models.Room
            {
                roomNumber = textRoomNum.Text.Trim(),
                isAvailable = true,
                roomTypeId = selectedRoomType.roomTypeId
            };

            int rows = roomRepository.Add(newRoom);

            if (rows > 0)
            {
                MessageBox.Show("Room saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textRoomNum.Text = string.Empty;
                LoadRooms();
            }
            else
            {
                MessageBox.Show("Failed to save room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}