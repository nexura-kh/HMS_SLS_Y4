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
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
            this.cardFoodLayout.AutoScroll = true;
            LoadMockupData();
        }
        private void LoadMockupData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("No.");
            table.Columns.Add("Item");
            table.Columns.Add("Quantity");
            table.Columns.Add("Description");
            table.Columns.Add("Price ($)");
            table.Columns.Add("Status");
            table.Columns.Add("Note");

            // Add mock rows
            table.Rows.Add(1, "Beef Steak", 1, "More Spicy", 10, "Ordered", "Before 3PM");
            table.Rows.Add(2, "Chicken Wings", 2, "Extra Crispy", 8, "Preparing", "Serve hot");
            table.Rows.Add(6, "Fruit Smoothie", 2, "Mixed Berries", 4.5, "Delivered", "Cold drink");

            orderedList.DataSource = table;
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


        private void cardFoodLayout_Paint(object sender, PaintEventArgs e)
        {

            // Get project path for icons
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string imgPath = Path.Combine(projectPath, "Resources", "icon", "fast-food.png");



            var foods = new List<(string Name, string ImagePath)>
            {
                ("Pizza", "food.png"),
                ("Burger", "food.png"),
                ("Sushi", "food.png"),
                ("Noodles", "food.png"),
                ("Fried Rice", "friedrice.png")
            };

            foreach (var food in foods)
            {
                Image foodImg = Image.FromFile(imgPath);
                Panel foodCard = CreateFoodCard(food.Name, foodImg, 9.99m);
                cardFoodLayout.Controls.Add(foodCard);
            }

        }
    }
}
