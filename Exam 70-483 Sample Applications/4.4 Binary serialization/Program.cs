using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _4._4_Binary_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product();
            prod.name = "Candy Bar";
            prod.price = 1.95m;
            prod.id = 1;

            IFormatter formatter = new BinaryFormatter();

            // Serialize
            Stream stream = new FileStream("Product.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, prod);
            stream.Close();

            // Deserialize
            stream = new FileStream("Product.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Product prod2 = (Product)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
