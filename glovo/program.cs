using Glovo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class Program
    {
        static int ReadPositiveInteger(string message)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value <= 0);

            return value;
        }

        static double ReadPositiveDouble(string message)
        {
            double value;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out value) || value <= 0);

            return value;
        }

        static int ReadValidIndex(string message, int upperLimit)
        {
            int index;
            do
            {
                index = ReadPositiveInteger(message) - 1;
            } while (index < 0 || index >= upperLimit);

            return index;
        }

        static void Main(string[] args)
        {
            // Створення ресторанів
            var restaurants = new List<Restaurant>
        {
            new Restaurant("Good Eats", "123 Main St", 4, "10:00 - 22:00", 5.0),
            new Restaurant("Tasty Bites", "456 Elm St", 5, "11:00 - 23:00", 7.5),
            new Restaurant("Spicy Kitchen", "789 Oak St", 3, "09:00 - 21:00", 3.2),
            new Restaurant("Fresh Delight", "321 Maple St", 4, "08:00 - 20:00", 9.8)
        };

            // Додавання страв до меню ресторанів
            foreach (var restaurant in restaurants)
            {
                restaurant.AddDish(new Dish("Borsch", 10.99m));
                restaurant.AddDish(new Dish("Burger", 8.49m));
                restaurant.AddDish(new Dish("Caesar Salad", 7.99m));
                restaurant.AddDish(new Dish("Pizza", 12.99m));
                restaurant.AddDish(new Dish("Sushi", 14.99m));
            }

            // Створення кур'єрів
            var couriers = new List<Courier>
            {
            new Courier("John Doe", "555-1234", "car"),
            new Courier("Jane Smith", "555-5678", "motorcycle"),
            new Courier("Alex Johnson", "555-9876", "bicycle"),
            new Courier("Emily Brown", "555-4321", "foot")
        };

            // Створення клієнта
            var client = new Client("John", "456 Oak St", "555-9876");

            bool continueOrdering = true;
            while (continueOrdering)
            {
                // Вибір ресторану
                Console.WriteLine("Available restaurants:");
                for (int i = 0; i < restaurants.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {restaurants[i].Name} - Rating: {restaurants[i].Rating} - Working Hours: {restaurants[i].WorkingHours} - Distance: {restaurants[i].DistanceFromUser} km");
                }
                int selectedRestaurantIndex = ReadValidIndex("\nSelect a restaurant (enter number): ", restaurants.Count);

                // Вибір страви
                Console.WriteLine("\nAvailable dishes:");
                for (int i = 0; i < restaurants[selectedRestaurantIndex].Menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {restaurants[selectedRestaurantIndex].Menu[i].Name} - ${restaurants[selectedRestaurantIndex].Menu[i].Price}");
                }
                int selectedDishIndex = ReadValidIndex("\nSelect a dish (enter number): ", restaurants[selectedRestaurantIndex].Menu.Count);

                // Вибір кур'єра
                Console.WriteLine("\nAvailable couriers:");
                for (int i = 0; i < couriers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {couriers[i].Name} - Contact: {couriers[i].ContactInfo} - Mode: {couriers[i].TransportationMode}");
                }
                int selectedCourierIndex = ReadValidIndex("\nSelect a courier (enter number): ", couriers.Count);

                // Створення замовлення
                Order order = new Order(restaurants[selectedRestaurantIndex], restaurants[selectedRestaurantIndex].Menu[selectedDishIndex], couriers[selectedCourierIndex], DateTime.Now);
                client.OrderHistory.Add(order);

                // Виведення історії замовлень клієнта
                Console.WriteLine("\nYour order history:");
                foreach (var item in client.OrderHistory)
                {
                    Console.WriteLine($"Restaurant: {item.Restaurant.Name}, Dish: {item.Dish.Name}, Courier: {item.Courier.Name}, Order Time: {item.OrderTime}");
                }

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
