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
    }
}
