using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Repositories;
using HMS_SLS_Y4.Models;

namespace HMS_SLS_Y4.Seeders
{
    public class SeedFood
    {   
        private readonly FoodRepository foodRepo = new FoodRepository();
        private readonly string connStr = DatabaseHelper.ConnectionString;
        public void SeedFoods()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SET FOREIGN_KEY_CHECKS = 0;
                    TRUNCATE TABLE order_items;
                    TRUNCATE TABLE foods;
                    SET FOREIGN_KEY_CHECKS = 1;
                ";
                cmd.ExecuteNonQuery();  
            }
            var Food = new List<Food>
            {
                new Food { FoodName = "Burger", FoodType = "Food", Description = "Delicious beef burger with cheese and lettuce", Price = 5.99m },
                new Food { FoodName = "Pizza", FoodType = "Food", Description = "Large pepperoni pizza with extra cheese", Price = 8.99m },
                new Food { FoodName = "Caesar Salad", FoodType = "Food", Description = "Fresh romaine lettuce with Caesar dressing and croutons", Price = 4.99m },
                new Food { FoodName = "Spaghetti Bolognese", FoodType = "Food", Description = "Classic Italian pasta with rich meat sauce", Price = 7.99m },
                new Food { FoodName = "Grilled Chicken Sandwich", FoodType = "Food", Description = "Grilled chicken breast with mayo and pickles on a bun", Price = 6.49m },
                new Food { FoodName = "Grilled Salmon", FoodType = "Food", Description = "Fresh salmon fillet grilled with herbs and lemon", Price = 11.99m },
                new Food { FoodName = "Steak", FoodType = "Food", Description = "Juicy grilled steak cooked to perfection", Price = 12.99m },
                new Food { FoodName = "French Fries", FoodType = "Food", Description = "Crispy golden fries with ketchup", Price = 2.99m },
                new Food { FoodName = "Rice", FoodType = "Food", Description = "Deliscious Cambodia Rice", Price = 0.25m},
                new Food { FoodName = "Coca Cola", FoodType = "Drink", Description = "Big bottle of Coca Cola", Price = 1.49m },
                new Food { FoodName = "Lemonade", FoodType = "Drink", Description = "Refreshing homemade lemonade", Price = 1.99m },
                new Food { FoodName = "Iced Tea", FoodType = "Drink", Description = "Chilled black tea with lemon and ice", Price = 1.79m },
                new Food { FoodName = "Matcha Latte", FoodType = "Drink", Description = "Creamy matcha green tea latte", Price = 2.99m },
                new Food { FoodName = "Tiramisu", FoodType = "Food", Description = "Classic Italian dessert with coffee and mascarpone", Price = 4.49m },
                new Food { FoodName = "Ice Cream Sundae", FoodType = "Food", Description = "Vanilla ice cream with chocolate syrup and a cherry on top", Price = 3.49m },
                new Food { FoodName = "Chicken Tikka Masala", FoodType = "Food", Description = "Spiced chicken in creamy tomato sauce served with rice", Price = 9.99m },
                new Food { FoodName = "Chocolate Cake", FoodType = "Food", Description = "Decadent chocolate cake slice with frosting", Price = 3.99m }
            };
            foreach (var food in Food)
            {
                foodRepo.Add(food);
            }
        }
    }
}
