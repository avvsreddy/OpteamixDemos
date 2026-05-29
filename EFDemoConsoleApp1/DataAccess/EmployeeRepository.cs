using EFDemoConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoConsoleApp1.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EmployeeDbContext db = null;

        public EmployeeRepository()
        {
            db = new EmployeeDbContext();
        }

        public EmployeeRepository(EmployeeDbContext db)
        {
            this.db = db;
        }

        public void AddEmployee(Employee employee)
        {
           db.Employees.Add(employee);
           db.SaveChanges();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
        }

        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await db.Employees.FindAsync(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges ();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
        }
    }
}
