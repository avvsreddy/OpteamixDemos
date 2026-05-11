namespace MyFirstConsoleApp
{
    internal class Program
    {
        // Class Members
            // State - Data
                // Fields/Variables
                // Properties - IMP

            // Behavior - Action
                // Methods - IMP
                // Constructor
                // Destructor - Never Use
                // Events


        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.empNo = 111;
            e.empName = "Sachin";
            e.salary = -890000;
           
        }

       
    }


    class Employee
    {
        public int empNo;
        public string empName;
         double salary;
    }
}
