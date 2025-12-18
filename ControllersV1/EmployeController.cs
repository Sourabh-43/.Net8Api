using EmployeManagementApi1.DTOs;
using EmployeManagementApi1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagementApi1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/employe")]
    [Authorize]
    public class EmployesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET ALL
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // GET BY ID
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

        // CREATE
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee([FromBody] CreateEmployeeDto dto)
        {
            var employee = _employeeService.AddEmployee(dto);
            return Ok(employee);
        }

        // UPDATE
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDto dto)
        {
            var updated = _employeeService.UpdateEmployee(id, dto);

            if (updated == null)
                return NotFound("Employee not found");

            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployee(int id)
        {
            var success = _employeeService.DeleteEmployee(id);

            if (!success)
                return NotFound("Employee not found");

            return Ok("Employee deleted successfully");
        }
    }
}
