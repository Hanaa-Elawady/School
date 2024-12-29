using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using School.Data.Entities.IdentityEntities;
using School.Services.Mapping.Dtos.AuthDtos;
using School.Services.Mapping.Dtos.User;
using School.Services.Services.Token;


namespace School.Services.Services.User
{

    public class UserService :IUserService
    {
        #region Dependancy Injection
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper ,SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenService tokenService , IConfiguration configuration)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }   
        #endregion

        #region Login
        public async Task<AppUserDto> Login(LoginDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
                throw new Exception("User Not Found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            if (!result.Succeeded)
                throw new Exception("LoginError");

            var mappedUser = _mapper.Map<AppUserDto>(user);
            mappedUser.Token = _tokenService.GenerateUserToken(user);
            return mappedUser;

        }
        #endregion

        #region Register 
        public async Task<AppUserDto> Register(RegisterDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user is not null)
                throw new Exception("Email Already exist");

            var appUser = _mapper.Map<AppUser>(input);

            var result = await _userManager.CreateAsync(appUser,input.Password);
            if (!result.Succeeded)
                throw new Exception("Register Error");

            var mappedUser = _mapper.Map<AppUserDto>(appUser);
            return mappedUser;
        }
        #endregion

    }
}
