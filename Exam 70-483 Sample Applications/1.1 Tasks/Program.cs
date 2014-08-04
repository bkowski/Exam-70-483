using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewTask();
            // best practice
            TaskDotRun();
        }

        private static void NewTask()
        {
            Thread.CurrentThread.Name = "Main";
            // create a task
            Task taskA = new Task(() => Console.WriteLine("Hello from task A"));
            // start the task
            taskA.Start();
            // output message from the calling thread
            Console.WriteLine("Hello from thread {0}", Thread.CurrentThread.Name);

            // call Task.Wait to ensure task completes before console closes
            taskA.Wait();

            Console.ReadLine();
        }

        private static void TaskDotRun()
        {
            Thread.CurrentThread.Name = "Main";
            // define and run the task in the one operation
            Task taskA = Task.Run(() => Console.WriteLine("Hello from task A"));

            // output message from the calling thread
            Console.WriteLine("Hello from thread {0}", Thread.CurrentThread.Name);

            // call Task.Wait to ensure task completes before console closes
            taskA.Wait();

            Console.ReadLine();
        }

        private static void TaskFactoryStartNew()
        {
            Thread.CurrentThread.Name = "Main";
            // create and start task in one operation
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from task A"));

            // output message from the calling thread
            Console.WriteLine("Hello from thread {0}", Thread.CurrentThread.Name);

            // call Task.Wait to ensure task completes before console closes
            taskA.Wait();

            Console.ReadLine();
        }

        private static void TaskReturnValue()
        {
            Task<int> t = Task.Run(() =>
            {
                return 145;
            });
            Console.WriteLine(t.Result);
            Console.ReadLine();
        }

        #region Task Continuation
        private static void TaskContinuation()
        {
            Task<int> t = Task.Run(() =>
                {
                    return 55;
                }).ContinueWith((i) =>
                {
                    return i.Result * 2;
                });
            Console.WriteLine(t.Result);
        }
        #endregion

        #region Child Tasks
        private static void ChildTasks()
        {
            var parent = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Parent task beginning...");
                    for (int ctr = 0; ctr < 10; ctr++)
                    {
                        int taskNo = ctr;
                        Task.Factory.StartNew((x) =>
                        {
                            Thread.SpinWait(5000000);
                            Console.WriteLine("Attached child #{0} completed", x);
                        }, taskNo, TaskCreationOptions.AttachedToParent);
                    }

                });

            parent.Wait();
            Console.WriteLine("Parent task completed");
            Console.ReadLine();
        }
        #endregion

        #region Task.WaitAny Task.WaitAny
        private static void TaskWaiting()
        {
            Task[] tasks = new Task[3]
            {
                Task.Factory.StartNew(() => Thread.Sleep(2000)),
                Task.Factory.StartNew(() => Thread.Sleep(1000)),
                Task.Factory.StartNew(() => Thread.Sleep(3000))
            };

            // block until all tasks complete
            Task.WaitAll(tasks);

            // block until any task completes
            Task.WaitAny(tasks);
        }
        #endregion
    }
}
