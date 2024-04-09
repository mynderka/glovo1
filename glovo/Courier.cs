using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class Courier
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string TransportationMode { get; set; }
        public decimal DeliveryPrice { get; set; } // Ціна доставки

        public Courier(string name, string contactInfo, string transportationMode, decimal deliveryPrice)
        {
            Name = name;
            ContactInfo = contactInfo;
            TransportationMode = transportationMode;
            DeliveryPrice = deliveryPrice;
        }

        public static void DisplayAvailableCouriers(List<Courier> couriers)
        {
            Console.WriteLine("\nAvailable couriers:");
            for (int i = 0; i < couriers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {couriers[i].Name} - Contact: {couriers[i].ContactInfo} - Type of moving: {couriers[i].TransportationMode} - Delivery Price: {couriers[i].DeliveryPrice}");
            }
        }
    }
}

        


