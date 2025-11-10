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

        public Order(int bookingID, string room_number, string cusName)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.room_number = room_number;
            this.LoadFoods();
            this.cardFoodLayout.AutoScroll = true;

            defineTheColumns();
            this.loadOrderItems();
            roomNumber.Text = room_number;
            customerName.Text = cusName;

            orderStatus.DataSource = Enum.GetValues(typeof(Enums.FoodOrderStatus));
        }

        private void defineTheColumns()
        {
            orderedList.AutoGenerateColumns = false;

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
            orderedList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderedList.MultiSelect = false;
            orderedList.ReadOnly = true;
            orderedList.AllowUserToAddRows = false;
            orderedList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // kide the key column
            if (orderedList.Columns["OrderItemID"] != null)
            {
                orderedList.Columns["OrderItemID"].Visible = false;
            }
        }

        // Using the CreateFoodCard method from Food component
        private Panel CreateFoodCard(Models.Food food, int cardWidth, int cardHeight)
        {
            Panel card = new Panel();
            card.Width = cardWidth;
            card.Height = cardHeight;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Cursor = Cursors.Hand;
            card.Tag = food;
            card.Margin = new Padding(11);

            card.Click += (s, e) => SelectFoodForOrder(food);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(40, 40);
            pictureBox.Location = new Point((cardWidth - 40) / 2, 6);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.LightGray;
            pictureBox.Image = CreatePlaceholderImage(40, 40, food.FoodType == "Drink" ? "🥤" : "🍽️");
            pictureBox.Click += (s, e) => SelectFoodForOrder(food);

            Label nameLabel = new Label();
            nameLabel.Text = food.FoodName;
            nameLabel.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            nameLabel.Location = new Point(3, 50);
            nameLabel.Size = new Size(cardWidth - 6, 16);
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Click += (s, e) => SelectFoodForOrder(food);

            Label priceLabel = new Label();
            priceLabel.Text = "$" + food.Price.ToString("F2");
            priceLabel.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            priceLabel.ForeColor = Color.FromArgb(46, 204, 113);
            priceLabel.Location = new Point(3, 67);
            priceLabel.Size = new Size(cardWidth - 6, 16);
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            priceLabel.Click += (s, e) => SelectFoodForOrder(food);

            Label typeLabel = new Label();
            typeLabel.Text = food.FoodType ?? "Food";
            typeLabel.Font = new Font("Segoe UI", 6, FontStyle.Bold);
            typeLabel.ForeColor = Color.White;
            typeLabel.BackColor = food.FoodType == "Drink"
                ? Color.FromArgb(52, 152, 219)
                : Color.FromArgb(230, 126, 34);
            typeLabel.AutoSize = false;
            typeLabel.Size = new Size(cardWidth - 12, 14);
            typeLabel.TextAlign = ContentAlignment.MiddleCenter;
            typeLabel.Location = new Point(6, 90);
            typeLabel.Click += (s, e) => SelectFoodForOrder(food);

            card.Controls.Add(pictureBox);
            card.Controls.Add(nameLabel);
            card.Controls.Add(priceLabel);
            card.Controls.Add(typeLabel);

            return card;
        }

        private Bitmap CreatePlaceholderImage(int width, int height, string emoji)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)), 0, 0, width, height);

                Font font = new Font("Segoe UI Emoji", 28);
                SizeF textSize = g.MeasureString(emoji, font);
                float x = (width - textSize.Width) / 2;
                float y = (height - textSize.Height) / 2;
                g.DrawString(emoji, font, Brushes.Gray, x, y);
            }
            return bmp;
        }

        private void LoadFoods()
        {
            cardFoodLayout.Controls.Clear();
            cardFoodLayout.AutoScroll = true;

            var foodsList = foodRepository.GetAll();

            int cardWidth = 120;
            int cardHeight = 120;
            int margin = 100;

            int xPos = margin;
            int yPos = margin;

            int cardsPerRow = (cardFoodLayout.Width - margin) / (cardWidth + margin);
            if (cardsPerRow < 1) cardsPerRow = 1;

            int cardCount = 0;
            foreach (var food in foodsList)
            {
                Panel card = CreateFoodCard(food, cardWidth, cardHeight);
                card.Location = new Point(xPos, yPos);
                cardFoodLayout.Controls.Add(card);

                cardCount++;
                xPos += cardWidth + margin;

                if (cardCount % cardsPerRow == 0)
                {
                    xPos = margin;
                    yPos += cardHeight + margin;
                }
            }
        }

        private void SelectFoodForOrder(Models.Food food)
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

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            string foodName = orderName.Text;
            int quantity = int.Parse(orderQuantity.Text);
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

            foodOrderRepository.Add(new FoodOrder
            {
                bookingId = bookingID,
                orderDate = DateTime.Now,
                status = selectedStatus.ToString()
            });

            orderItemRepository.Add(new OrderItem
            {
                OrderId = bookingID,
                FoodId = foodId,
                Quantity = quantity,
                note = additionalNote.Text,
                totalPrice = totalPrice
            });

            this.loadOrderItems();

            txtDescription.Text = "";
            orderName.Text = "";
            orderPrice.Text = "";
            orderQuantity.Text = "";
            additionalNote.Text = "";
        }
    }
}