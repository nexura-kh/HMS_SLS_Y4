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

namespace HMS_SLS_Y4.Components
{
    public partial class Food : UserControl
    {


        public FoodRepository foodRepository { get; }


        public Food(FoodRepository repo)
        {
            InitializeComponent();
            foodRepository = repo ?? throw new ArgumentNullException(nameof(repo));
            LoadDummyCards();

           

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        // cards
        private void LoadDummyCards()
        {

            splitContainer1.Panel1.Controls.Clear(); // Clear previous cards



            // Dummy data
            var foods = foodRepository.GetAllFoods();

            int cardWidth = 250;
            int cardHeight = 120;
            int margin = 10;
            int yPos = 0;

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();  
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel);

            foreach (var food in foods)
            {
                Panel card = new Panel();
                card.Width = cardWidth;
                card.Height = cardHeight;
                card.BackColor = Color.LightGray;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10); // spacing between cards

                // Name label
                Label nameLabel = new Label();
                nameLabel.Text = food.FoodName;
                nameLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                nameLabel.Location = new Point(10, 10);
                nameLabel.AutoSize = true;

                // Description label
                Label descLabel = new Label();
                descLabel.Text = food.Description;
                descLabel.Location = new Point(10, 40);
                descLabel.Size = new Size(card.Width - 20, 40);

                // Price label
                Label priceLabel = new Label();
                priceLabel.Text = "Price: $" + food.Price.ToString("F2");
                priceLabel.Location = new Point(10, 85);
                priceLabel.AutoSize = true;

                // Delete button
                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.BackColor = Color.Red;
                deleteButton.ForeColor = Color.White;
                deleteButton.Size = new Size(70, 30);
                deleteButton.Tag = food.FoodId; 
                deleteButton.Click += (s, e) =>
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool isDeleted = foodRepository.DeleteFood(food.FoodId);
                        if (isDeleted)
                        {
                            MessageBox.Show("Food item deleted successfully!");
                            LoadDummyCards(); // Refresh the food cards
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete food item.");
                        }
                    }
                };
                deleteButton.Location = new Point(card.Width - 160, 80);

                // Update button
                Button updateButton = new Button();
                updateButton.Text = "Update";
                updateButton.BackColor = Color.Green;
                updateButton.ForeColor = Color.White;
                updateButton.Size = new Size(70, 30);
                updateButton.Location = new Point(card.Width - 90, 80);
                updateButton.Click += (s, e) =>
                {
                    // Open update dialog
                    using (UpdateFoodForm updateForm = new UpdateFoodForm(foodRepository, food))
                    {
                        if (updateForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDummyCards(); // Refresh the food cards
                        }
                    }
                };
                deleteButton.Location = new Point(card.Width - 160, 80);


                // Add controls to card
                card.Controls.Add(updateButton);
                card.Controls.Add(deleteButton);
                card.Controls.Add(nameLabel);
                card.Controls.Add(descLabel);
                card.Controls.Add(priceLabel);

                // Add the card to the FlowLayoutPanel
                flowLayoutPanel.Controls.Add(card);
            }
        }




        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fname_Click(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            String name = namefood.Text.Trim();
            String description = des.Text.Trim();
            decimal price;


            if (!decimal.TryParse(foodPrice.Text.Trim(), out price))
            {
                MessageBox.Show("Please enter a valid number for price.");
                return;
            }


            bool isSuccess = foodRepository.AddFood(new Models.Food
            {
                FoodName = name,
                Description = description,
                Price = price
            });

            if (isSuccess)
            {
                MessageBox.Show("Food item saved successfully!");
                // Optionally, clear the input fields
                namefood.Text = "";
                des.Text = "";
                foodPrice.Text = "";
                LoadDummyCards(); // Refresh the food cards
            }
            else
            {
                MessageBox.Show("Failed to save food item.");
            }



        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }
    }
}
