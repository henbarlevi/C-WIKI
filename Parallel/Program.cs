using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace ParallelCode
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             =========
             TASKS
             =========
             */
            Console.WriteLine("==== TASKS ====");
            /*
             [Task] is equivalent to [Promise] in js. it runs in parallel
             the difference is that task will not run until you tell it to:
             */
            var t1 = new Task(() => doJob("1", 400));
            t1.Start();//run task in another thread
            var t2 = new Task(() => doJob("2", 200));
            t2.Start();
            //How to create Task and run it immidietly
            Task.Factory.StartNew(() => doJob("3", 500));
            /* how to chain tasks
             * (run another task when the first task completed)
             * (equivalent to [.then()/.catch()] in promises)*/
            var t4 = Task.Factory.StartNew(() => doJob("4", 700)).ContinueWith((prevTask) => doMoreWork("4", 100));/* .then(res) - res == .ContinueWith(res) - res.Result*/
            /*
             How to run a bunch of tasks in parallel and then execute another task only after any/all tasks completed
             */
            var taskList = new List<Task>
             {
                Task.Factory.StartNew(() => doJob("taskList[1]", 1000)),
                Task.Factory.StartNew(() => doJob("taskList[2]", 1000)),
                Task.Factory.StartNew(() => doJob("taskList[3]", 1000)),
             };
            Task.WaitAll(taskList.ToArray()); //thread blocking operation. will not continue beyond this line until all taskList are completed - equivalent to [await Promise.All()] in js.
            /*
            =========
            Parallel
            =========*/
            Console.WriteLine("==== Parallel ====");
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //will do operation on each element in the collection in seperated thread (in parallel)
            Parallel.ForEach(numbers, (n) => Console.WriteLine($"Parallel:[{n}]"));////thread blocking operation. will not continue beyond this line until
            /*
            =========
            Abort Task
            =========*/
            Console.WriteLine("==== Abort Task ====");
            var source = new CancellationTokenSource();
            Task.Factory.StartNew(() => doJob("abortableTask", 2000, source.Token)).ContinueWith((prevTask) => doMoreWork("abortableTask", 500));
            source.Cancel();
            /*
           =========
           Async & Await
           =========*/

            asyncExmaple();
            Console.ReadLine();
        }

        static void doJob(string id, int sleepTime)
        {
            Console.WriteLine($"task {id} is [Beginning]");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} [Completed]");
        }
        static void doMoreWork(string id, int sleepTime)
        {
            Console.WriteLine($"task {id} is [Beginning] an extra work");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} [Completed] the extra work");
        }

        /*abortable task*/
        static void doJob(string id, int sleepTime, CancellationToken token)
        {
            try
            {
                Console.WriteLine($"task {id} is [Beginning]");
                Thread.Sleep(sleepTime);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task Cancellation Requested");
                    token.ThrowIfCancellationRequested();
                }
                Console.WriteLine($"task {id} [Completed]");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }

        }


        //equivalent to async&await in js
        async static void asyncExmaple()
        {
            Console.WriteLine("==== Async & Await ====");

            var x = 0;
            x = await Task.Factory.StartNew(() => returnNumber(10));
            Console.WriteLine(x);
        }
        static int returnNumber(int n)
        {
            Thread.Sleep(1000);
            return n;
        }
    }
}
