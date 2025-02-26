using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface IOrderItemRepository : IRepository<OrderItems>
{
    Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId, CancellationToken token = default);
}
