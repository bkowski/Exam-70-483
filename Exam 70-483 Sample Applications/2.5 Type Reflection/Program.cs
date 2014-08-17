using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _2._5_Type_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to My Type Viewer*****");
            string typeName = "";

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("Or enter q to quit: ");

                typeName = Console.ReadLine();

                if(typeName.ToUpper() == "Q")
                {
                    break;
                }

                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }catch
                {
                    Console.WriteLine("Sorry can't find type");
                }
            } while (true);
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("*****Methods*****");
            MethodInfo[] mi = t.GetMethods();
            foreach(MethodInfo m in mi)
            {
                Console.WriteLine("->{0}", m.Name);
                Console.WriteLine();
            }
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("*****Fields*****");
            var fields = from f in t.GetFields()
                         select f.Name;
            foreach(string fi in fields)
            {
                Console.WriteLine("->{0}", fi);
                Console.WriteLine();
            }
        }

        static void ListProps(Type t)
        {
            Console.WriteLine("*****Properties*****");
            var props = from p in t.GetProperties()
                        select p.Name;
            foreach(string p in props)
            {
                Console.WriteLine("->{0}", p);
                Console.WriteLine();
            }
        }

        static void ListInterfaces(Type t)
        {
            Console.WriteLine("*****Interfaces*****");
            var interfaces = from i in t.GetInterfaces()
                             select i.Name;
            foreach(string i in interfaces)
            {
                Console.WriteLine("->{0}", i);
            }
        }

        static void ListVariousStats(Type t)
        {
            Console.WriteLine("*****Various Stats*****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericType);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }
}
