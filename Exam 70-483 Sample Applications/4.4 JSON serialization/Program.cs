using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Json;

namespace _4._4_JSON_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product();
            prod.id = 1;
            prod.name = "Kit Kat";
            prod.price = 2.50m;

            // Serialize
            Stream stream = new FileStream("Product.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
            ser.WriteObject(stream, prod); // Note: call WriteObject method instead of Serialize
            stream.Close();

            // Deserialize
            Product prod2 = new Product();
            Stream stream2 = new FileStream("Product.json", FileMode.Open);
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Product));
            prod2 = (Product)ser.ReadObject(stream2); // Note: call ReadObject method instead of Deserialize
            stream2.Close();
        }
    }
}
