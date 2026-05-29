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
            // add new emp
            Employee e = new Employee { Name = "Ganesh", Salary = 69000, Designation = "Developer" };
            Address adr = new Address { City = "Mysore" };
            e.Address = adr;

            Project p = new WebProject { Name = "Web", WebUrl = "http:sdfsdf.com", Client = "client 1" };
            e.Project = p;

            IEmployeeRepository repo = new EmployeeRepository();
            repo.AddEmployee(e);
            Console.WriteLine("saved");
        }

        private static void RawSQL()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {

                //db.Skills.RemoveRange(db.Skills);
                //db.SaveChanges();

                // delete from skills

                db.Database.ExecuteSqlRaw("delete from skills");

            }
        }

        private static void GetAllMobiles()
        {
            // get all mobile project

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                //var mobileProjects = from mp in db.MobileProjects
                //                     select mp;

                var mobileProjects = from mp in db.Projects.OfType<MobileProject>()
                                     select mp;

                foreach (var project in mobileProjects)
                {
                    Console.WriteLine(project.Name);
                }

            }
        }

        private static void AddProjects()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var mp = new MobileProject { Name = "Mobile Project 1", Client = "Google", Plotform = "Android" };
                var wp = new WebProject { Name = "Web Project 1", Client = "Govt of India", WebUrl = "www.india.gov.in" };
                var dp = new DesktopProject { Name = "Desktop Project 1", Client = "Microsoft", OS = "Windows" };

                //db.Projects.Add(mp);
                //db.Projects.Add(wp);
                //db.Projects.Add(dp);

                db.MobileProjects.Add(mp);
                db.WebProjects.Add(wp);
                db.DesktopProjects.Add(dp);

                db.SaveChanges();
            }
        }

        private static void EgarLoading()
        {
            // get employee data then display name and city
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var employees = from e in db.Employees //.Include("Address") //.Include("Projects") //.Include(e=>e.Address)
                                select e;

                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"{employee.Name} \t {employee.Address.City}");
                }
            }
        }

        private static void Add()
        {
            // Add new employee with new address
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                Employee e = new Employee { Name = "Somesh", Designation = "DevOps Engineer", Salary = 67000 };

                Address adr = new Address { City = "Chennai" };

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
