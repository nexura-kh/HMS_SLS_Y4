using HMS_SLS_Y4.Components;
using HMS_SLS_Y4.Repositories;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Windows.Forms;

namespace HMS_SLS_Y4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadReservation(); 
        }

        #region Load Methods

        private void LoadReservation()
        {
            Reservation reservation = new Reservation();
            reservation.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(reservation);
        }

        private void LoadCustomer()
        {
            Customer customer = new Customer(this);
            customer.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(customer);
        }


        private void LoadRoom()
        {
            RoomTypeRepository roomTypeRepo = new RoomTypeRepository();
            RoomRepository roomRepo = new RoomRepository();
            Room room = new Room(roomTypeRepo, roomRepo);
            room.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(room);
        }

        public void LoadOrder(int bookingId, string roomNumber,string cusName)
        {
            Order order = new Order(bookingId, roomNumber,cusName);
            order.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(order);
        }

        private void LoadPayment()
        {
            Payment payment = new Payment();
            payment.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(payment);
        }

        private void LoadFoodTable()
        {
            FoodRepository foodRepo = new FoodRepository();
            Food foodTable = new Food(foodRepo);
            foodTable.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(foodTable);
        }
        
        private void LoadOrderList()
        {
            OrderList orderList = new OrderList(this);
            orderList.Dock = DockStyle.Fill;
            container.Controls.Clear();
            container.Controls.Add(orderList);
        }
        public void LoadReservationWithBooking(int bookingId)
        {
            container.Controls.Clear();

            Reservation reservationControl = new Reservation();

            reservationControl.Dock = DockStyle.Fill;

            container.Controls.Add(reservationControl);

            reservationControl.LoadBookingById(bookingId);
        }

        #endregion

        #region Button Click Events

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

        private void food_btn_Click(object sender, EventArgs e)
        {
            LoadFoodTable();
        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            LoadPayment();
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            LoadOrderList();
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

        #endregion
    }
}
