using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Interfaces
{
    public interface IProductRepository : IRepository<Products>
    {
        Task<IEnumerable<Products>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
