using EFDemoConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoConsoleApp1.DataAccess
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);

        List<Employee> GetAllEmployees();

        void UpdateEmployee(Employee employee);



        // Async Methods

        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(int id);

        Task<List<Employee>> GetAllEmployeesAsync();

        Task UpdateEmployeeAsync(Employee employee);

    }
}
