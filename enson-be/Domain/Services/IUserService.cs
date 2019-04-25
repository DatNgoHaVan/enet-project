using enson_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(long userId);
        Task<User> GetUserByEmailAsync(string userEmail);
        Task<User> GetUserByUserNameAsync(string userName);
        Task UpdateUserAsync(User user, string password);
        Task DeleteUserAsync(User user);
    }
}
