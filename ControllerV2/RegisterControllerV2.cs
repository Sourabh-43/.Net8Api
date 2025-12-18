using EmployeManagementApi1.Data;
using EmployeManagementApi1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/register")]
public class RegisterControllerV2 : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RegisterControllerV2(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegisterV2(RegisterV2Dto dto)
    {
        var user = new AppUser
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Password = dto.Password,
            Role = "User",
            Salary = dto.Salary,
            YearsOfExperience = dto.YearsOfExperience
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User registered successfully (V2).");
    }
}
