using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest req)
        {
            if (string.IsNullOrWhiteSpace(req?.Username) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest("username and password required");

            var created = _userService.Register(req.Username, req.Password);
            if (!created) return Conflict("user already exists");
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            if (string.IsNullOrWhiteSpace(req?.Username) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest("username and password required");

            if (!_userService.ValidateCredentials(req.Username, req.Password))
                return Unauthorized();

            var key = _configuration["Jwt:Key"] ?? "please-change-this-secret-key-to-a-strong-value";
            var issuer = _configuration["Jwt:Issuer"] ?? "WebApplication1";
            var audience = _configuration["Jwt:Audience"] ?? "WebApplication1";
            var expireMinutes = int.TryParse(_configuration["Jwt:ExpireMinutes"], out var m) ? m : 60;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, req.Username) }),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new AuthResponse { Token = jwt, ExpiresAt = tokenDescriptor.Expires ?? DateTime.UtcNow.AddMinutes(expireMinutes) });
        }
    }
}
