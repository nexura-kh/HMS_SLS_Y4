using HMS_SLS_Y4.Enums;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Models.DTOs;
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
        private string cusName;
        private int bookingID;
        private string room_number;
        private int selectedOrderItemId = -1;
        private decimal selectedFoodPrice = 0;


        public Order(int bookingID, string room_number, string cusName)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.room_number = room_number;
            this.cusName = cusName;

            LoadFoods();
            cardFoodLayout.AutoScroll = true;

            loadOrderItems();
            roomNumber.Text = room_number;
            r_num.Text = room_number;
            customerName.Text = cusName;
            c_name.Text = cusName;

            orderStatus.DataSource = Enum.GetValues(typeof(Enums.FoodOrderStatus));

            orderedList.CellClick += orderedList_CellClick;
            orderQuantity.TextChanged += orderQuantity_TextChanged;
        }

        private void loadOrderItems()
        {
            DataTable table = new DataTable();
            table.Columns.Add("OrderID", typeof(int));
            table.Columns.Add("Item Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Total Price", typeof(decimal));
            table.Columns.Add("Note", typeof(string));

            var orderItemsList = orderItemRepository.GetOrderItemsByBookingId(bookingID);

            foreach (var item in orderItemsList)
            {
                table.Rows.Add(
                    item.orderItemId,
                    item.itemName,
                    item.quantity,
                    item.totalPrice,
                    item.note
                );
            }

            orderedList.DataSource = table;
            orderedList.Columns["OrderID"].Visible = false;
            orderedList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderedList.MultiSelect = false;
            orderedList.ReadOnly = true;
            orderedList.AllowUserToAddRows = false;
            orderedList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private Panel CreateFoodCard(Models.Food food, int cardWidth, int cardHeight)
        {
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = food,
                Margin = new Padding(11)
            };

            card.Click += (s, e) => SelectFoodForOrder(food);

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point((cardWidth - 40) / 2, 6),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray,
                Image = CreatePlaceholderImage(65, 65, food.FoodType == "Drink" ? "🥤" : "🥗")
            };
            pictureBox.Click += (s, e) => SelectFoodForOrder(food);

            Label nameLabel = new Label
            {
                Text = food.FoodName,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Location = new Point(3, 50),
                Size = new Size(cardWidth - 6, 16),
                TextAlign = ContentAlignment.MiddleCenter
            };
            nameLabel.Click += (s, e) => SelectFoodForOrder(food);

            Label priceLabel = new Label
            {
                Text = "$" + food.Price.ToString("F2"),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(3, 67),
                Size = new Size(cardWidth - 6, 16),
                TextAlign = ContentAlignment.MiddleCenter
            };
            priceLabel.Click += (s, e) => SelectFoodForOrder(food);

            Label typeLabel = new Label
            {
                Text = food.FoodType ?? "Food",
                Font = new Font("Segoe UI", 6, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = food.FoodType == "Drink"
                    ? Color.FromArgb(52, 152, 219)
                    : Color.FromArgb(230, 126, 34),
                AutoSize = false,
                Size = new Size(cardWidth - 12, 14),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(6, 90)
            };
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
            selectedFoodPrice = food.Price;
        }

        private void orderedList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < orderedList.Rows.Count)
            {
                DataGridViewRow row = orderedList.Rows[e.RowIndex];

                if (row.Cells["OrderID"].Value != null)
                {
                    int orderItemId = Convert.ToInt32(row.Cells["OrderID"].Value);
                    var orderItem = orderItemRepository.GetOrderItemById(orderItemId);

                    if (orderItem != null)
                    {
                        selectedOrderItemId = orderItem.orderItemId;
                        orderName.Text = orderItem.itemName;
                        orderQuantity.Text = orderItem.quantity.ToString();
                        txtDescription.Text = orderItem.description ?? string.Empty;
                        orderPrice.Text = orderItem.totalPrice.ToString("N2");
                        additionalNote.Text = orderItem.note ?? string.Empty;

                        if (Enum.IsDefined(typeof(FoodOrderStatus), orderItem.status))
                        {
                            orderStatus.SelectedItem = orderItem.status;
                            selectedStatus = orderItem.status;
                        }

                        addOrderBtn.Text = "Cancel";
                    }
                    else
                    {
                        MessageBox.Show("Order item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void orderQuantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(orderQuantity.Text, out decimal quantity) && quantity > 0)
            {
                decimal totalPrice = selectedFoodPrice * quantity;
                orderPrice.Text = totalPrice.ToString("C2");
            }
            else
            {
                orderPrice.Text = selectedFoodPrice.ToString("C2");
            }
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            if (addOrderBtn.Text == "Cancel")
            {
                orderedList.ClearSelection();
                selectedOrderItemId = -1;

                txtDescription.Clear();
                orderName.Clear();
                orderPrice.Clear();
                orderQuantity.Value = orderQuantity.Minimum;
                additionalNote.Clear();

                addOrderBtn.Text = "Add";
                return;
            }

            if (orderStatus.SelectedItem != null)
                selectedStatus = (Enums.FoodOrderStatus)orderStatus.SelectedItem;

            if (!int.TryParse(orderQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            decimal price = decimal.Parse(orderPrice.Text.Replace("$", ""));
            decimal totalPrice = price;

            int orderId = foodOrderRepository.Add(new FoodOrder
            {
                bookingId = bookingID,
                orderDate = DateTime.Now,
                status = selectedStatus.ToString()
            });

            orderItemRepository.Add(new OrderItem
            {
                OrderId = orderId,
                FoodId = foodId,
                Quantity = quantity,
                note = additionalNote.Text,
                totalPrice = totalPrice
            });

            loadOrderItems();

            txtDescription.Clear();
            orderName.Clear();
            orderPrice.Clear();
            orderQuantity.Value = orderQuantity.Minimum;
            additionalNote.Clear();

            addOrderBtn.Text = "Add";
        }

        private void deleteOrderBtn_Click(object sender, EventArgs e)
        {
            if (selectedOrderItemId == -1)
            {
                MessageBox.Show("Please select an order to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this order item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                orderItemRepository.Delete(selectedOrderItemId);

                selectedOrderItemId = -1;
                loadOrderItems();

                txtDescription.Clear();
                orderName.Clear();
                orderPrice.Clear();
                orderQuantity.Value = orderQuantity.Minimum;
                additionalNote.Clear();

                addOrderBtn.Text = "Add";
            }
        }

        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            if (selectedOrderItemId == -1)
            {
                MessageBox.Show("Please select an order to edit.");
                return;
            }

            if (!int.TryParse(orderQuantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            decimal price = decimal.Parse(orderPrice.Text.Replace("$", ""));
            decimal totalPrice = price * quantity;

            var updatedItem = new OrderItem
            {
                OrderItemId = selectedOrderItemId,
                FoodId = foodId,
                Quantity = quantity,
                note = additionalNote.Text,
                totalPrice = totalPrice
            };

            orderItemRepository.Update(updatedItem);

            MessageBox.Show("Order item updated successfully!");
            loadOrderItems();

            addOrderBtn.Text = "Add";
        }
    }
}
