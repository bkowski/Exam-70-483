using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4_CarDelegate
{
    public class Car
    {
        // Delegate type
        public delegate void CarEngineHandler(string msgForCaller);
        // Member variable of this delegate
        private CarEngineHandler listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }
        public void Accelerate(int delta)
        {
            if(carIsDead)
            {
                if(listOfHandlers != null)
                {
                    listOfHandlers("Sorry, this car is dead");
                }
            }
            else
            {
                CurrentSpeed += delta;
                if(10 == (CurrentSpeed - MaxSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful, gonna blow");
                }
                if(CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("Current speed = {0}", CurrentSpeed);
                }
            }
        }

        // internal state data
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        // Is the car alive or dead
        public bool carIsDead;

        // Class constructors
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSpd, int curSpd)
        {
            CurrentSpeed = curSpd;
            MaxSpeed = maxSpd;
            PetName = name;

        }
    }
}
