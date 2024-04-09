using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class Dish
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dish(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static void DisplayAvailableDishes(List<Dish> dishes)
        {
            Console.WriteLine("\nAvailable dishes:");
            for (int i = 0; i < dishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dishes[i].Name} - ${dishes[i].Price}");
            }
        }
    }



}
