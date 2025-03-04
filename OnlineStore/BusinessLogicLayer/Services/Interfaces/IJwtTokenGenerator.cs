namespace BusinessLogicLayer.Services.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateRefreshToken();
    string CreateAccessToken(int userId, string userName, string? userRole);
}
