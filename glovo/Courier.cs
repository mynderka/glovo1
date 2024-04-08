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

        public Courier(string name, string contactInfo, string transportationMode)
        {
            Name = name;
            ContactInfo = contactInfo;
            TransportationMode = transportationMode;
        }
    }
}
