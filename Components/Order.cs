using HMS_SLS_Y4.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Models.DTOs;

namespace HMS_SLS_Y4.Components
{
    public partial class Order : UserControl
    {


        private FoodOrderRepository foodOrderRepository = new FoodOrderRepository();
        private FoodRepository foodRepository = new FoodRepository();

        private OrderItemRepository orderItemRepository = new OrderItemRepository();

        private RoomRepository roomRepository = new RoomRepository();
        private UserRepository userRepository = new UserRepository();

        private Enums.FoodOrderStatus selectedStatus;

        private int foodId;

        

        private String cusName;

        private int bookingID;
        
        private string room_number;
        public Order(int bookingID, string room_number,string cusName)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.room_number = room_number;
            this.LoadFoods();
            this.cardFoodLayout.AutoScroll = true;


            defineTheColumns();
            this.loadOrderItems();
            // assign customer name and room number to form 
            roomNumber.Text = room_number;
           customerName.Text = cusName;

          

            orderStatus.DataSource = Enum.GetValues(typeof(Enums.FoodOrderStatus));
        }
        private void defineTheColumns()
        {
            orderedList.AutoGenerateColumns = false;  // we'll define custom columns
            

            // Define columns manually
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "No", Name = "No" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Item", DataPropertyName = "ItemName" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantity", DataPropertyName = "Quantity" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = "Description" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "TotalPrice" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            orderedList.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Note", DataPropertyName = "Note" });


        }


        private void loadOrderItems()
        {
            var orderItemsList = orderItemRepository.GetOrderItemsByBookingId(bookingID);
            orderedList.DataSource = orderItemsList;

        }
        private void orderStatus_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderTitle_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        // food card in customer section
        public Panel CreateFoodCard(string foodName, Image foodImage, decimal foodPrice)
        {
            // Main card panel
            Panel panel = new Panel();
            panel.Size = new Size(130, 130);
            panel.BackColor = Color.AliceBlue;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            panel.Cursor = Cursors.Hand; // show hand cursor when hovering

            // PictureBox for food image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = foodImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(80, 70);
            pictureBox.Location = new Point((panel.Width - pictureBox.Width) / 2, 10);

            Label lblPrice = new Label();
            lblPrice.Text = $"${foodPrice:F2}";
            lblPrice.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblPrice.ForeColor = Color.Blue;
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point((panel.Width - lblPrice.PreferredWidth) / 2, 85);

            // Label for food name
            Label lblFoodName = new Label();
            lblFoodName.Text = foodName;
            lblFoodName.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblFoodName.ForeColor = Color.Black;
            lblFoodName.AutoSize = true;
            lblFoodName.Location = new Point((panel.Width - lblFoodName.PreferredWidth) / 2, 105);
            // Add controls to panel
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(lblFoodName);

            // Optional hover effect
            panel.MouseEnter += (s, e) => panel.BackColor = Color.LightYellow;
            panel.MouseLeave += (s, e) => panel.BackColor = Color.AliceBlue;

            // Click event (optional)
            panel.Click += (s, e) =>
            {
                MessageBox.Show($"You selected {foodName}");
            };

            return panel;
        }

        private void LoadFoods()
        {
            // Get project path for icons
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string imgPath = Path.Combine(projectPath, "Resources", "icon", "fast-food.png");

            var foodsList = foodRepository.GetAll();
            Image foodImg = Image.FromFile(imgPath);

            // Clear old cards
            cardFoodLayout.Controls.Clear();
            cardFoodLayout.Padding = new Padding(10);


            int x = 10; // start position
            int y = 10;
            int margin = 10;
            // If you use FlowLayoutPanel, layout is automatic
            foreach (var food in foodsList)
            {
                Panel foodCard = CreateFoodCard(food.FoodName, foodImg, food.Price);
                foodCard.Location = new Point(x, y);
                foodCard.Tag = food; // Store food data in Tag property
                foodCard.Click += foodCard_Click;
                foreach (Control ctrl in foodCard.Controls)
                {
                    ctrl.Click += (s, e) => foodCard_Click(foodCard, e);
                }

                cardFoodLayout.Controls.Add(foodCard);


                // Move position for next card
                x += foodCard.Width + margin;

                // Wrap to new row if too wide
                if (x + foodCard.Width > cardFoodLayout.Width)
                {
                    x = 10;
                    y += foodCard.Height + margin;
                }
            }
        }


        private void foodCard_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is Models.Food food)
            {
                foodId = food.FoodId;
                txtDescription.Text = food.Description;
                orderName.Text = food.FoodName;
                orderPrice.Text = food.Price.ToString("C2");
               

                if (int.TryParse(orderQuantity.Text, out int quantity))
                {
                    decimal total = food.Price * quantity;
                    
                }

            }
        }
        private void cardFoodLayout_Paint(object sender, PaintEventArgs e)
        {
        }

        private void orderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            string foodName= orderName.Text;
            int quantity =int.Parse( orderQuantity.Text);
            string description = txtDescription.Text;
            decimal totalPrice;
            string status = selectedStatus.ToString();

            if (orderStatus.SelectedItem != null)
            {
                selectedStatus = (Enums.FoodOrderStatus)orderStatus.SelectedItem;
                

            }
            totalPrice = decimal.Parse(orderPrice.Text.Replace("$", "")) * quantity;
            
           


            for (int i = 0; i < orderedList.Rows.Count; i++)
            {
                orderedList.Rows[i].Cells["No"].Value = i + 1;
            }

            // add to foodOrder repo

            foodOrderRepository.Add(new FoodOrder
            {
                bookingId = bookingID,
                orderDate = DateTime.Now,
                status = selectedStatus.ToString()
            });

            // add to order item repo
            orderItemRepository.Add(new OrderItem
            {
                OrderId = bookingID,
                FoodId = foodId,
                Quantity = quantity,
                note = additionalNote.Text,
                totalPrice = totalPrice
            });

            this.loadOrderItems();

            // empty the text box after save to db
            txtDescription.Text = "";
            orderName.Text = "";
            orderPrice.Text = "";
            orderQuantity.Text = "";
            additionalNote.Text = "";
        }


        // handle when clikc certain row in dataGridView and delete that row 

        
    }
}
