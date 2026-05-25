using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace MTDemo6ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataProducer producer = new DataProducer();
            //producer.FillData();
            //producer.FillData();
            Parallel.Invoke(producer.FillData, producer.FillData);
            Console.WriteLine(producer.DataStack.Count);
        }
    }


    class DataProducer
    {
        //public Stack<int> DataStack { get; private set; } = new Stack<int>();
        public ConcurrentStack<int> DataStack { get; private set; } = new ConcurrentStack<int>();

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FillData() 
        {
            for (int i = 0; i < 10000000; i++)
            {
                //Monitor.Enter(this);
                //lock (this)
                //{
                    DataStack.Push(i);
                //}
                //Monitor.Exit(this);

                //Mutex // can be used across process boundaries, but it is slower than lock and Monitor
                // Semaphore // can be allowd multiple threads to access the critical section


            }
        }
    }
}
