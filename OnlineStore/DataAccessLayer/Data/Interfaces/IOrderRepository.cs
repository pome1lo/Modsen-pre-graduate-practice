using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface IOrderRepository : IRepository<Orders>
{
    Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(int userId, CancellationToken token = default);
}
