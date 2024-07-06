using API.Dtos;
using API.EmailSetting;
using API.Errors;
using Core.Entities.IdentityEntities;
using Core.Interfaces.EmailSetting;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IEmailSettings _emailSettings;
        private readonly IdentityContext _identityContext;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IAuthService authService, IEmailSettings emailSettings, IdentityContext identityContext,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _emailSettings = emailSettings;
            _identityContext = identityContext;
            _logger = logger;
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto model)
        {
            if (model is null)
                return BadRequest(new ApiResponse(400, "Invalid registration data."));

            if (!IsValidEmail(model.Email))
                return BadRequest(new ApiResponse(400, "Invalid email format."));

            if (await CheckEmailExist(model.Email))
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
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                return BadRequest(new ApiValidationErrorResponse { Errors = errors });
            }

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(new AppUserDto
            {
                DisplayName = user.DisplayName,
                Email = model.Email,
                Token = token
            });
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto model)
        {
            if (model is null)
                return BadRequest(new ApiResponse(400, "Invalid login data."));

            if (!IsValidEmail(model.Email))
                return BadRequest(new ApiResponse(400, "Invalid email format."));

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
                return Unauthorized(new ApiResponse(401, "Invalid email or password."));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded is false)
                return Unauthorized(new ApiResponse(401, "Invalid email or password."));

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(new AppUserDto
            {
                DisplayName = user.DisplayName,
                Email = model.Email,
                Token = token
            });
        }

        [HttpGet("forgetpassword")]
        public async Task<ActionResult> ForgetPassword(string email)
        {
            if (!IsValidEmail(email))
                return BadRequest(new ApiResponse(400));

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return NotFound(new ApiResponse(404));

            var code = GenerateSecureCode();

            Email emailToSend = new Email()
            {
                To = email,
                Subject = "Reset Your Password",
                Body = EmailBody(code, user.UserName)
            };

            try
            {
                await _identityContext.IdentityCodes.AddAsync(new IdentityCode()
                {
                    Code = HashCode(code),
                    AppUserId = user.Id
                });

                await _identityContext.SaveChangesAsync();

                await _emailSettings.SendEmailMessage(emailToSend);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while sending password reset email.");
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request."));
            }

            return Ok(new ApiResponse(200, "Password reset email sent successfully."));
        }

        [HttpPost("VerifyResetCode")]
        public async Task<ActionResult> VerifyResetCode(string email, string code)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                return BadRequest(new ApiResponse(400));

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return NotFound(new ApiResponse(404));

            var identityCode = await _identityContext.IdentityCodes.Where(P => P.AppUserId == user.Id).OrderBy(d => d.CreationTime).LastOrDefaultAsync();

            if (identityCode is null)
                return BadRequest(new ApiResponse(400, "No valid reset code found."));
            
            if (identityCode.IsActive)
                return BadRequest(new ApiResponse(400, "You already have an active code."));

            var lastCode = identityCode.Code;

            if(lastCode != HashCode(code) || identityCode.CreationTime.Minute + 1 < DateTime.UtcNow.Minute)
                return BadRequest(new ApiResponse(400, "This code has expired."));

            if(!ConstantTimeComparison(lastCode, HashCode(code)))
                return BadRequest(new ApiResponse(400, "Invalid reset code."));

            identityCode.IsActive = true;
            _identityContext.IdentityCodes.Update(identityCode);
            await _identityContext.SaveChangesAsync();

            return Ok(new ApiResponse(200, "Code verified successfully."));
        }

        [HttpPost("changepassword")]
        public async Task<ActionResult> ChangePassword(string email, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                return BadRequest(new ApiResponse(400));

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return NotFound(new ApiResponse(404));

            var identityCode = await _identityContext.IdentityCodes.Where(P => P.AppUserId == user.Id).OrderBy(d => d.CreationTime).LastOrDefaultAsync();

            if (identityCode is null)
                return BadRequest(new ApiResponse(400, "No valid reset code found."));

            if (!identityCode.IsActive)
                return BadRequest(new ApiResponse(400, "This code has expired."));

            using var transaction = await _identityContext.Database.BeginTransactionAsync();

            try
            {
                identityCode.IsActive = false;
                _identityContext.IdentityCodes.Update(identityCode);
                await _identityContext.SaveChangesAsync();

                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (!removePasswordResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new ApiResponse(400, "Failed to remove the old password."));
                }

                var addPasswordResult = await _userManager.AddPasswordAsync(user, newPassword);
                if (!addPasswordResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new ApiResponse(400, "Failed to set the new password."));
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                _logger.LogError(ex, "Error occurred while changing password.");
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request."));
            }

            return Ok(new ApiResponse(200, "Password changed successfully."));
        }

        private async Task<bool> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        private string EmailBody(string code, string userName)
        {
            return $@"
                <html>
                <head>
                    <style>
                        .email-container {{
                            font-family: Arial, sans-serif;
                            color: #333333;
                            line-height: 1.5;
                        }}
                        .header {{
                            background-color: #f7f7f7;
                            padding: 20px;
                            text-align: center;
                            border-bottom: 1px solid #dddddd;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .code {{
                            font-size: 24px;
                            color: #2c3e50;
                            font-weight: bold;
                        }}
                        .footer {{
                            background-color: #f7f7f7;
                            padding: 10px;
                            text-align: center;
                            border-top: 1px solid #dddddd;
                            font-size: 12px;
                            color: #777777;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-container'>
                        <div class='header'>
                            <h1>Reset Your Password</h1>
                        </div>
                        <div class='content'>
                            <p>Dear {userName},</p>
                            <p>You have requested to reset your password. Please use the following code to complete the process:</p>
                            <p class='code'>{code}</p>
                            <p>This code is valid for 30 minutes.</p>
                            <p>If you did not request a password reset, please ignore this email or contact support if you have any concerns.</p>
                            <p>Thank you,<br/>TwoAxis</p>
                        </div>
                        <div class='footer'>
                            <p>&copy; 2024 TwoAxis. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>";
        }
        
        private string GenerateSecureCode()
        {
            byte[] randomNumber = new byte[4];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            int result = BitConverter.ToInt32(randomNumber, 0);
            int positiveResult = Math.Abs(result);

            int sixDigitCode = positiveResult % 1000000;
            return sixDigitCode.ToString("D6");
        }
        
        private string HashCode(string code)
        {
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
        
        private bool ConstantTimeComparison(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }
    }
}