

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

namespace HMS_SLS_Y4.Forms
{
    public partial class UpdateFoodForm : Form
    {

        private FoodRepository _foodRepository;
        private Food _food;
        public UpdateFoodForm(FoodRepository foodRepository, Food food)
        {
            InitializeComponent();
            _foodRepository = foodRepository;
            _food = food;

            // pre-fill the form fields with existing food data
            txtFoodName.Text = _food.FoodName;
            txtDescription.Text = _food.Description;
            numPrice.Value = (decimal)_food.Price;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update the food object with new values
            _food.FoodName = txtFoodName.Text.Trim();
            _food.Description = txtDescription.Text.Trim();
            _food.Price = (decimal)numPrice.Value;

            // Call repository to update in DB
            bool isUpdated = _foodRepository.Update(_food);

            if (isUpdated)
            {
                MessageBox.Show("Food updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // signal the parent to refresh cards
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update food.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
