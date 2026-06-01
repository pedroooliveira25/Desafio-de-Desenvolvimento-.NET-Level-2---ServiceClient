using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


public class TokenService : ITokenService
{

    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(Guid userId)
    {
    var key = _configuration["Jwt:Key"]
        ?? throw new Exception("Jwt:Key não configurado no appsettings.json");
    var issuer = _configuration["Jwt:Issuer"]
        ?? throw new Exception("Jwt:Issuer não configurado");;
    var audience = _configuration["Jwt:Audience"]
        ?? throw new Exception("Jwt:Audience não configurado");;

    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, userId.ToString())
    };

    var securityKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(key));

    var credentials = new SigningCredentials(
        securityKey,
        SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
    }
}