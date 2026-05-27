namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 23, 56, 23, 4, 78, 2, 89, 3, 99, 1 };
            // table: numbers
            // column: number
            // sql: select number from numbers where number mod 2 = 0
            // in c# we can do the same thing using linq

            var result = from num in numbers
                         where num % 2 == 0
                         select num;


            var result2 = numbers.Where(num => num % 2 == 0).Select(num => num);

            // extract all the even numbers from the list into a new list then display the new list
            // traditional way

            List<int> evens = new List<int>();
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    evens.Add(num);
                }
            }
            // display the even numbers
            foreach (int num in evens) 
            {
                Console.WriteLine(num);
            }
        }
    }
}
