using System;
using SimpleCalculator.BusinessLogic; // to use the Calculator class from the Business layer
namespace SimpleCalculator.ConsoleApp
{

    internal class Program // SRP
    {
        static void Main(string[] args) //UI Logic - SRP - Single Responsibility Principle
        {
            // Accept two int values from the user, find the sum and display the result.

            // step 1: accept two int values from the user
            int fno, sno, result;

            Console.Write("Enter First Number: ");
            fno = int.Parse(System.Console.ReadLine());
            Console.Write("Enter Second Number: ");
            sno = int.Parse(System.Console.ReadLine());

            // step 2: find the sum
            // result = fno + sno; // BL - Business Logic - SRP - Single Responsibility Principle
            result = Calculator.Add(fno, sno); // BL - Business Logic - SRP - Single Responsibility Principle
            // step 3: display the result
            //Console.WriteLine(result);
            Console.WriteLine($"The sum of {fno} and {sno} is {result}");
        }

    }
}
