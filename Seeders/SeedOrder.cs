using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS_SLS_Y4.Models;
using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Repositories;
using MySql.Data.MySqlClient;

namespace HMS_SLS_Y4.Seeders
{
    public class SeedOrder
    {
        private readonly CustomerRepository customerRepo = new CustomerRepository();
        private readonly RoomRepository roomRepo = new RoomRepository();
        private readonly FoodOrderRepository orderRepo = new FoodOrderRepository();
        private readonly OrderItemRepository itemRepo = new OrderItemRepository();

        private readonly string connStr = DatabaseHelper.ConnectionString;

        public void SeedOrders()
        {
            // --- Clear tables first ---
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SET FOREIGN_KEY_CHECKS = 0;
                    TRUNCATE TABLE food_orders;
                    TRUNCATE TABLE order_items;
                    SET FOREIGN_KEY_CHECKS = 1;
                ";
                cmd.ExecuteNonQuery();
            }

            var order1A = new FoodOrder { bookingId = 1, orderDate = DateTime.Now, status = "Ordered" };
            var order1B = new FoodOrder { bookingId = 1, orderDate = DateTime.Now.AddMinutes(10), status = "Ordered" };

            var order2A = new FoodOrder { bookingId = 2, orderDate = DateTime.Now, status = "Ordered" };
            var order2B = new FoodOrder { bookingId = 2, orderDate = DateTime.Now.AddMinutes(15), status = "Ordered" };
            var order2C = new FoodOrder { bookingId = 2, orderDate = DateTime.Now.AddMinutes(30), status = "Ordered" };

            var order3A = new FoodOrder { bookingId = 3, orderDate = DateTime.Now, status = "Ordered" };
            var order3B = new FoodOrder { bookingId = 3, orderDate = DateTime.Now.AddMinutes(20), status = "Ordered" };

            var order4A = new FoodOrder { bookingId = 4, orderDate = DateTime.Now, status = "Ordered" };
            var order4B = new FoodOrder { bookingId = 4, orderDate = DateTime.Now.AddMinutes(25), status = "Ordered" };
            var order4C = new FoodOrder { bookingId = 4, orderDate = DateTime.Now.AddMinutes(40), status = "Ordered" };

            var orders = new List<FoodOrder>
            {
                order1A, order1B,
                order2A, order2B, order2C,
                order3A, order3B,
                order4A, order4B, order4C
            };

            foreach (var order in orders)
            {
                orderRepo.Add(order);
            }

            var insertedOrders = orderRepo.GetAll();

            var orderItems = new List<OrderItem>
            {
                // Booking 1 orders
                new OrderItem { OrderId = insertedOrders[0].orderId, FoodId = 1, Quantity = 2, note = "No spicy", totalPrice = 20.0m },
                new OrderItem { OrderId = insertedOrders[0].orderId, FoodId = 3, Quantity = 1, note = "Extra cheese", totalPrice = 10.0m },

                new OrderItem { OrderId = insertedOrders[1].orderId, FoodId = 2, Quantity = 1, note = "N/A", totalPrice = 12.0m },
                new OrderItem { OrderId = insertedOrders[1].orderId, FoodId = 4, Quantity = 2, note = "Less salt", totalPrice = 24.0m },

                // Booking 2 orders
                new OrderItem { OrderId = insertedOrders[2].orderId, FoodId = 1, Quantity = 3, note = "Extra sauce", totalPrice = 30.0m },
                new OrderItem { OrderId = insertedOrders[2].orderId, FoodId = 5, Quantity = 1, note = "N/A", totalPrice = 15.0m },

                new OrderItem { OrderId = insertedOrders[3].orderId, FoodId = 2, Quantity = 2, note = "No onion", totalPrice = 18.0m },
                new OrderItem { OrderId = insertedOrders[3].orderId, FoodId = 6, Quantity = 1, note = "Well done", totalPrice = 22.0m },

                new OrderItem { OrderId = insertedOrders[4].orderId, FoodId = 3, Quantity = 1, note = "Cheesy crust", totalPrice = 14.0m },
                new OrderItem { OrderId = insertedOrders[4].orderId, FoodId = 7, Quantity = 2, note = "No pepper", totalPrice = 26.0m },

                // Booking 3 orders
                new OrderItem { OrderId = insertedOrders[5].orderId, FoodId = 4, Quantity = 2, note = "Less oil", totalPrice = 22.0m },
                new OrderItem { OrderId = insertedOrders[6].orderId, FoodId = 1, Quantity = 3, note = "No sugar", totalPrice = 27.0m },

                // Booking 4 orders
                new OrderItem { OrderId = insertedOrders[7].orderId, FoodId = 5, Quantity = 2, note = "Extra crispy", totalPrice = 20.0m },
                new OrderItem { OrderId = insertedOrders[8].orderId, FoodId = 2, Quantity = 1, note = "Less salt", totalPrice = 10.0m },
                new OrderItem { OrderId = insertedOrders[9].orderId, FoodId = 8, Quantity = 2, note = "N/A", totalPrice = 25.0m }
            };

            foreach (var item in orderItems)
            {
                itemRepo.Add(item);
            }

        }

    }
}
