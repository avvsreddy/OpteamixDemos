namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is a simple demonstration of exception handling in C#.

            // Accept two even integer inputs from the user and perform addition, then display the result. then save the data,  repeat the process until the user decides to exit.
            while (true)
            {
                try
                {
                    int fno, sno, sum;
                    // open db connection
                    Console.Write("Enter the first number:");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second number:");
                    sno = int.Parse(Console.ReadLine());
                    // perform some CRUD operations on the database
                    Calculator calc = new Calculator();
                    sum = calc.Add(fno, sno);
                    Console.WriteLine("The sum is: " + sum);
                    // read some data from the database and display it
                    // close the db connection

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter valid integers.");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("The number is too large or too small.");
                }
                catch (InvalidEvenNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) // Catch any other unexpected exceptions
                {
                    //if(ex is FormatException) {
                    //    Console.WriteLine("Please enter valid integers.");
                    //}
                    //else if(ex is OverflowException) {
                    //    Console.WriteLine("The number is too large or too small.");
                    //}
                    //else {
                    //    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    //}

                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }

                finally 
                {
                    // This block will always execute, regardless of whether an exception was thrown or not.
                    // You can use this block to perform any cleanup or final actions
                    // close the resource, 
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Calculator
    {
        // This method adds two even integers and returns the result. If either of the numbers is odd, it throws an InvalidEvenNumberException.

        /// <summary>
        /// This method adds two even integers and returns the result. If either of the numbers is odd, it throws an InvalidEvenNumberException.
        /// </summary>
        /// <param name="a">int even parameter 1</param>
        /// <param name="b">int evenparameter 2</param>
        /// <returns>the sum of the two even numbers</returns>
        /// <exception cref="InvalidEvenNumberException"></exception>
        public int Add(int a, int b)
        {
            if(a % 2 != 0 || b % 2 != 0)
            {
                throw new InvalidEvenNumberException("Both numbers must be even.");
            }
            CalculatorRepository repo = new CalculatorRepository();
            repo.SaveResult($"Added {a} and {b} to get {a + b}");
            return a + b;
        }
    }

    class InvalidEvenNumberException : ApplicationException
    {
        //public InvalidEvenNumberException()
        //{
            
        //}
        //public InvalidEvenNumberException(string msg) : base(msg) 
        //{
            
        //}
        public InvalidEvenNumberException(string msg=null, Exception innerExp=null) : base(msg, innerExp)
        {
            
        }
    }

    /// <summary>
    /// Saves the calculator results to a file. This class is responsible for handling all file operations related to the calculator, such as inserting new records, updating existing records, and retrieving data for display.
    /// </summary>
    public class CalculatorRepository
    {
        public bool SaveResult(string result)
        {
            try
            {
                // Code to save the result to a file or database
                StreamWriter sw = new StreamWriter("a:/calculator_results.txt", true);
                sw.WriteLine(result);
                sw.Close();
              
            }
            catch (Exception ex)
            {
                // Convert the exception to a custom exception if needed
                ResultNotSavedException customEx = new ResultNotSavedException("Failed to save the result.", ex);
                // log the exception or perform any necessary actions

                // nLog
                // log4net
                // Serilog

                // must rethrow the exception to be handled by the calling code
                throw customEx;
            }

            return true;
        }
    }

    public class  ResultNotSavedException : ApplicationException
    {
        public ResultNotSavedException(string msg = null, Exception innerExp = null) : base(msg, innerExp)
        {
            
        }
    }
}
