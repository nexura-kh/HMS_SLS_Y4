using HMS_SLS_Y4.Forms;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace HMS_SLS_Y4.Components
{
    public partial class Room : UserControl
    {
        public RoomTypeRepository roomTypeRepository { get; }
        public RoomRepository roomRepository { get; set; }

        private Models.Room selectedRoom;

        int roomTypeId;

        public Room(RoomTypeRepository roomType, RoomRepository roomRepo)
        {
            InitializeComponent();

            this.roomTypeRepository = roomType ?? throw new ArgumentNullException(nameof(roomType));
            this.roomRepository = roomRepo ?? throw new ArgumentNullException(nameof(roomRepo));

            if (flowlayoutRoomCard != null)
            {
                flowlayoutRoomCard.AutoScroll = true;
                flowlayoutRoomCard.WrapContents = true;
                flowlayoutRoomCard.FlowDirection = FlowDirection.LeftToRight;
            }

            this.Load += room_Load;
            LoadRoomTypes();
            btnSave.Click += btnSave_Click;
        }

        private void room_Load(object sender, EventArgs e)
        {
            var roomTypes = roomTypeRepository.GetAllRoomTypes() ?? new System.Collections.Generic.List<RoomType>();

            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.DisplayMember = "typeName";
            cmbRoomType.ValueMember = "roomTypeId";
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadRooms();
        }

        private Panel CreateRoomCard(Models.Room room)
        {
            var roomType = room.RoomType ?? room.roomType;
            string roomTypeName = roomType?.typeName ?? "Unknown";
            string description = roomType?.description ?? string.Empty;
            decimal pricePerNight = roomType?.price ?? 0m;

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string iconPath = GetRoomIconPath(roomTypeName, room.isAvailable, projectPath);

            Panel card = new Panel
            {
                Width = 103,
                Height = 115,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = room
            };

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(230, 240, 255);
            card.MouseLeave += (s, e) =>
            {
                if (selectedRoom != null && selectedRoom.roomId == room.roomId)
                {
                    card.BackColor = Color.FromArgb(200, 220, 255);
                }
                else
                {
                    card.BackColor = Color.White;
                }
            };

            PictureBox roomIcon = new PictureBox
            {
                Width = 58,
                Height = 58,
                Location = new Point(20, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = room
            };

            if (File.Exists(iconPath))
            {
                roomIcon.Image = Image.FromFile(iconPath);
            }
            else
            {
                roomIcon.BackColor = room.isAvailable ? Color.LightGreen : Color.LightCoral;
            }

            Label roomNumberLabel = new Label
            {
                Text = room.roomNumber,
                Location = new Point(5, 65),
                Width = 90,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = room
            };

            Label roomTypeLabel = new Label
            {
                Text = roomTypeName.ToUpper(),
                Location = new Point(5, 85),
                Width = 90,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7),
                ForeColor = room.isAvailable ? Color.Green : Color.Red,
                Tag = room
            };

            Label statusLabel = new Label
            {
                Text = room.isAvailable ? "Available" : "Occupied",
                Location = new Point(5, 100),
                Width = 90,
                Height = 15,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 6),
                ForeColor = Color.Gray,
                Tag = room
            };

            void SelectRoom()
            {
                selectedRoom = room;
                PopulateRoomForm(room);

                foreach (Control ctrl in flowlayoutRoomCard.Controls)
                {
                    if (ctrl is Panel panel)
                    {
                        var panelRoom = panel.Tag as Models.Room;
                        if (panelRoom != null && panelRoom.roomId == room.roomId)
                        {
                            panel.BackColor = Color.FromArgb(200, 220, 255);
                        }
                        else
                        {
                            panel.BackColor = Color.White;
                        }
                    }
                }
            }

            card.Click += (s, e) => SelectRoom();
            roomIcon.Click += (s, e) => SelectRoom();
            roomNumberLabel.Click += (s, e) => SelectRoom();
            roomTypeLabel.Click += (s, e) => SelectRoom();
            statusLabel.Click += (s, e) => SelectRoom();

            card.Controls.Add(roomIcon);
            card.Controls.Add(roomNumberLabel);
            card.Controls.Add(roomTypeLabel);
            card.Controls.Add(statusLabel);

            return card;
        }

        private void PopulateRoomForm(Models.Room room)
        {
            var roomType = room.RoomType ?? room.roomType;

            textRoomNum.Text = room.roomNumber;
            txtAvialable.Text = room.isAvailable ? "Available" : "Accupied";
            txtAvialable.Enabled = false;

            if (cmbRoomType != null && roomType != null)
            {
                for (int i = 0; i < cmbRoomType.Items.Count; i++)
                {
                    var item = cmbRoomType.Items[i] as RoomType;
                    if (item != null && item.roomTypeId == roomType.roomTypeId)
                    {
                        cmbRoomType.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (btnSave != null)
            {
                btnSave.Text = "Update";
            }
        }

        private string GetRoomIconPath(string roomType, bool isAvailable, string projectPath)
        {
            string iconFileName = "";

            if (roomType.ToLower() == "single fan" || roomType.ToLower() == "single ac")
            {
                iconFileName = isAvailable ? "single_bed_available.png" : "single_bed_unavailble.png";
            }
            else if (roomType.ToLower() == "twins fan" || roomType.ToLower() == "twins ac")
            {
                iconFileName = isAvailable ? "twin_bed_available.png" : "twin_bed_unavailable.png";
            }

            return Path.Combine(projectPath, "Resources", "icon", iconFileName);
        }

        public void LoadRooms()
        {
            flowlayoutRoomCard.Controls.Clear();

            var rooms = roomRepository.GetRoomList() ?? new System.Collections.Generic.List<Models.Room>();

            foreach (var r in rooms)
            {
                Panel card = CreateRoomCard(r);
                flowlayoutRoomCard.Controls.Add(card);
            }

            selectedRoom = null;
            if (btnSave != null)
            {
                btnSave.Text = "Create";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textRoomNum.Text))
            {
                MessageBox.Show("Please enter a valid room number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            if (selectedRoom != null && btnSave.Text == "Update")
            {
                selectedRoom.roomNumber = textRoomNum.Text.Trim();
                selectedRoom.roomTypeId = selectedRoomType.roomTypeId;

                var rows = roomRepository.Update(selectedRoom);

                if (rows)
                {
                    MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textRoomNum.Text = string.Empty;
                    selectedRoom = null;
                    btnSave.Text = "Create";
                    LoadRooms();
                }
                else
                {
                    MessageBox.Show("Failed to update room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
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
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            if (selectedRoom != null)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    isDeleted = roomRepository.Delete(selectedRoom.roomId);

                    if (isDeleted)
                    {
                        MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textRoomNum.Text = string.Empty;
                        selectedRoom = null;
                        btnSave.Text = "Create";
                        LoadRooms();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadRoomTypes()
        {
            DataTable table = new DataTable();
            table.Columns.Add("RoomID", typeof(int));
            table.Columns.Add("Room Type");
            table.Columns.Add("Price Per Night");
            table.Columns.Add("Description");

            var roomTypes = roomTypeRepository.GetAllRoomTypes();
            foreach (var roomType in roomTypes)
            {
                table.Rows.Add(
                    roomType.roomTypeId,
                    roomType.typeName,
                    roomType.price.ToString("C"),
                    roomType.description
                );
            }
            dvgRoomTypes.DataSource = table;
            dvgRoomTypes.Columns["RoomID"].Visible = false;
            dvgRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgRoomTypes.MultiSelect = false;
            dvgRoomTypes.ReadOnly = true;
            dvgRoomTypes.AllowUserToAddRows = false;
            dvgRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dvgRoomTypes.CellClick += dvgRoomTypes_CellClick;

        }

        private void dvgRoomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                roomTypeId = Convert.ToInt32(dvgRoomTypes.Rows[e.RowIndex].Cells["RoomID"].Value);
                this.populateRoomTypeForm(roomTypeId);

                btnCreate.Text = "Edit";
            }


        }

        private void populateRoomTypeForm(int roomTypeId)
        {

            var roomType = roomTypeRepository.GetRoomTypeById(roomTypeId);
            if (roomType != null)
            {
                txtTypeName.Text = roomType.typeName;
                txtPrice.Text = roomType.price.ToString();
                txtDescription.Text = roomType.description;
            }
        }

        private void addRoomType()
        {
            var newRoomType = new RoomType
            {
                typeName = txtTypeName.Text,
                price = decimal.Parse(txtPrice.Text),
                description = txtDescription.Text
            };
            int rows = roomTypeRepository.Add(newRoomType);
            if (rows > 0)
            {
                MessageBox.Show("Room type added successfully");
            }
        }

        private bool updateRoomType(int roomTypeId)
        {
            var roomType = roomTypeRepository.GetRoomTypeById(roomTypeId);

            bool isUpdated = false;
            if (roomType != null)
            {
                roomType.roomTypeId = roomTypeId;
                roomType.typeName = txtTypeName.Text;
                roomType.price = decimal.Parse(txtPrice.Text);
                roomType.description = txtDescription.Text;
                roomTypeRepository.Update(roomType);

                txtTypeName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDescription.Text = string.Empty;

                btnCreate.Text = "Create";

                LoadRoomTypes();
            }
            return isUpdated;
        }

        private void deleteRow(int roomTypeId)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this room type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                bool rowsAffected = roomTypeRepository.Delete(roomTypeId);
                if (rowsAffected)
                {
                    MessageBox.Show("Room type deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomTypes();
                }
                else
                {
                    MessageBox.Show("Failed to delete room type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {


            if (btnCreate.Text == "Create")
            {

                this.addRoomType();
            }
            else if (btnCreate.Text == "Edit")
            {
                bool isUpdated = this.updateRoomType(roomTypeId);
                btnCreate.Text = "Create";
            }
            // clear text boxes
            txtTypeName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;
            // reload room types
            LoadRoomTypes();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.deleteRow(Convert.ToInt32(dvgRoomTypes.SelectedRows[0].Cells["RoomID"].Value));

            // clear text boxes
            txtTypeName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;

            // change button text back to create
            btnCreate.Text = "Create";
        }

    }
}