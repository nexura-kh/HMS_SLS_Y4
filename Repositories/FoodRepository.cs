using HMS_SLS_Y4.Data; 
using HMS_SLS_Y4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace HMS_SLS_Y4.Repositories
{
    public class FoodRepository
    {
        private readonly string connStr = DatabaseHelper.ConnectionString;


        public bool AddFood(Food food)
        {
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = new MySqlCommand("INSERT INTO foods (food_name, description, price) VALUES (@name, @description, @price)", conn))
            {
                cmd.Parameters.AddWithValue("@name", food.FoodName);
                cmd.Parameters.AddWithValue("@description", food.Description);
                cmd.Parameters.AddWithValue("@price", food.Price);


                try
                {
                    conn.Open();
                      cmd.ExecuteNonQuery();

                   
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Invalid data format: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message);
                }

            }

            return true;
        }


        public bool UpdateFood(Food food)
        {
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = new MySqlCommand("UPDATE foods SET food_name = @name, description = @description, price = @price WHERE food_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@name", food.FoodName);
                cmd.Parameters.AddWithValue("@description", food.Description);
                cmd.Parameters.AddWithValue("@price", food.Price);
                cmd.Parameters.AddWithValue("@id", food.FoodId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Invalid data format: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message);
                }
            }
            return true;
        }


        public bool DeleteFood(int foodId)
        {
            bool isDeleted = false;

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM foods WHERE food_id = @FoodId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodId", foodId);  // updated parameter name to match database schema

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        isDeleted = true;
                }
            }

            return isDeleted;
        }

        public List<Food> GetAllFoods()
        {
            var foods = new List<Food>();

            using (var conn = new MySqlConnection(connStr))
            using (var cmd = new MySqlCommand("SELECT * FROM foods", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foods.Add(new Food
                        {
                            FoodId = reader.GetInt32("food_id"),
                            FoodName = reader.GetString("food_name"),
                            Description = reader.GetString("description"),
                            Price = reader.GetDecimal("price"),
                            CreatedAt = reader.GetDateTime("created_at")
                        });
                    }
                }
            }

            return foods;
        }
    }
}
