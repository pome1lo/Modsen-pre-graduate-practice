using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Interfaces;

public interface ICategoryRepository : IRepository<Categories>
{
    Task<IEnumerable<Categories>> GetCategoriesWithProductsAsync(CancellationToken token = default);
}
