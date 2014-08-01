using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace _2._5_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // with reflection
            object dog = Activator.CreateInstance(typeof(Dog));
            PropertyInfo[] properties = typeof(Dog).GetProperties();
            PropertyInfo numberOfLegsProperty1 = properties[0];

            // or
            PropertyInfo numberOfLegsProperty2 = null;
            foreach(PropertyInfo propertyInfo in properties)
            {
                if(propertyInfo.Name.Equals("numberoflegs", StringComparison.CurrentCultureIgnoreCase))
                {
                    numberOfLegsProperty2 = propertyInfo;
                }
            }

            numberOfLegsProperty1.SetValue(dog, 3, null);

            Console.WriteLine(numberOfLegsProperty2.GetValue(dog, null));

            // use reflection to invoke different constructors

            var defaultConstructor = typeof(Dog).GetConstructor(new Type[0]);
            var legConstructor = typeof(Dog).GetConstructor(new[] { typeof(int) });

            var defaultDog = (Dog)defaultConstructor.Invoke(null);
            Console.WriteLine(defaultDog.NumberOfLegs);

            var legDog = (Dog)legConstructor.Invoke(new object[] { 5 });
            Console.WriteLine(legDog.NumberOfLegs);

            Console.ReadLine();
        }
    }

    internal class Dog
    {
        public int NumberOfLegs { get; set; }
        public Dog()
        {
            NumberOfLegs = 4;
        }
        public Dog(int legs)
        {
            NumberOfLegs = legs;
        }
    }
}
