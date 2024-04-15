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
