using AutoMapper;
using School.Data.Entities.IdentityEntities;
using School.Services.Mapping.Dtos.AuthDtos;
using School.Services.Mapping.Dtos.User;

namespace School.Services.Mapping.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser , AppUserDto>().ReverseMap();

            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => getNameFromEmail(src.Email)));

        }
        private string getNameFromEmail(string Email)
        {
            return Email.Split("@")[0];
        }
    }
}
