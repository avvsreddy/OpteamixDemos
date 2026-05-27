using System.Security.Cryptography;

namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // var - implicitly typed variable
            // Anonymous types - types without a name, created using the var keyword
            // Extension methods - methods that can be called on any type, even if the type does not have the method defined
            // Object initializers - a way to initialize an object without calling a constructor
            // LINQ - Language Integrated Query, a way to query collections of data using a syntax similar to SQL
            // Lambda expressions - a way to write anonymous functions, often used in LINQ queries
            // Linq Providers - a way to query data from different sources, such as databases, XML, etc.

            Console.WriteLine("Hello, World!");


            string data = "some random text with some words and some more words";
            data = data.ToUpper();
            Console.WriteLine(data);

            data.Encrypt();
            data.Encrypt();
            string encryptedData = SomeClass.Encrypt(data);

            int n = 234234234;
            //n.Encrypt();
            Program p = new Program();

            List<string> list = new List<string>() { "one", "two", "three" };
            if (data.IsEmail())
            {
                Console.WriteLine("This is an email");

            }
        }
    }

    public static class SomeClass
    {
        public static string Encrypt(this string data)
        {
            return "@#$@#DSFSDSRT#$^#$TERGDFGSDFER@#$%@#$E%THDFGSDFGQWE%#$^";
        }

        public static string Decrypt(this string data)
        {
            return "some random text with some words and some more words";
        }


        extension(string data)
        {
            public string Encrypt1()
            {
                return "@#$@#DSFSDSRT#$^#$TERGDFGSDFER@#$%@#$E%THDFGSDFGQWE%#$^";
            }
            public string Decrypt1()
            {
                return "some random text with some words and some more words";
            }

            public bool IsEmail()
            {
                return data.Contains("@");
            }
        }
    }
}


