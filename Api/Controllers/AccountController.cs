using Appointment.Common;
using Appointment.Domain.BusinessObjects;
using Appointment.Membership.Entities;
using Appointment.Membership.Model;
using Appointment.Membership.Services;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ILifetimeScope _scope;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenGeneratorService _refreshTokenGeneratorService;
        private readonly ITokenRefresher _tokenRefresher;
        public AccountController(ILogger<AccountController> logger, IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
           ILifetimeScope scope, ITokenService tokenService, IRefreshTokenGeneratorService refreshTokenGeneratorService, ITokenRefresher tokenRefresher)
        {
            _userManager = userManager;
            _scope = scope;
            _logger = logger;
            _signInManager = signInManager;

            _configuration = configuration;
            _tokenService = tokenService;
            _refreshTokenGeneratorService = refreshTokenGeneratorService;
            _tokenRefresher = tokenRefresher;
        }

        //private async Task<AuthorizeResponse?> CreateTokenAsync(string? email, string? password)
        //{
        //    if (email != null && password != null)
        //    {

        //        var user = await _userManager.FindByEmailAsync(email);
        //        var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        //        if (result != null && result.Succeeded)
        //        {
        //            var tokenHandler = new JwtSecurityTokenHandler();
        //            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        //            var tokenDescriptor = new SecurityTokenDescriptor
        //            {
        //                Subject = new ClaimsIdentity((await _userManager.GetClaimsAsync(user)).ToArray()),
        //                Issuer = _configuration["Jwt:Issuer"],
        //                Audience = _configuration["Jwt:Audience"],
        //                Expires = DateTime.UtcNow.AddDays(7),
        //                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //            };
        //            var token = tokenHandler.CreateToken(tokenDescriptor);
        //            var RefreshToken = _refreshTokenGeneratorService.GenerateRefreshToken();
               
        //            return new AuthorizeResponse { JwtToken = tokenHandler.WriteToken(token), RefreshToken = RefreshToken };
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        [HttpPost("adminregister")]
        public async Task<ActionResult<UserDto>> AdminRegister()
        {
            var appUser = new ApplicationUser()
            {
                Email = "rezwan.aiub10@gmail.com",
                UserName = "Rezwan",
                PhoneNumber = "01750425444",

            };
            var result = _userManager.CreateAsync(appUser, "Rezwan10*");

            if (!result.Result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                await _userManager.AddToRolesAsync(appUser, new string[] { "Admin" });
                return new UserDto
                {
                    Email = appUser.Email
                };
            }

        }

       

        [HttpPost("login")]
        public async Task<ActionResult<AuthorizeResponse>> Login(LoginDto model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.userName, model.password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");

                        var user = await _userManager.FindByNameAsync(model.userName);
                        var claims = (await _userManager.GetClaimsAsync(user)).ToArray();
                        var token = await _tokenService.GetJwtToken(claims);
                        var refreshToken = await _refreshTokenGeneratorService.GenerateRefreshToken();
                      
                        if(string.IsNullOrEmpty(user.RefreshToken))
                        {
                            user.RefreshToken = refreshToken;
                            await _userManager.UpdateAsync(user);
                        }
                        return new AuthorizeResponse
                        {
                            JwtToken = token,
                            RefreshToken = refreshToken,
                       
                        };
                    }
                    else if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return Unauthorized("User account locked out.");
                    }
                    else
                    {
                        return Unauthorized("");
                    }

                }


                else return Unauthorized("");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto model)
        {
            try
            {

                //var user = await _userManager.FindByNameAsync(loginDto.Email);
                //var role = await _userManager.IsInRoleAsync(user,"Admin");
                //if (user == null) return Unauthorized("");

                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        EmailConfirmed = false,
                        PhoneNumber = model.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(user, new string[] { "Customer" });
                        await _userManager.AddClaimAsync(user, new Claim("AddTask", "true"));

                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                        //var callbackUrl = Url.Action(
                        //"ConfirmEmail",
                        //"Account",
                        //values: new { area = "", userId = user.Id, code = code, returnUrl = model.ReturnUrl },
                        //protocol: Request.Scheme);

                        //_emailService.CreateEmail("Confirm your email", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                        //model.Email, model.Email);
                        //await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                        return new UserDto
                        {
                            Id = user.Id,
                            UserName = user.UserName,

                            Email = user.Email
                        };
                    }
                    else return Unauthorized("");
                }


                else return Unauthorized("");


            }
            catch (Exception ex)
            {

                return Unauthorized("");
            }
        }
        [HttpPost("refresh")]
        public async Task<ActionResult> Refresh(RefreshCred refreshCred)
        {
            var token = await _tokenRefresher.Refresh(refreshCred);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);

        }
    }
}
