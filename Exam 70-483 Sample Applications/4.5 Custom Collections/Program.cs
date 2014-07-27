using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _4._5_Custom_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductCollection products = new ProductCollection();

            products.Add(new Product()
            {
                ProductId = 1,
                Name = "Kit Kat",
                Price = 1.50m
            });

            products.Add(new Product()
            {
                ProductId = 2,
                Name = "Hubba Bubba",
                Price = 0.50m
            });

            foreach(Product prod in products)
            {
                Debug.WriteLine(prod.Name);
            }
        }
    }
}
