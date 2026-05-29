using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDemoConsoleApp1.Entities
{
    [Table("tbl_emp")]
    public class Employee //poco
    {

        // any modifications to entity classess or add new entity classess, or modify the context class, must add-migraion then update-database
        [Key]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [Range(999,9999999)]
        public int Salary { get; set; }
        public string? Designation { get; set; }
        [NotMapped]
        public int Bonus { get; set; }

        public Address Address { get; set; }
        public Project Project { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();
    }

    [ComplexType]
    public class Address
    {
        //public int AddressID { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Area { get; set; }
        [Required]
        public string City { get; set; }
        public string? Country { get; set; }
        public string? Pincode { get; set; }
    }
   
    public class Skill
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }

    abstract public class Project
    {
        public int ProjectID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Client { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class WebProject : Project
    {
        public string WebUrl { get; set; }
    }

    public class MobileProject : Project
    {
        public string Plotform { get; set; } // IOS, Android
    }

    public class DesktopProject : Project
    {
        public string OS { get; set; } //Win, Linux
    }
}
