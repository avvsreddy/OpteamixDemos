namespace MTDemoConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main executing in thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Running Seq....");
            Program p = new Program();
            //p.Method1();
            //Method2();

            // Classic way to create a thread and run a method in it
            ThreadStart threadStart = new ThreadStart(p.Method1);
            Thread thread1 = new Thread(threadStart);
            //thread1.Start();

            Thread thread2 = new Thread(Method2);
            //thread2.Start();

            Console.WriteLine("End of Main...");

        }

        public void Method1()
        {
            Console.WriteLine($"Method1 executing in thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("This is Method1.");
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine($"Method1 loop iteration {i}");
                Thread.Sleep(500); // Simulate some work
            }
        }

        public static void Method2()
        {
            Console.WriteLine($"Method2 executing in thread id: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("This is Method2.");
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine($"Method2 loop iteration {i}");
                Thread.Sleep(500); // Simulate some work
            }
        }
    }
}
