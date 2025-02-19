using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetUserByEmailAsync(string email);
        Task<IEnumerable<Users>> GetAllUsersAsync();
    }
}
