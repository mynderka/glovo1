using Glovo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class Program
    {
        public static int ReadPositiveInteger(string message)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value <= 0);

            return value;
        }

        public static double ReadPositiveDouble(string message)
        {
            double value;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out value) || value <= 0);

            return value;
        }

        public static int ReadValidIndex(string message, int upperLimit)
        {
            int index;
            do
            {
                index = ReadPositiveInteger(message) - 1;
            } while (index < 0 || index >= upperLimit);

            return index;
        }

        public static Tuple<Restaurant, Dish> SelectRestaurantAndDish(List<Restaurant> restaurants)
        {
            // показуєм ресторани
            Restaurant.DisplayAvailableRestaurants(restaurants);
            int selectedRestaurantIndex = ReadValidIndex("\nSelect a restaurant (enter number): ", restaurants.Count);

            // показуєм страви в кожному з ресторанів
            Dish.DisplayAvailableDishes(restaurants[selectedRestaurantIndex].Menu);
            int selectedDishIndex = ReadValidIndex("\nSelect a dish (enter number): ", restaurants[selectedRestaurantIndex].Menu.Count);

            return new Tuple<Restaurant, Dish>(restaurants[selectedRestaurantIndex], restaurants[selectedRestaurantIndex].Menu[selectedDishIndex]);
        }

        static void Main(string[] args)
        {
            // Створення списку ресторанів та кур'єрів (включаючи їх меню та ціни доставки)
            var restaurants = new List<Restaurant>
            {   
            new Restaurant("Good Eats", "123 Main St", 4, "10:00 - 22:00", 5.0, new List<Dish> { new Dish("Borsch", 10.99m), new Dish("Varenyky", 12.49m), new Dish("Banosh", 11.29m), new Dish("Mushroom Soup", 9.99m) }, 3.0m),
            new Restaurant("Tasty Bites", "456 Elm St", 5, "11:00 - 23:00", 7.5, new List<Dish> { new Dish("Burger", 8.49m), new Dish("Nuggets", 7.99m), new Dish("Fried Chicken", 9.99m), new Dish("Salad", 7.99m) }, 4.0m),
            new Restaurant("Spicy Kitchen", "789 Oak St", 3, "09:00 - 21:00", 3.2, new List<Dish> { new Dish("Tacos", 11.99m), new Dish("Burrito", 10.49m), new Dish("Enchiladas", 12.99m), new Dish("Quesadilla", 9.99m) }, 2.5m),
            new Restaurant("Fresh Delight", "321 Maple St", 4, "08:00 - 20:00", 9.8, new List<Dish> { new Dish("Sushi", 14.99m), new Dish("Ramen", 12.99m), new Dish("Udon", 11.99m), new Dish("Tempura", 13.49m) }, 3.5m),
            new Restaurant("Dobra", "9 builders st", 4, "07:00 - 22:00", 10.2, new List<Dish> { new Dish("Coffee", 3.99m), new Dish("Tea", 2.49m), new Dish("Juice", 4.99m), new Dish("Cheesecakes", 7.99m) }, 2.0m)
            };

            // Створення списку кур'єрів
            var couriers = new List<Courier>
            {
            new Courier("John Dee", "555-1234", "car", 5.0m),
            new Courier("Will Smith", "555-5678", "motorcycle", 4.0m),
            new Courier("Alex Xanax", "555-9876", "bicycle", 3.0m),
            new Courier("Emma Brown", "555-4321", "foot", 2.0m),
            new Courier("Sasha Zaets", "228-456", "kultapka", 1.0m)
            };

            // Створення клієнта
            var client = new Client("Natasha", "456 Oak St", "555-9876");

            bool continueOrdering = true;
            while (continueOrdering)
            {
                // Вибір ресторану та страви
                var selectedRestaurantAndDish = SelectRestaurantAndDish(restaurants);
                var selectedRestaurant = selectedRestaurantAndDish.Item1;
                var selectedDish = selectedRestaurantAndDish.Item2;

                // Вибір кур'єра
                Console.WriteLine("\nAvailable couriers:");
                Courier.DisplayAvailableCouriers(couriers);
                int selectedCourierIndex = Program.ReadValidIndex("\nSelect a courier (enter number): ", couriers.Count);

                // Створення замовлення
                Order order = new Order(selectedRestaurant, selectedDish, couriers[selectedCourierIndex], DateTime.Now);
                client.OrderHistory.Add(order);

                // Виведення історії замовлень клієнта та обчислення загальної ціни
                Console.WriteLine(DeliveryManager.DisplayOrderHistory(client));


                // Питання про продовження замовлення
                Console.Write("\nDo you want to place another order? (yes/no): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "yes")
                {
                    continueOrdering = false;
                }
            }
            // Програма завершує роботу
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
