using System.Runtime.CompilerServices;

namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Static/Fixed size collection
            // To Store fixed number of items
            // To Store items of same type
            // Ex: Store 5 numbers, Store 10 names, Store 3 products


            int a1 = 1; // scalar variable
            int a2 = 2; // value type variable
            int a3 = 3;

            // int a[4]
            int[] a = new int[5];
            a[0] = 10;
            a[1] = 20;
            a[2] = 30;
            a[3] = 40;
            a[4] = 50;

            Console.WriteLine(a[0]);
            Console.WriteLine(a[1]);
            Console.WriteLine(a[2]);
            Console.WriteLine(a[3]);
            Console.WriteLine(a[4]);

            // accept 5 numbers from user and store in array and display the numbers
            int[] numbers = new int[4];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter a number: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            // display the numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // declare
            int[] arr; // declaration of array
            // allocation
            arr = new int[5]; // allocation of array
            // initialization
            arr[0] = 10;

            // declare, allocate and initialize in single statement
            int[] arr2 = new int[5] { 10, 20, 30, 40, 50 };

            int sum = arr2.Sum();
            int max = arr2.Max();
            int min = arr2.Min();
            double avg = arr2.Average();
            Array.Sort(arr2);//assending in ascending order
            Array.Reverse(arr2);//descending order

            int size = 10;
            string[] names = new string[size];




            int[] arr3 = new int[] { 10, 20, 30, 40, 50 };
            int[] arr4 = { 10, 20, 30, 40, 50 };

            Product[] products = new Product[3];
            Product p1 = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            products[0] = p1;
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
