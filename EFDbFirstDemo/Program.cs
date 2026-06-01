namespace EFDbFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // step 1: install ef and setup
            // step 2: identify the existing db and tables, if not then create manually
            // step 3: scaffold the dbcontext - EF will generate all required entity classes and dbcontext class 


            // Scaffold-DbContext -connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OpteamixProductsDb;Integrated Security=True" -Provider "Microsoft.EntityFrameworkCore.SqlServer" -OutputDir "DataLayer"
        }
    }
}
