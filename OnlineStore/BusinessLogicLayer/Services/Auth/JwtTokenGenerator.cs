using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BusinessLogicLayer.Services.Auth;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CRM.Business.Auth;

public class JwtTokenGenerator(IOptions<JwtConfig> jwtConfig) : IJwtTokenGenerator
{
    private readonly JwtConfig _jwtConfig = jwtConfig?.Value
        ?? throw new ArgumentNullException(nameof(jwtConfig), "JWT config is not provided.");

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public string CreateAccessToken(
        int userId,
        string userEmail,
        string? userRole)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.Email, userEmail),
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(ClaimTypes.Role, userRole ?? string.Empty)
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            audience: _jwtConfig.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
