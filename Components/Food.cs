using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Forms;
using HMS_SLS_Y4.Models;

namespace HMS_SLS_Y4.Components
{
    public partial class Food : UserControl
    {
        public FoodRepository foodRepository { get; }
        private int? selectedFoodId = null;

        public Food(FoodRepository repo)
        {
            InitializeComponent();
            foodRepository = repo ?? throw new ArgumentNullException(nameof(repo));

            txtFoodType.Items.AddRange(new string[] { "Food", "Drink" });
            txtFoodType.SelectedIndex = 0;

            LoadFoodCards();
            LoadDrinkCards();
        }

        private void LoadFoodCards()
        {
            foodPanel.Controls.Clear();
            foodPanel.AutoScroll = true; // Auto-scroll is already here

            var foods = foodRepository.GetAll()
                .Where(f => f.FoodType == "Food" || string.IsNullOrEmpty(f.FoodType))
                .ToList();

            int cardWidth = 120;
            int cardHeight = 120;
            int margin = 100; // Increased margin

            int xPos = margin;
            int yPos = margin;

            // Calculate number of cards per row dynamically based on current panel width
            int cardsPerRow = (foodPanel.Width - margin) / (cardWidth + margin);
            if (cardsPerRow < 1) cardsPerRow = 1; // Ensure at least one card fits

            int cardCount = 0;
            foreach (var food in foods)
            {
                Panel card = CreateFoodCard(food, cardWidth, cardHeight);
                card.Location = new Point(xPos, yPos);
                foodPanel.Controls.Add(card);

                cardCount++;
                // Move horizontally
                xPos += cardWidth + margin;

                // Wrap to next row
                if (cardCount % cardsPerRow == 0) // Use cardCount and cardsPerRow for wrapping
                {
                    xPos = margin;
                    yPos += cardHeight + margin;
                }
            }
        }

        private void LoadDrinkCards()
        {
            drinkPanel.Controls.Clear();
            drinkPanel.AutoScroll = true; // Auto-scroll is already here

            var drinks = foodRepository.GetAll()
                .Where(f => f.FoodType == "Drink")
                .ToList();

            int cardWidth = 120;
            int cardHeight = 120;
            int margin = 100; // Increased margin

            int xPos = margin;
            int yPos = margin;

            // Calculate number of cards per row dynamically based on current panel width
            int cardsPerRow = (drinkPanel.Width - margin) / (cardWidth + margin);
            if (cardsPerRow < 1) cardsPerRow = 1; // Ensure at least one card fits

            int cardCount = 0;
            foreach (var drink in drinks)
            {
                Panel card = CreateFoodCard(drink, cardWidth, cardHeight);
                card.Location = new Point(xPos, yPos);
                drinkPanel.Controls.Add(card);

                cardCount++;
                // Move horizontally
                xPos += cardWidth + margin;

                // Wrap to next row
                if (cardCount % cardsPerRow == 0) // Use cardCount and cardsPerRow for wrapping
                {
                    xPos = margin;
                    yPos += cardHeight + margin;
                }
            }
        }

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

            card.Click += (s, e) => SelectFoodForEditing(food);

            // Image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(40, 40);
            pictureBox.Location = new Point((cardWidth - 40) / 2, 6);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.LightGray;
            pictureBox.Image = CreatePlaceholderImage(40, 40, food.FoodType == "Drink" ? "🥤" : "🍽️");
            pictureBox.Click += (s, e) => SelectFoodForEditing(food);

            // Name
            Label nameLabel = new Label();
            nameLabel.Text = food.FoodName;
            nameLabel.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            nameLabel.Location = new Point(3, 50);
            nameLabel.Size = new Size(cardWidth - 6, 16);
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Click += (s, e) => SelectFoodForEditing(food);

            // Price
            Label priceLabel = new Label();
            priceLabel.Text = "$" + food.Price.ToString("F2");
            priceLabel.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            priceLabel.ForeColor = Color.FromArgb(46, 204, 113);
            priceLabel.Location = new Point(3, 67);
            priceLabel.Size = new Size(cardWidth - 6, 16);
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            priceLabel.Click += (s, e) => SelectFoodForEditing(food);

            // Type label
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
            typeLabel.Click += (s, e) => SelectFoodForEditing(food);

            // Add controls
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

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text.Trim();
            string description = txtFoodDescription.Text.Trim();
            string foodType = txtFoodType.SelectedItem?.ToString();
            decimal price;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a food name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(foodType))
            {
                MessageBox.Show("Please select a food type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFoodPrice.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedFoodId.HasValue)
            {
                bool isUpdated = foodRepository.Update(new Models.Food
                {
                    FoodId = selectedFoodId.Value,
                    FoodName = name,
                    Description = description,
                    Price = price,
                    FoodType = foodType
                });

                if (isUpdated)
                {
                    ClearForm(); 
                    LoadFoodCards();
                    LoadDrinkCards();
                }
                else
                {
                    MessageBox.Show("Failed to update item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int isSuccess = foodRepository.Add(new Models.Food
                {
                    FoodName = name,
                    Description = description,
                    Price = price,
                    FoodType = foodType
                });

                if (isSuccess == 1)
                {
                    ClearForm();
                    LoadFoodCards();
                    LoadDrinkCards();
                }
                else
                {
                    MessageBox.Show("Failed to save item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectFoodForEditing(Models.Food food)
        {
            selectedFoodId = food.FoodId;
            txtFoodName.Text = food.FoodName;
            txtFoodDescription.Text = food.Description;
            txtFoodPrice.Text = food.Price.ToString("F2");
            txtFoodType.SelectedItem = food.FoodType ?? "Food";

            btnAddFood.Text = "Save";
            btnAddFood.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void ClearForm()
        {
            selectedFoodId = null;
            txtFoodName.Text = "";
            txtFoodDescription.Text = "";
            txtFoodPrice.Text = "";
            txtFoodType.SelectedIndex = 0;

            btnAddFood.Text = "Add";
            btnAddFood.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (selectedFoodId.HasValue)
            {
                foodRepository.Delete(selectedFoodId.Value);
                ClearForm();
                LoadFoodCards();
                LoadDrinkCards(); 
            }
            else
            {
                ClearForm();
            }
        }
    }
}
