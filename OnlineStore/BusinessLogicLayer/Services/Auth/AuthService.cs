using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer.Services.Auth;

public class AuthService(
    IJwtTokenGenerator jwtTokenGenerator,
    IRepository<User> userRepository,
    IMapper mapper
) : IAuthService
{
    private async Task<User> FindUserByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        return users.FirstOrDefault(u => u.Username == username)
            ?? throw new UnauthorizedAccessException("Invalid credentials");
    }

    private string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    private string HashPassword(string password, string salt)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = password + salt;
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        return Convert.ToBase64String(hashedBytes);
    }

    private bool VerifyPassword(string password, string storedHash, string salt)
    {
        var hashedPassword = HashPassword(password, salt);
        return hashedPassword == storedHash;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
    {
        var user = await FindUserByUsernameAsync(loginDto.Username, cancellationToken);

        if (!VerifyPassword(loginDto.Password, user.Password, user.Password_Salt))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var accessToken = jwtTokenGenerator.CreateAccessToken(
            user.Id,
            user.Username,
            null
        );

        var refreshToken = jwtTokenGenerator.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.UpdatedDate = DateTime.UtcNow;
        await userRepository.UpdateAsync(user, cancellationToken);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            UserId = user.Id
        };
    }

    public async Task LogoutAsync(int userId, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new KeyNotFoundException("User not found");

        user.RefreshToken = null;
        user.UpdatedDate = DateTime.UtcNow;
        await userRepository.UpdateAsync(user, cancellationToken);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        var user = users.FirstOrDefault(u => u.RefreshToken == refreshToken)
            ?? throw new UnauthorizedAccessException("Invalid refresh token");

        var newAccessToken = jwtTokenGenerator.CreateAccessToken(
            user.Id,
            user.Username,
            null
        );

        var newRefreshToken = jwtTokenGenerator.GenerateRefreshToken();
        user.RefreshToken = newRefreshToken;
        user.UpdatedDate = DateTime.UtcNow;
        await userRepository.UpdateAsync(user, cancellationToken);

        return new AuthResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            UserId = user.Id
        };
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken = default)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        if (users.Any(u => u.Username == registerDto.Username))
        {
            throw new InvalidOperationException("User with this username already exists");
        }

        var user = mapper.Map<User>(registerDto);
        user.Password_Salt = GenerateSalt();
        user.Password = HashPassword(registerDto.Password, user.Password_Salt);
        user.CreatedDate = DateTime.UtcNow;
        user.UpdatedDate = DateTime.UtcNow;
        user.RefreshToken = jwtTokenGenerator.GenerateRefreshToken();

        await userRepository.AddAsync(user, cancellationToken);

        var accessToken = jwtTokenGenerator.CreateAccessToken(
            user.Id,
            user.Username,
            null
        );

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = user.RefreshToken,
            UserId = user.Id
        };
    }
}