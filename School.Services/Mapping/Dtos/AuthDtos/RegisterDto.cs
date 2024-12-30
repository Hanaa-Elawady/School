using System.ComponentModel.DataAnnotations;

namespace School.Services.Mapping.Dtos.AuthDtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, one non-alphanumeric character, and must be at least 6 characters long.")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "passwords Not Matching")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^(010|015|011)[0-9]{8}$", ErrorMessage = "Not Valid Number")]
        public string PhoneNumber { get; set; }
    }
}
