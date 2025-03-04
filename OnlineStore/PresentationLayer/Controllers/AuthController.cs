using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IAuthService authService
) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginDto loginDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authResponse = await authService.LoginAsync(loginDto, cancellationToken);
            return Ok(authResponse);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync(
        [FromQuery] int userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await authService.LogoutAsync(userId, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync(
        [FromBody] string refreshToken,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authResponse = await authService.RefreshTokenAsync(refreshToken, cancellationToken);
            return Ok(authResponse);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterDto registerDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authResponse = await authService.RegisterAsync(registerDto, cancellationToken);
            return CreatedAtAction(nameof(LoginAsync), authResponse);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}