using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities.IdentityEntities;
using School.Services.Mapping.Dtos.AuthDtos;
using School.Services.Mapping.Dtos.User;
using School.Services.Services.User;
using School.Web.Helper.HandleResponse;

namespace School.Web.Controllers
{
    public class AuthController : BaseController
    {
        #region Injection
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _configuration = configuration;
        }
        #endregion

        #region Login
        [HttpPost]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto input)
        {
            var user = await _userService.Login(input);
            if (user is null)
                return BadRequest(new CustomExeption(400, "Login Error"));

            return Ok(user);

        }
        #endregion

        #region Register
        [HttpPost]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto input)
        {
            var user = await _userService.Register(input);
            if (user is null)
                return BadRequest(new CustomExeption(400, "register Error"));

            return Ok(user);

        }
        #endregion
    }
}
