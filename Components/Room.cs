using Google.Protobuf.WellKnownTypes;
using HMS_SLS_Y4.Forms;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Components
{
    public partial class Room : UserControl
    {

        public RoomTypeRepository roomTypeRepository { get; }
        public RoomRepository roomRepository { get; }

        public Room(RoomTypeRepository roomType, RoomRepository roomRepo)
        {
            InitializeComponent();

            this.roomTypeRepository = roomType;
            this.roomRepository = roomRepo;

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel);


            // attach load event
            this.Load += room_Load;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void room_Load(object sender, EventArgs e)
        {
            var roomTypes = roomTypeRepository.GetAllRoomTypes();

            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.DisplayMember = "TypeName";
            cmbRoomType.ValueMember = "RoomTypeId";
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;


            // call room cards
            LoadRooms();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pricePerNight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textRoomNum_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {



        }
        public Panel CreateRoomCard(
            string roomNumber,
            string roomTypeName,
            bool isAvailable,
            string description,
            decimal pricePerNight,
            int roomTypeId,
            int roomId,
            Action refreshCardsCallback
            )
        {
            Panel card = new Panel();
            card.Size = new Size(103, 115);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(10);
            card.Cursor = Cursors.Hand;
            card.BackColor = Color.White;

            // Room icon
            PictureBox icon = new PictureBox();
            icon.Size = new Size(58, 58);
            icon.Location = new Point(30, 10);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Image = roomTypeName.ToLower() == "twin"
                ? Properties.Resources.Hotel_Image  // <-- replace with your twin icon
                : Properties.Resources.Hotel_Image; // <-- replace with your single icon

            // Room number
            Label lblNumber = new Label();
            lblNumber.Text = roomNumber;
            lblNumber.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNumber.ForeColor = isAvailable ? Color.Green : Color.Red;
            lblNumber.AutoSize = false;
            lblNumber.TextAlign = ContentAlignment.MiddleCenter;
            lblNumber.Dock = DockStyle.Bottom;

            // Room type
            Label lblType = new Label();
            lblType.Text = roomTypeName.ToUpper();
            lblType.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblType.ForeColor = isAvailable ? Color.Green : Color.Red;
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblType.Dock = DockStyle.Bottom;

            // Add controls
            card.Controls.Add(icon);
            card.Controls.Add(lblNumber);
            card.Controls.Add(lblType);

            // Click event → show modal
            card.Click += (s, e) =>
            {
               RoomDetailForm detailForm = new RoomDetailForm(
                   refreshCardsCallback,
                   roomTypeRepository,
                    roomRepository,
                    pricePerNight,
                    description,
                    roomTypeId,
                    roomId
                    );
                detailForm.ShowDialog();

            };

            return card;
        }

        public void LoadRooms()
        {
            flowlayoutRoomCard.Controls.Clear();

            // Example data (you can replace with DB data)
            var rooms =roomRepository.GetRoomList();

            foreach (var room in rooms)
            {
                Panel card = CreateRoomCard(
                    room.RoomNumber,
                    room.RoomType.TypeName,
                    room.IsAvailable,
                    room.RoomType.Description,
                    room.RoomType.Price,
                    room.RoomType.RoomTypeId,
                    room.RoomId,
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
            if (!int.TryParse(textRoomNum.Text.Trim(), out int roomNumber))
            {
                MessageBox.Show("Room number must be a valid number.");
                return;
            }
            // 2 Get selected item from ComboBox
            if (cmbRoomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            RoomType selectedRoomType = (RoomType)cmbRoomType.SelectedItem;

            int roomTypeId = selectedRoomType.RoomTypeId;
            int roomNum = int.Parse(textRoomNum.Text);

            // save to database via repository
            bool isTrue = roomRepository.InsertRoom(roomNum, true, roomTypeId);
            if (isTrue)
            {
                MessageBox.Show("Room saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textRoomNum.Text = ""; // clear input
                this.LoadRooms(); // refresh room cards
            }
            else
            {
                MessageBox.Show("Failed to save room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void flowlayoutRoomCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
