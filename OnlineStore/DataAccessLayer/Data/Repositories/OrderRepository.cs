using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class OrderRepository : Repository<Orders>, IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(int userId, CancellationToken token = default)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync(token);
    }
}
