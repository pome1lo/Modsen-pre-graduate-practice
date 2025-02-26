using DataAccessLayer.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbSet.ToListAsync(token);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken token = default)
    {
        return await _dbSet.FindAsync([id], token);
    }

    public async Task AddAsync(T entity, CancellationToken token = default)
    {
        await _dbSet.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(T entity, CancellationToken token = default)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(int id, CancellationToken token = default)
    {
        var entity = await GetByIdAsync(id, token);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(token);
        }
    }
}