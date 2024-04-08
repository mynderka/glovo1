using Glovo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class Order
    {
        public Restaurant Restaurant { get; set; }
        public Dish Dish { get; set; }
        public Courier Courier { get; set; }
        public DateTime OrderTime { get; set; }

        public Order(Restaurant restaurant, Dish dish, Courier courier, DateTime orderTime)
        {
            Restaurant = restaurant;
            Dish = dish;
            Courier = courier;
            OrderTime = orderTime;
        }
    }
}
