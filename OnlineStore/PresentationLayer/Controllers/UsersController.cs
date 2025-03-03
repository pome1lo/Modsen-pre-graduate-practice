using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(CancellationToken cancellationToken)
        { 
            return Ok(
                await _userService.GetAllUsersAsync(cancellationToken)
            );
        }
         
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId, CancellationToken cancellationToken)
        { 
            return Ok(
                await _userService.GetUserByIdAsync(userId, cancellationToken)
            );
        }
          
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserDto updatedUser, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserAsync(userId, updatedUser, cancellationToken);
            return NoContent();
        }
         
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId, CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(userId, cancellationToken);
            return NoContent();
        }
    }
}
