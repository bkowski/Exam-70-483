using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace _4._4_XML_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product();
            prod.id = 1;
            prod.name = "Gummy Bears";
            prod.price = 3.95m;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));

            // Serialize
            StreamWriter streamWriter = new StreamWriter("Product.xml");
            xmlSerializer.Serialize(streamWriter, prod);
            streamWriter.Close();

            // Deserialize
            FileStream fs = new FileStream("Product.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Product prod2 = (Product)xmlSerializer.Deserialize(fs);

        }
    }
}
