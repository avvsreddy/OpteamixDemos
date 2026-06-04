using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProductCatelogService.Api.Services;

namespace ProductCatelogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(TokenService tokenService, UserManager<IdentityUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        // POST: http://localhost:5000/api/auth/login

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //if (request.Email == "admin" &&
            //    request.Password == "password")


            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return Unauthorized();

            bool validPassword =
                await _userManager.CheckPasswordAsync(
                    user,
                    request.Password);

            if (!validPassword)
                return Unauthorized();

            var token =
                _tokenService.GenerateToken(request.Email);

            return Ok(new
            {
                Token = token
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(
    RegisterRequest model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User created");
        }
    }
}
