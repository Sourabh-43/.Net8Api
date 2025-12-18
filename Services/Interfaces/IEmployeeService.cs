using EmployeManagementApi1.DTOs;
using EmployeManagementApi1.Models;
using System.Collections.Generic;

namespace EmployeManagementApi1.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        Employee AddEmployee(CreateEmployeeDto dto);
        Employee? UpdateEmployee(int id, UpdateEmployeeDto dto);
        bool DeleteEmployee(int id);
    }
}
