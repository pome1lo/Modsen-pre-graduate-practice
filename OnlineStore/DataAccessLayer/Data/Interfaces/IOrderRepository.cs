using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Interfaces
{
    public interface IOrderRepository : IRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(int userId);
    }
}
