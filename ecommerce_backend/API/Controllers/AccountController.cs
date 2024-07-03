using API.Dtos;
using API.EmailSetting;
using API.Errors;
using Core.Entities.IdentityEntities;
using Core.Interfaces.EmailSetting;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IEmailSettings _emailSettings;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IAuthService authService, IEmailSettings emailSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _emailSettings = emailSettings;
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto model)
        {
            if (CheckEmailExist(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This email has already been used" } });

            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded is false)
                return BadRequest(new ApiResponse(400));

            return Ok(new AppUserDto
            {
                DisplayName = user.DisplayName,
                Email = model.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
                return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded is false)
                return Unauthorized(new ApiResponse(401));

            return Ok(new AppUserDto
            {
                DisplayName = user.DisplayName,
                Email = model.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }


        [HttpPost]
        public async Task<ActionResult> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return NotFound(new ApiResponse(404));

            Email emailToSend = new Email()
            {
                To = user.Email,
                Subject = "Change Password",
                Body = "This is link"
            };

            try
            {
                _emailSettings.SendEmail(emailToSend);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return Ok(emailToSend);
        }
    }
}