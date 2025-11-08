using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HMS_SLS_Y4.Repositories
{
    public class FoodRepository : BaseRepository<Food>
    {
        public FoodRepository() : base(DatabaseHelper.ConnectionString) { }

        public override int Add(Food entity)
        {
            string query = @"INSERT INTO foods (food_name, food_type, description, price, created_at)
                             VALUES (@name, @food_type, @description, @price, @createdAt)";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", entity.FoodName);
            cmd.Parameters.AddWithValue("@food_type", entity.FoodType);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@createdAt", entity.CreatedAt == default ? DateTime.Now : entity.CreatedAt);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting food: " + ex.Message);
                return 0;
            }
        }

        public override bool Delete(int id)
        {
            string query = "DELETE FROM foods WHERE food_id = @id";
            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error deleting food: " + ex.Message);
                return false;
            }
        }

        public override List<Food> GetAll()
        {
            var list = new List<Food>();
            string query = "SELECT food_id, food_name, food_type, description, price, created_at FROM foods ORDER BY food_name";

            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var f = new Food
                    {
                        FoodId = reader.GetInt32("food_id"),
                        FoodName = reader.IsDBNull(reader.GetOrdinal("food_name")) ? string.Empty : reader.GetString("food_name"),
                        FoodType = reader.IsDBNull(reader.GetOrdinal("food_type")) ? string.Empty : reader.GetString("food_type"),
                        Description = reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                        Price = reader.IsDBNull(reader.GetOrdinal("price")) ? 0m : reader.GetDecimal("price"),
                        CreatedAt = reader.IsDBNull(reader.GetOrdinal("created_at")) ? DateTime.MinValue : reader.GetDateTime("created_at")
                    };
                    list.Add(f);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching foods: " + ex.Message);
            }

            return list;
        }

        public override Food GetById(int id)
        {
            string query = "SELECT food_id, food_name, description, price, created_at FROM foods WHERE food_id = @id";
            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Food
                    {
                        FoodId = reader.GetInt32("food_id"),
                        FoodName = reader.IsDBNull(reader.GetOrdinal("food_name")) ? string.Empty : reader.GetString("food_name"),
                        Description = reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                        Price = reader.IsDBNull(reader.GetOrdinal("price")) ? 0m : reader.GetDecimal("price"),
                        CreatedAt = reader.IsDBNull(reader.GetOrdinal("created_at")) ? DateTime.MinValue : reader.GetDateTime("created_at")
                    };
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error fetching food: " + ex.Message);
            }

            return null;
        }

        public override bool Update(Food entity)
        {
            string query = @"UPDATE foods SET food_name = @name, description = @description, price = @price WHERE food_id = @id";
            using var conn = new MySqlConnection(ConnectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", entity.FoodName);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@price", entity.Price);
            cmd.Parameters.AddWithValue("@id", entity.FoodId);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating food: " + ex.Message);
                return false;
            }
        }
    }
}