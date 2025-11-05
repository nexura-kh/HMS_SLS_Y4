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
        public RoomRepository roomRepository { get; set; }

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

        private void room_Load(object sender, EventArgs e)
        {
            var roomTypes = roomTypeRepository.GetAllRoomTypes();

            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.DisplayMember = "TypeName";
            cmbRoomType.ValueMember = "RoomTypeId";
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;

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

            if (cmbRoomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            RoomType selectedRoomType = (RoomType)cmbRoomType.SelectedItem;

            var newRoom = new HMS_SLS_Y4.Models.Room
            {
                roomNumber = textRoomNum.Text,
                isAvailable = true,
                roomTypeId = selectedRoomType.roomTypeId
            };

            int isTrue = roomRepository.Add(newRoom);

            if(isTrue ==1 )
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
