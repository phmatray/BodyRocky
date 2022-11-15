using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared;
using BodyRocky.Shared.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BodyRocky.Back.Server.Controllers
{
    [Route("authorize/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            ILogger<AuthorizeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByEmailAsync(parameters.Email);
            if (user == null)
            {
                _logger.LogWarning("Login failed for {0}", parameters.Email);
                return BadRequest("User does not exist");
            }
            
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!signInResult.Succeeded)
            {
                _logger.LogWarning("Login failed for {0}", parameters.Email);
                return BadRequest("Invalid password");
            }

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new Customer
            {
                UserName = parameters.Email.Split("@").First(),
                Email = parameters.Email,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName
            };

            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            return await Login(new LoginParameters
            {
                Email = parameters.Email,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<UserInfo> UserInfo()
        {
            // var user = await _userManager.GetUserAsync(HttpContext.User);
            return BuildUserInfo();
        }


        private UserInfo BuildUserInfo()
        {
            return new UserInfo
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}