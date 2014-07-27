using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace _4._5_Custom_Collections
{
    class ProductCollection : CollectionBase // Custom Collections must inherit from CollectionBase class
    {
        public void Add(Product prod)
        {
            List.Add(prod);
        }
        public void Insert(int index, Product prod)
        {
            List.Insert(index, prod);
        }
        public void Remove(Product prod)
        {
            List.Remove(prod);
        }
        // Indexer for referencing the collection by index
        public Product this[int index]
        {
            get
            {
                return (Product)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
