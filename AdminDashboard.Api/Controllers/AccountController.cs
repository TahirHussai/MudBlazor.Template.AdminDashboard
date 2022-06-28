using AdminDashboard.Api.Data;
using AdminDashboard.Api.Models;
using AdminDashboard.Api.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ILogger<AccountController> logger;
        public AccountController(ILogger<AccountController> logger, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            this.logger = logger;

            this.userManager = userManager;
            this.configuration = configuration;
        }

        [Route("register")]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegistrationModel userDTO)
        {
            logger.LogInformation($"Registration Attempt for {userDTO.EmailAddress} ");
            try
            {
                ApiUser user = new ApiUser();
                user.Email = userDTO.EmailAddress;
                user.PasswordHash = userDTO.Password;
                user.FirstName = userDTO.FirstName==null?" ": userDTO.FirstName;
                user.LastName = userDTO.LastName==null?" ": userDTO.LastName;
                user.ProfilePicture = userDTO.ProfilePicture;
                user.UserName= userDTO.EmailAddress;

                var result = await userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, userDTO.UserRole);
                return Accepted();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseModel>> Login(LoginModel dto)
        {
            var location = GetControllerActionName();
            try
            {
                var response = new ResponseModel();
                var username = dto.EmailAddress;
                var password = dto.Password;
                logger.LogInformation($"{location}: Login Attempt from user {username} ");
                var user = await userManager.FindByEmailAsync(username);
                var passwordValid = await userManager.CheckPasswordAsync(user, dto.Password);

                if (user == null || passwordValid == false)
                {
                     response = new ResponseModel
                    {
                        Email = dto.EmailAddress,
                        Token = "",
                        IsSuccess = false,
                        ResponseMessage = "Ivalid!"
                    };
                    return response;
                }
                string tokenString = await GenerateToken(user);

                 response = new ResponseModel
                {
                    Email = dto.EmailAddress,
                    Token = tokenString,
                    UserId = user.Id,
                    IsSuccess=true,
                    ResponseMessage="Success"
                };
                return response;
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        private async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToInt32(configuration["JwtSettings:Duration"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GetControllerActionName()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller}-{action}";
        }

        private ObjectResult InternalError(string message)
        {
            logger.LogError(message);

            return StatusCode(500, "Some thing went wrong please contact to administrator");
        }
    }
}
