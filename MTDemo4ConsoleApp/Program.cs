namespace MTDemo4ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            t1.Start();

            Task task1 = new Task(M1);


            // ThreadStart (no return no parameters) and ParameterizedThreadStart (no return and one object parameter)
            Thread t2 = new Thread( () => { M2("sdfsdfsdf"); });
            t2.Start();

            Task task2 = new Task(() => { M2("sdfsdfsdf"); });

            //Thread t3 = new Thread(M3);
            Task<int> task3 = new Task<int>(M3);
            task3.Start();

            Task task33 = Task.Factory.StartNew(() => M3()); // This will start M3 immediately and return a Task<int> that represents the ongoing operation of M3. You can then use task33.Result to get the return value from M3 once it completes.


            // do some other work here while M3 is running...

            int returnValue = task3.Result; // This will block until M3 completes and returns a value.
            // will execute M3 and wait for it to complete, then retrieve the return value from M3.


            Task<int> task4 = new Task<int>(() => { return M4(5); });
            task4.Start();
            // do some other work here while M4 is running...
            int returnValue4 = task4.Result; // This will block until M4 completes and returns a value.
        }



        public static void M1() // TheradStart() method requires a parameterless method, so M1 is suitable for that. M2, M3, and M4 are not suitable because they require parameters or return values.
        {
            Console.WriteLine("M1");
        }
        public static void M2(string str)
        {
            Console.WriteLine("M2");
        }
        public static int M3()
        {
            Console.WriteLine("M3");
            return 0;
        }
        public static int M4(int i)
        {
            Console.WriteLine("M4");
            return i * i;
        }
    } 
}
