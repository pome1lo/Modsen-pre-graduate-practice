using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
 
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
 
    public async Task<User> GetUserByEmailAsync(string email, CancellationToken token = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, token);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken token = default)
    {
        return await _context.Users.ToListAsync(token); 
    }
}
