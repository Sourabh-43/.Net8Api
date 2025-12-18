using EmployeManagementApi1.Data;
using EmployeManagementApi1.DTOs;
using EmployeManagementApi1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagementApi1.ControllersV1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/register")]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already exists.");

            var user = new AppUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,   
                Role = AppUser.Roles.User
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { Message = "User registered successfully (v1).", UserId = user.Id });
        }
    }
}
