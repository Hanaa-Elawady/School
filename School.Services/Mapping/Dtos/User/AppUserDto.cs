namespace School.Services.Mapping.Dtos.User
{
    public class AppUserDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
