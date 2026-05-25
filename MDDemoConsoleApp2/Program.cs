using System.Diagnostics;

namespace MDDemoConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"No. Cores : {Environment.ProcessorCount}");
            Console.WriteLine("Running Seq....");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Method1();
            Method2();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Running in mupltiple threads");
            sw.Restart();
            Thread t1 = new Thread(Method1);
            t1.Start();
            Thread t2 = new Thread(Method2);
            t2.Start();
            t1.Join(); // Wait for thread t1 to finish
            t2.Join(); // Wait for thread t2 to finish
            Console.WriteLine(sw.ElapsedMilliseconds); // does not wait for the threads to finish, it will print the elapsed time immediately after starting the threads

            Console.WriteLine("Running using Task (TPL)");
            sw.Restart();
            Task task1 = new Task(Method1);
            task1.Start();
            Task task2 = new Task(Method2);
            task2.Start();
            task1.Wait(); // Wait for task1 to finish
            task2.Wait(); // Wait for task2 to finish
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Running using Parallel (TPL)");
            sw.Restart();
            Parallel.Invoke(Method1, Method2);
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Running using Parallel For Loop");
            sw.Restart();
            Parallel.Invoke(Method11, Method22);
            Console.WriteLine(sw.ElapsedMilliseconds);


        }

        public static void  Method1()
        {
            for (int i = 0; i < 10; i++) // Sequential execution of the loop, each iteration will wait for 1 second before moving to the next iteration, resulting in a total execution time of approximately 11 seconds (10 iterations + 1 initial iteration).
            {
                Thread.Sleep(1000);
            }
        }


        public static void Method11()
        {
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });
        }


        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
           
            {
                Thread.Sleep(1000);
            };
        }

        public static void Method22()
        {
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });
        }

    }
}
