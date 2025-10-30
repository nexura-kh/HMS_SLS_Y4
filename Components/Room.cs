using Google.Protobuf.WellKnownTypes;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textRoomNum.Text))
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
            int roomNum= int.Parse(textRoomNum.Text);

            // save to database via repository
           bool isTrue= roomRepository.InsertRoom(roomNum,true, roomTypeId);
            if(isTrue)
            {
                MessageBox.Show("Room saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
