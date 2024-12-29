using School.Services.Mapping.Dtos.AuthDtos;
using School.Services.Mapping.Dtos.User;

namespace School.Services.Services.User
{
    public interface IUserService
    {
        Task<AppUserDto> Login(LoginDto input);
        Task<AppUserDto> Register(RegisterDto input);

    }
}
