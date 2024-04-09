using glovo;
using System;

namespace Glovo
{
    class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public string WorkingHours { get; set; }
        public double DistanceFromUser { get; set; }
        public List<Dish> Menu { get; set; }
        public decimal DeliveryPrice { get; set; } // Ціна доставки

        public Restaurant(string name, string address, int rating, string workingHours, double distanceFromUser, List<Dish> menu, decimal deliveryPrice)
        {
            Name = name;
            Address = address;
            Rating = rating;
            WorkingHours = workingHours;
            DistanceFromUser = distanceFromUser;
            Menu = menu;
            DeliveryPrice = deliveryPrice;
        }
        public static void DisplayAvailableRestaurants(List<Restaurant> restaurants)
        {
            Console.WriteLine("Available restaurants:");
            for (int i = 0; i < restaurants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurants[i].Name} - Rating: {restaurants[i].Rating} - Working Hours: {restaurants[i].WorkingHours} - Distance: {restaurants[i].DistanceFromUser} km");
            }
        }
    }

    

}

