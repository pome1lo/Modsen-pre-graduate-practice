using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface IUserRepository : IRepository<User>
{ 
    Task<User> GetUserByEmailAsync(string email, CancellationToken token = default);
    Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken token = default); 
}
