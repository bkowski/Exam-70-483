using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4._2_XmlDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("People.xml");
            XmlNodeList nodes = doc.GetElementsByTagName("person");

            foreach(XmlNode node in nodes)
            {
                string firstname = node.Attributes["firstname"].Value;
                Console.WriteLine("Name: {0}", firstname);
            }

            // start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstname");
            firstNameAttribute.Value = "Bar";

            newNode.Attributes.Append(firstNameAttribute);

            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);

            Console.ReadLine();
        }
    }
}
