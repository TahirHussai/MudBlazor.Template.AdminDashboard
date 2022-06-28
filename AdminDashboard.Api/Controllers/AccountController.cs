using AdminDashboard.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger, IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = configuration;
            _logger = logger;


        }

        [Route("register")]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegistrationModel userDTO)
        {
            var location = GetControllerActionName();
            try
            {
                var username = userDTO.EmailAddress;
                var password = userDTO.Password;
                _logger.LogInformation($"Registration Attempt for {username} ");
                var user = new IdentityUser { Email = username, UserName = username };
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError($"{error.Code} {error.Description}");
                    }
                    return InternalError($"{location}:{username} User Registration Attempt Failed");
                }
                await _userManager.AddToRoleAsync(user, userDTO.UserRole);
                return Created("login", new { result.Succeeded });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Some thing went wrong please contact to administrator");
            }
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel dto)
        {
            var location = GetControllerActionName();
            try
            {
                var username = dto.EmailAddress;
                var password = dto.Password;
                _logger.LogInformation($"{location}: Login Attempt from user {username} ");
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"{location}: {username} Successfully Authenticated");
                    var user = await _userManager.FindByEmailAsync(username);
                    return Ok();
                }
                _logger.LogInformation($"{location}: {username} Not Authenticated");
                return Unauthorized(dto);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        private string GetControllerActionName()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller}-{action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);

            return StatusCode(500, "Some thing went wrong please contact to administrator");
        }
    }
}
