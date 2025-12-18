using System.ComponentModel.DataAnnotations;

namespace EmployeManagementApi1.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // Store hashed password, no [Required]
        public string Password { get; set; }

        public string Role { get; set; } = Roles.User;
        public decimal? Salary { get; set; }
        public int? YearsOfExperience { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public static class Roles
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
    }
}
