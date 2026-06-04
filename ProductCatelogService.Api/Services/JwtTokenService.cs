namespace ProductCatelogService.Api.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username)
        {
            //var jwtSettings = _configuration.GetSection("Jwt");

            //var key = new SymmetricSecurityKey(
            //    Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("ThisIsMySecretKey123456789fsdfsdfsdfljdfdfjdfdfker3redfdsfsdfeweqredfgdfgdfgrgqertegdgsdgdfg"));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
            //new Claim(ClaimTypes.Role, "Admin")
        };

            //var token = new JwtSecurityToken(
            //    issuer: jwtSettings["Issuer"],
            //    audience: jwtSettings["Audience"],
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddMinutes(
            //        Convert.ToInt32(jwtSettings["ExpiryMinutes"])),
            //    signingCredentials: credentials
            //);

            var token = new JwtSecurityToken(
                issuer: "Opteamix-AuthServer",
                audience: "Opteamix-Api-Clients",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToInt32("60")),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
