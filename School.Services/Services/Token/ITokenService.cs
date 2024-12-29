using School.Data.Entities.IdentityEntities;

namespace School.Services.Services.Token
{
    public interface ITokenService
    {
        string GenerateUserToken(AppUser user);

    }
}
