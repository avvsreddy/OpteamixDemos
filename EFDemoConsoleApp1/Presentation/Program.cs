using EFDemoConsoleApp1.DataAccess;
using EFDemoConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFDemoConsoleApp1.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Want to add new employee into database table

            // Step 1: DAL Tech Stack - EF Core
            // Step 2: DB Server? - MS SQL Server
            // Step 3: Approach? Code First
            // Step 4: Setup/Install EF Core - Done
            // Step 5: Create Required Code - Entity Classes and Configuration Class
            // Step 6: Do Data Migraions - Auto Generates tables
            // Step 7: Perform CRUD Operation using EF Core

            // write only oo code to perform CRUD operations with database
            // add new employee
            //Employee employee = new Employee {Name = "Sachin", Designation = "Batsman", Salary = 999999 };

            //List<Employee> employees = new List<Employee>();
            //employees.Add(new Employee { Name="Ramesh", Designation = "Developer", Salary=75000 });
            //employees.Add(new Employee { Name = "Girish", Designation = "Developer", Salary = 75000 });
            //employees.Add(new Employee { Name = "Somesh", Designation = "Tester", Salary = 75000 });
            //employees.Add(new Employee { Name = "Suresh", Designation = "Developer", Salary = 75000 });
            //employees.Add(new Employee { Name = "Mahesh", Designation = "UI Developer", Salary = 75000 });
            //employees.Add(new Employee { Name = "Ratnesh", Designation = "Developer", Salary = 75000 });
            //employees.Add(new Employee { Name = "Ganesh", Designation = "Backend Developer", Salary = 75000 });

            Employee e1 = new Employee { Name = "Ramesh1", Designation = "Developer", Salary = 75000 };
            Employee e2 = new Employee { Name = "Ramesh2", Designation = "Developer", Salary = 75000 };
            Employee e3 = new Employee { Name = "Ramesh3", Designation = "Developer", Salary = 75000 };

            EmployeeDbContext db = new EmployeeDbContext();
            db.Employees.Add(e1);
            db.Employees.Add(e2);
            db.Employees.Add(e3);
            //db.Employees.AddRange(employees);
            db.SaveChanges();


        }
    }
}
