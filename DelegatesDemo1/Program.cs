namespace DelegatesDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Greeting("Welcome to Delegates in C#!"); // Direct method call

            //Delegate dObj = new Delegate(); // Creating a delegate instance
            // Step 2: Delegate instantiation - Create an instance of the delegate, pointing to the method you want to call.
            Program p = new Program(); // Creating an instance of the Program class to access instance methods if needed
            MyDelegate dObj = new MyDelegate(p.Hello); // Creating a delegate instance and pointing it to the Greeting method
            dObj += Greeting; // Adding another method to the delegate invocation list (multicast delegate)
            dObj -= p.Hello; // Removing the instance method from the delegate invocation list

            // step 3: Delegate invocation - Invoke the delegate, which will call the method it points to.
            //dObj.Invoke("Hello from the delegate!"); // Invoking the delegate to call the Greeting method
            dObj("Using the shorthand syntax to invoke the delegate"); // Using the shorthand syntax to invoke the delegate
        }

        public static void Greeting(string text) 
        {
            Console.WriteLine($"Greeting: {text}");
        }

        public void Hello(string str) 
        {
            Console.WriteLine($"Hello: {str}");
        }
    }

    //public class MyDelegate : Delegate
    //{
    //    // Custom implementation of the delegate can be added here
    //}

    // Step 1: Delegate declaration - Define a delegate type that matches the signature of the method you want to call.
    public delegate void MyDelegate(string text);

}
