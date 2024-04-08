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
    }
}
