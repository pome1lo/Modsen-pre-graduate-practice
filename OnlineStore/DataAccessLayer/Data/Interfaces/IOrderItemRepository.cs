using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItems>> GetAllAsync();
        Task<OrderItems> GetByIdAsync(int id);
        Task AddAsync(OrderItems orderItem);
        Task UpdateAsync(OrderItems orderItem);
        Task DeleteAsync(int id);
    }
}
