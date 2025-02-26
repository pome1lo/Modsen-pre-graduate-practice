using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface IProductRepository : IRepository<Products>
{
    Task<IEnumerable<Products>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken token = default);
}
