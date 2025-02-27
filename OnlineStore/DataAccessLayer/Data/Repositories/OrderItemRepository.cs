using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class OrderItemRepository : Repository<OrderItems>, IOrderItemRepository
{
    private readonly ApplicationContext _context;

    public OrderItemRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId, CancellationToken token = default)
    {
        return await _context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync(token);
    }
}
