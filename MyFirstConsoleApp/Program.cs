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
            var a = 10.5;
            var str = "sdfsdfdsfsdf";
            var d =10;

            for (var i = 0; i < 10; i++)
            {

            }


            //Employee e = new Employee();
            ////e.empNo = 111;
            //Console.WriteLine(e.EmpNo);
            //e.EmpName = "Sachin";
            ////e.salary = -890000;
            //e.SetSalary(100000);
            //e.Salary = 5000;
            //double sal = e.GetSalary();
            //sal = e.Salary;
           

            Product p1 = new Product(); // Object Instantiation
            // Initialize
            p1.ProductId = 111;
            p1.Name = "I Phone";
            p1.Price = 90000;


            // Object Initialization Syntax
            //Product p2 = new Product(1,"I Phone", 75000);
            var p2 = new  { ProductId=1, Name= "I Phone", Price=75000 };

            p2.Price = 10;
            Console.WriteLine(p2.Price);

            Product p3 = new Product { ProductId =123 };
            Product p4 = new Product { ProductId = 123, Price=50000 };

            Console.WriteLine(p1.Price);
        }

       
    }


    class Employee
    {
        //private int empNo;
        private int backingfield_24234234234234234;
        private string empName;
        private string fname;
        private string lname;
        private double salary; // backing field
        //private string designation;
        // Camel Casing : employeeName
        // Pascal Casing : EmployeeName

        public string Designation { get; private set; }
        public string FirstName { get; set; }
        public int EmpNo // Automatic Properties
        {
            get
            {
                return backingfield_24234234234234234;
            }
            set
            {
                backingfield_24234234234234234 = value;
            }
        }

        public string EmpName
        {
            get;// { return empName; }
            set;// { empName = value; }
        }

        // Property
        public double Salary 
        {
            get 
            {
                return this.salary;
            }
            set
            {
                if (value < 10000)
                {
                    this.salary = 10000;
                }
                else
                {
                    this.salary = value;
                }
            }
        }
        public void SetSalary(double salary) 
        {
            if (salary < 10000)
            {
                this.salary = 10000;
            }
            else
            {
                this.salary = salary;
            }
        }
        
        public double GetSalary() 
        {
            return this.salary;
        }
    }

    //class Product // Entity Classess
    //{
    //    public int ProductId { get; set; }
    //    public string Name { get; set; }
    //    public double Price { get; set; }

    //    //public Product()
    //    //{
            
    //    //}
    //    //public Product(int id=0, string name=null, double price=0.0)  //: this(id,price)
    //    //{
    //    //    ProductId = id;
    //    //    Price = price;
    //    //    Name = name;
    //    //}

    //    //public Product(int id)
    //    //{
    //    //    ProductId = id;
    //    //}

    //    //public Product(int id, double price): this(id)
    //    //{
    //    //    //ProductId = id;
    //    //    Price = price;
    //    //}
    //}
}
