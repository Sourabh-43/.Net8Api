using EmployeManagementApi1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagementApi1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ONLY ADMIN can promote another user
        [Authorize(Roles = "Admin")]
        [HttpPost("make-admin/{id}")]
        public IActionResult MakeAdmin(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound("User not found");

            if (user.Role == "Admin")
                return BadRequest("User is already an Admin");

            user.Role = "Admin";
            _context.SaveChanges();

            return Ok("User promoted to Admin successfully");
        }
    }
}
