
﻿namespace DataAccessLayer.Data.Interfaces;


public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default);
    Task<T> GetByIdAsync(int id, CancellationToken token = default);
    Task AddAsync(T entity, CancellationToken token = default);
    Task UpdateAsync(T entity, CancellationToken token = default);
    Task DeleteAsync(int id, CancellationToken token = default);
}
