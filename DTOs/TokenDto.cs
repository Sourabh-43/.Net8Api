using System.ComponentModel.DataAnnotations;

namespace EmployeManagementApi1.DTOs
{
    public class TokenDto
    {
        [Required(ErrorMessage = "Refresh token is required")]
        public string RefreshToken { get; set; }
    }
}
