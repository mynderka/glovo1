using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovo
{
    class MockTester
    {
        public List<Client> AvailableClients { get; set; }
        public DeliveryManager DeliveryManager { get; set; }

        public MockTester(List<Client> availableClients, DeliveryManager deliveryManager)
        {
            AvailableClients = availableClients;
            DeliveryManager = deliveryManager;
        }

        public void TestDeliveryService()
        {
            // Логіка тестування функціональності сервісу доставки
            // Створення випадкового замовлення та виклик DeliveryManager
        }
    }
}
