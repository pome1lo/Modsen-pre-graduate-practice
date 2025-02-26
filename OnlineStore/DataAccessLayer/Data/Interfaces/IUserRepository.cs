using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface IUserRepository : IRepository<Users>
{
    Task<Users> GetUserByEmailAsync(string email, CancellationToken token = default);
    Task<IEnumerable<Users>> GetAllUsersAsync(CancellationToken token = default);
}
