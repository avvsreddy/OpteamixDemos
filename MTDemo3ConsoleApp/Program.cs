namespace MTDemo3ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Method1();
        }

        public static void Method1()
        {
            int pc = Environment.ProcessorCount/2;
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = pc;
            Parallel.For(0, 100,po, i =>
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
