using EFDemoConsoleApp1.DataAccess;
using EFDemoConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFDemoConsoleApp1.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add new employee with new address
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                Employee e = new Employee {Name = "Ramesh", Designation = "DevOps Engineer", Salary = 67000 };

                Address adr = new Address { City = "Bangalore" };

                e.Address = adr;

                db.Employees.Add(e);
                //db.Addresses.Add(adr); // this is optional
                db.SaveChanges();
                Console.WriteLine("Employee with address saved...");
            }
        }
        private static void Edit()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                // get the object to edit
                var empToEdit = db.Employees.Find(2);
                empToEdit.Salary += 1;
                empToEdit.Designation = "Sr. Developer";
                //db.Employees.Update(empToEdit);
                db.SaveChanges();

            }
        }

        private static void Delete()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                // Get the employee object to delete
                //var emp = (from e in db.Employees
                //           where e.EmployeeId == 1
                //           select e).FirstOrDefault();



                var empToDelete = db.Employees.Find(1);
                if (empToDelete != null)
                {
                    db.Employees.Remove(empToDelete);
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("Employee not found");

            }
        }

        private static void GetAllEmp()
        {
            // get all employees then display

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                // Linq to Entities
                var employees = (from emp in db.Employees
                                 select emp).AsNoTracking().ToList();

                foreach (var employee in db.Employees)
                {
                    Console.WriteLine(employee.Name);
                }
            }
        }
    }
}
