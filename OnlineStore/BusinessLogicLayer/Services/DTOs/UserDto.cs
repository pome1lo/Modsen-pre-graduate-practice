using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserDto() { }

        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }
    }
}
