using Glovo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class DeliveryManager
    {
        public void AssignCourier(Order order)
        {
            Console.WriteLine($"Courier assigned for order from {order.Restaurant.Name} delivering {order.Dish.Name}: {order.Courier.Name}");
        }

        public void TrackOrderStatus(Order order)
        {
            Console.WriteLine($"Order from {order.Restaurant.Name} for {order.Dish.Name} is out for delivery with {order.Courier.Name}");
        }
        //todo

        public static Tuple<Restaurant, Dish> SelectRestaurantAndDish(List<Restaurant> restaurants)
        {
            Console.WriteLine("Available restaurants:");
            for (int i = 0; i < restaurants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurants[i].Name} - Rating: {restaurants[i].Rating} - Working Hours: {restaurants[i].WorkingHours} - Distance: {restaurants[i].DistanceFromUser} km");
            }
            int selectedRestaurantIndex = Program.ReadValidIndex("\nSelect a restaurant (enter number): ", restaurants.Count);

            Console.WriteLine("\nAvailable dishes:");
            for (int i = 0; i < restaurants[selectedRestaurantIndex].Menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurants[selectedRestaurantIndex].Menu[i].Name} - ${restaurants[selectedRestaurantIndex].Menu[i].Price}");
            }
            int selectedDishIndex = Program.ReadValidIndex("\nSelect a dish (enter number): ", restaurants[selectedRestaurantIndex].Menu.Count);

            return new Tuple<Restaurant, Dish>(restaurants[selectedRestaurantIndex], restaurants[selectedRestaurantIndex].Menu[selectedDishIndex]);
        }

        // Метод для відображення історії замовлень
        public static string DisplayOrderHistory(Client client)
        {
            StringBuilder history = new StringBuilder();

            // Додавання заголовка
            history.AppendLine("\nYour order history:");

            decimal totalPrice = 0; // Загальна ціна замовлення
            foreach (var item in client.OrderHistory)
            {
                // Додавання інформації про кожне замовлення
                history.AppendLine($"Restaurant: {item.Restaurant.Name}, Dish: {item.Dish.Name}, Price: {item.Dish.Price}, Courier: {item.Courier.Name}, Order Time: {item.OrderTime}");

                // Розрахунок загальної ціни
                totalPrice += item.Dish.Price; // Додавання ціни страви до загальної ціни
                totalPrice += item.Courier.DeliveryPrice; // Додавання ціни доставки до загальної ціни
            }

            // Додавання загальної ціни до історії замовлень
            history.AppendLine($"Total Price: {totalPrice}");

            return history.ToString();
        }
    }
}
