using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models;

public class User : BaseModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Password_Salt { get; set; }
    public string RefreshToken { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime UpdatedDate { get; set; }
    public RoleList Roles { get; set; }
    public virtual ICollection<Orders> Orders { get; set; }
}
