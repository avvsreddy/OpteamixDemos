using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoConsoleApp1.Entities
{
    public class Employee //poco
    {

        // any modifications to entity classess or add new entity classess, or modify the context class, must add-migraion then update-database
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
    }
}
