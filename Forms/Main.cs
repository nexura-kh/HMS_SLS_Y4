using HMS_SLS_Y4.Components;
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

namespace HMS_SLS_Y4
{
    public partial class Main : System.Windows.Forms.Form
    {
        public Main()
        {
            InitializeComponent();
            LoadReservation();
        }
        private void LoadReservation()
        {
            Reservation reservation = new Reservation();
            reservation.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(reservation);

        }
        private void LoadCustomer()
        {
            Customer customer = new Customer();
            customer.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(customer);
        }
        private void LoadRoom()
        {
            RoomTypeRepository repository = new RoomTypeRepository();
            RoomRepository roomRepository = new RoomRepository();
            Room room = new Room(repository,roomRepository);
            room.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(room);
        }

       
    
        private void LoadPayment()
        {
            Payment payment = new Payment();
            payment.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(payment);
        }
        private void customer_btn_Click(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void reservation_btn_Click(object sender, EventArgs e)
        {
            LoadReservation();
        }

        private void room_btn_Click(object sender, EventArgs e)
        {
            LoadRoom();
            
        }

        private void LoadFoodTable()
        {
            FoodRepository repo = new FoodRepository();
            Food foodTable = new Food(repo);
            foodTable.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(foodTable);
        }

        private void food_btn_Click(object sender, EventArgs e)
        {
            LoadFoodTable();

        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            LoadPayment();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
