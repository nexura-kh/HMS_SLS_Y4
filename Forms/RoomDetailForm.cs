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
using HMS_SLS_Y4.Components;
using HMS_SLS_Y4.Models;

namespace HMS_SLS_Y4.Forms
{
    public partial class RoomDetailForm : Form
    {

        public RoomTypeRepository roomTypeRepo { get; }

        private readonly Action loadCards;
        public RoomRepository roomRepo { get; }

        private int roomTypeId;
        private int roomId;
        public RoomDetailForm(
            Action loadCards,
            RoomTypeRepository roomTypeRepository,
            RoomRepository roomRepository,
            decimal pricePerNight,
            string description,
            int roomTypeId,
            int roomId)
        {
            InitializeComponent();
            this.loadCards = loadCards;
            roomRepo = roomRepository;
            this.roomTypeRepo = roomTypeRepository;
            txtPrice.Text = pricePerNight.ToString();
            txtDescription.Text = description;

            this.roomTypeId = roomTypeId;
            this.roomId = roomId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void updateRoomType(decimal pricePerNight, string description, int typeId)
        {

            roomRepo.DeleteRoom(roomId);


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            decimal pricePerNight = decimal.Parse(txtPrice.Text);
            string description = txtDescription.Text.Trim();
            RoomType roomType = new RoomType(roomTypeId, pricePerNight, description);
            roomTypeRepo.Update(roomType);
            this.Close();
            loadCards?.Invoke();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            roomRepo.DeleteRoom(roomId);
            this.Close();
            loadCards?.Invoke();


        }
    }
}
