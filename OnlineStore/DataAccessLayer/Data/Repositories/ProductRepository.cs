using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class ProductRepository : Repository<Products>, IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Products>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken token = default)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync(token);
    }
}
