using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class CategoryRepository : Repository<Categories>, ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categories>> GetCategoriesWithProductsAsync()
    {
        return await _context.Categories.Include(c => c.Products).ToListAsync();
    }
}
