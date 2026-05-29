using EFDemoConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoConsoleApp1.DataAccess
{
    public class EmployeeDbContext : DbContext
    {

        // Configure Database

        // use ctor
        // override onconfiguring()

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Initial Catalog=OpteamixEmpDb").LogTo(Console.WriteLine,LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API Syntax
            //modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
            //modelBuilder.Entity<Employee>().Property(e => e.Name).HasColumnName("EmpName").HasMaxLength(100);

            //modelBuilder.Entity<Project>().UseTphMappingStrategy(); // default - 

                    
            //modelBuilder.Entity<Project>().UseTptMappingStrategy(); // dont use it

            modelBuilder.Entity<Project>().UseTpcMappingStrategy(); // best

        }

        // Map Entity Classes with Tables
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<DesktopProject> DesktopProjects { get; set; }
        public DbSet<WebProject> WebProjects { get; set; }
        public DbSet<MobileProject> MobileProjects { get; set; }
    }
}
