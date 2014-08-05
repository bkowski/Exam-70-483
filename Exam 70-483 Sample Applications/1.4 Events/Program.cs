using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4_Events
{
    // a class to hold information about the event
    public class TimeInfoEventArgs : EventArgs
    {
        public int hour;
        public int minute;
        public int second;

        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }

    // the publisher: class other classes will observe
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        // the delegate the subscribers must implement
        public delegate void SecondChangedHandler(object clock, TimeInfoEventArgs timeInformation);
        // an instance of the delegate using event keyword
        public event SecondChangedHandler SecondChanged;

        // set the clock running
        public void Run()
        {
            // infinite loop
            for(; ; )
            {
                System.Threading.Thread.Sleep(100);

                // get the current time
                System.DateTime dt = DateTime.Now;
                // if the second has changed notify the subscribers
                if(dt.Second != this.second)
                {
                    // create the TimeInfoEventArgs object to pass to the subscriber
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                    // if anyone has subscribed notify them
                    if(SecondChanged != null)
                    {
                        SecondChanged(this, timeInformation);
                    }
                }

                // update the state
                this.hour = dt.Hour;
                this.minute = dt.Minute;
                this.second = dt.Second;
            }
        }
    }

    // a subscriber
    public class DisplayClock
    {
        // given a clock, subscribe to its SecondChangedHandler event
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChanged += new Clock.SecondChangedHandler(TimeHasChanged);
        }

        // the method that implements the delegated functionality
        public void TimeHasChanged(object clock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current time: {0}:{1}:{2}", ti.hour, ti.minute, ti.second);
        }
    }

    public class Tester
    {
        public void Run()
        {
            // create a new clock
            Clock theClock = new Clock();

            // create the display and tell it to subscribe to the clock just created
            DisplayClock displayClock = new DisplayClock();
            displayClock.Subscribe(theClock);

            // get the clock started
            theClock.Run();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Tester test = new Tester();
            test.Run();
        }
    }
}
