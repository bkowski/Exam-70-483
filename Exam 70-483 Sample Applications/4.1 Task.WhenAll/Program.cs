using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace _4._1_Task.WhenAll
{
    class Program
    {
        static void Main(string[] args)
        {
            InputReader inputReader = new InputReader('d', 'x');
            inputReader.CharsMatch += ir_CharsMatch;

            Console.WriteLine("Press d to begin download and x to exit...");
            while(Console.ReadKey(true).KeyChar != null)
            {
                inputReader.CheckInput(Console.ReadKey().KeyChar);
            }
            
        }

        static async void ir_CharsMatch(object sender, EventArgs e)
        {
            await ExecuteMultipleRequestsInParallel();
        }

        static async Task ExecuteMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();

            Task[] tasks = new Task[]
            {
                client.GetStringAsync("http://www.imarketplace.com.au"),
                client.GetStringAsync("http://www.allthecraze.com.au"),
                client.GetStringAsync("http://www.shopwhiz.com.au")
            };
            //tasks[0] = client.GetStringAsync("http://www.imarketplace.com.au");
            //Task imarketplace = client.GetStringAsync("http://www.imarketplace.com.au");
            //Task allthecraze = client.GetStringAsync("http://www.allthecraze.com.au");
            //Task shopwhiz = client.GetStringAsync("http://www.shopwhiz.com.au");

            await Task.WhenAll(tasks);
            Console.WriteLine("Download complete...");
        }
    }

    class InputReader
    {
        public event EventHandler CharsMatch;

        private char inputTarget;
        private char exitChar;

        public InputReader(char inputTarget, char exitChar)
        {
            this.inputTarget = inputTarget;
            this.exitChar = exitChar;
        }

        public void CheckInput(char c)
        {
            if(c.CompareTo(inputTarget) == 0)
            {
                Console.WriteLine("Download commencing...");
                
                OnCharsMatch(EventArgs.Empty);
            }
            else if(c.CompareTo(exitChar) == 0)
            {
                Console.WriteLine("Exiting application in 5 seconds...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        protected virtual void OnCharsMatch(EventArgs e)
        {
            EventHandler handler = CharsMatch;
            if(handler != null)
            {
                handler(this, e);
            }
        }
    }
}
