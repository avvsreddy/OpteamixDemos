namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee(1, "John Doe");
            e.DisplayInfo();
            
            string str = "Hello World";
            

            "sdfdf".IsUpper();
            "sfsfsdf".IsLower();
            "sdfsdf".IsUpper();

            //Point p = new Point(10, 20);
            
            //PointClass pc = new PointClass { X = 10, Y = 20 };
            //pc.X =11; pc.Y = 20;
            //pc.Display();
            //PointRecord pr = new PointRecord(10, 20);
            //pr.X = 11; pr.Y = 20; // This will cause a compile-time error because properties in a record with init-only setters cannot be modified after initialization.
        }
    }

    class Employee(int id, string name) // Primary constructor syntax introduced in C# 14.0
                                        //Why use primary constructor syntax? It provides a concise way to define a class with immutable properties, reducing boilerplate code and improving readability. In this example, the Employee class has two properties, id and name, which are initialized through the primary constructor. The DisplayInfo method can access these properties directly without needing additional fields or constructors.
    {
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {id}, Name: {name}");
        }
    }

    public record Point(int X, int Y); // Record struct with primary constructor syntax

    class PointClass
    {
        public int X { get; init ; }
        public int Y { get; init ; }
        public void Display()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
    }

    public record PointRecord(int X, int Y); // Record class with primary constructor syntax

    // create an extension method for the Point class


    public static class MyExtensions
    {

        //public static bool IsLower(this string data)
        //{
        //    return data == data.ToLower();
        //}

        extension(string data)
        {
           public bool IsUpper()
            {
                return data == data.ToUpper();
            }
            public bool IsLower()
            {
                return data == data.ToLower();
            }
        }
        //extension(string data)
        //{
        //    public bool IsLower()
        //    {
        //        return data == data.ToLower();
        //    }
        //}
    }
}
