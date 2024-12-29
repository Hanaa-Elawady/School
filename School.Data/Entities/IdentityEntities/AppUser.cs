using Microsoft.AspNetCore.Identity;

namespace School.Data.Entities.IdentityEntities
{
    public class AppUser :IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
