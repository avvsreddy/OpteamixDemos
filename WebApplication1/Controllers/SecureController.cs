using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public() => Ok(new { message = "This endpoint is public" });

        [Authorize]
        [HttpGet("private")]
        public IActionResult Private()
        {
            var user = User?.Identity?.Name ?? "unknown";
            return Ok(new { message = $"Hello {user}, this is a protected endpoint" });
        }
    }
}
