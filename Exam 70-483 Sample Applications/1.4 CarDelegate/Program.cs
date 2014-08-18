using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4_CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            // First make a car object
            Car car1 = new Car("Slug Bug", 100, 10);

            // Now tell the car which method to call when it wants to send us messages
            car1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            // Speed up, this will trigger the events
            Console.WriteLine("***** Speeding Up *****");
            for(int i = 0; i < 6; i++)
            {
                car1.Accelerate(20);
                Console.ReadLine();
            }            
        }

        // This is the target for incomming events
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message from car object *****");
            Console.WriteLine("-> {0}", msg);
            Console.WriteLine("*************************************\n");
        }
    }
}
