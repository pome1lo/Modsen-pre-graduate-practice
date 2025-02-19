using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItems>
    {
        Task<IEnumerable<OrderItems>> GetOrderItemsByOrderIdAsync(int orderId);
    }
}
