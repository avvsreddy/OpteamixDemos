namespace LinqToObjectsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {12,56,44,89,67,4,90,11,23,35,68,87 }; // In-Memory Object
            // Linq To Objects
            // select all even numbers

           // Func<int, bool> predicate = new Func<int, bool>(IsEven);

            var evens = (from n in numbers
                        where n % 2 == 0
                        orderby n descending
                        select n).ToList();

            var evens2 = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .Select(n => n).ToList();

            // Linq query always returns IEnumerable collection

            numbers.Add(10);

            // display
            foreach (var n in evens) 
            {
                Console.WriteLine(n);
            }

            // get the first element from the collection
            int firstNumber = numbers.First(); // throws exception if collection is empty
            firstNumber = numbers.FirstOrDefault(); // returns null if collection is empty

            int sum = numbers.Sum();
            int max = numbers.Max();
            double avg = numbers.Average();
            int count = numbers.Count();
            int min = numbers.Min();
            bool found = numbers.Any(n => n > 100);

            


        }
       // public static bool IsEven(int n) { return n % 2 == 0; }
    }
}
