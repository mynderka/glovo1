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

        public Restaurant(string name, string address, int rating, string workingHours, double distanceFromUser)
        {
            Name = name;
            Address = address;
            Rating = rating;
            WorkingHours = workingHours;
            DistanceFromUser = distanceFromUser;
            Menu = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            Menu.Add(dish);
        }
    }
}
