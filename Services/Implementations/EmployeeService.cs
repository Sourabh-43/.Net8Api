using EmployeManagementApi1.Data;
using EmployeManagementApi1.DTOs;
using EmployeManagementApi1.Models;
using EmployeManagementApi1.Services.Interfaces;
using AutoMapper;

namespace EmployeManagementApi1.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;   //  Added AutoMapper

        //  Updated constructor to inject AutoMapper
        public EmployeeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee AddEmployee(CreateEmployeeDto dto)
        {
            
            // var employee = new Employee
            // {
            //     Name = dto.Name,
            //     Age = dto.Age,
            //     Department = dto.Department
            // };

            //  (AutoMapper)
            var employee = _mapper.Map<Employee>(dto);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public Employee? UpdateEmployee(int id, UpdateEmployeeDto dto)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return null;

            
            // employee.Name = dto.Name;
            // employee.Age = dto.Age;
            // employee.Department = dto.Department;

            // (AutoMapper updates existing entity)
            _mapper.Map(dto, employee);

            _context.SaveChanges();
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
