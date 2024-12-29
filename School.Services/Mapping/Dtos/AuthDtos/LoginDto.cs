using System.ComponentModel.DataAnnotations;

namespace School.Services.Mapping.Dtos.AuthDtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, one non-alphanumeric character, and must be at least 6 characters long.")]

        public string Password { get; set; }
    }
}
