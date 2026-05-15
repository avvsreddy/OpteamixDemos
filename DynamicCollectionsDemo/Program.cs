namespace DynamicCollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Untyped collection
            //System.Collections.ArrayList untypedList = new System.Collections.ArrayList();
            //untypedList.Add(1);
            //untypedList.Add("Hello");
            //untypedList.Add(3.14);
            //untypedList.Add(new object());


            ////read
            //int data = (int)untypedList[1];


            // System.Collections.Generic namespace provides type-safe collections
            // List<>
            // HashSet<>
            // Dictionary<,>

            // Stack<>
            // Queue<>
            // LinkedList<>

            //System.Collections.Concurrent.ConcurrentBag<>
            // System.Collections.Concurrent.ConcurrentDictionary<,>
            // System.Collections.Concurrent.ConcurrentQueue<>
            // System.Collections.Concurrent.ConcurrentStack<>



            // need to store n numbers of integers
            //List<int> numbers = new List<int>(100);
            //Console.WriteLine(numbers.Capacity);
            //// add
            //numbers.Add(1);
           
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(4);
            //numbers.Add(5);
            //numbers.Add(5);
            //numbers.TrimExcess();
            //Console.WriteLine(numbers.Capacity);
            //Console.WriteLine(numbers.Count);
            //int sum = numbers.Sum();
            //int max = numbers.Max();
            //int min = numbers.Min();
            //double avg = numbers.Average();
            //numbers.Clear();
           

            //// read
            //int firstNumber = numbers[0];
            //foreach (int number in numbers)
            //{
            //    Console.WriteLine(number);

            //}

            // HashSet<>
            //HashSet<int> set = new HashSet<int>();
            //set.Add(1);
            //set.Add(2);
            //set.Add(2);
            //Console.WriteLine(set.Count);


            // want to store unique 100 randmom numbers

            //Generate a random number
            //Random rnd = new Random();
            //for (int i = 1; i <= 100; i++)
            //{
            //    int n = rnd.Next(1, 100);
            //    Console.WriteLine(n);
            //}
           //HashSet<int> randomNumbers = new HashSet<int>();
           // while (randomNumbers.Count < 100) 
           // {
           //     randomNumbers.Add(rnd.Next(1,101));
           // }

           // foreach (int i in randomNumbers) 
           // {
           //     //Console.WriteLine(i);
           // }


            // FIFO - First In First Out
            //Queue<int> queue = new Queue<int>();
            //// add
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);

            //// read
            //int first = queue.Dequeue(); // removes the first element and returns it
            //int second = queue.Dequeue();
            //int third = queue.Dequeue();

            //int n = queue.Peek(); // returns the first element without removing it

            ////. LIFO - Last In First Out  -Stack
            //Stack<int> stack = new Stack<int>();
            //// Add
            //stack.Push(1);
            //stack.Push(2);

            // read
            //stack.Pop(); // removes the top element and returns it
            //n = stack.Peek(); // returns the top element without removing it

            // KeyValue pairs - Dictionary<,>
            // Store Roll number and name of students
            Dictionary<int, string> studentRecords = new Dictionary<int, string>();
            studentRecords[111] = "Alice";
            studentRecords[222] = "Bob";
            studentRecords[222] = "Charlie";


            // read
            string name = studentRecords[111];


            // store emp names for each dept
            Dictionary<int, List<string>> deptEmployees = new Dictionary<int, List<string>>();

            List<string> empList1 = new List<string>();
            empList1.Add("Alice");
            empList1.Add("Bob");

            deptEmployees[10] = empList1;

            deptEmployees[20] = new List<string> { "Charlie", "David" };


            // accept a day number and display the day name without using if-else or switch-case
            int dayNumber = 3; // Example day number
            Dictionary<int, string> dayNames = new Dictionary<int, string>
            {
                { 1, "Monday" },
                { 2, "Tuesday" },
                { 3, "Wednesday" },
                { 4, "Thursday" },
                { 5, "Friday" },
                { 6, "Saturday" },
                { 7, "Sunday" }
            };
            Console.WriteLine(dayNames[dayNumber]);
        }
    }
}
