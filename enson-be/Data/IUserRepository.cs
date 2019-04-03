using enson_be.Dtos;
using enson_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public interface IUserRepository
    {
        // get all users
        IEnumerable<User> GetUsers();

        // get one users by iduser
        User GetUserById(long userId);

        // add user
        User AddUser(User user, string password);

        // update user
        void UpdateUser(User user, string password = null);

        // delete user
        void DeleteUser(long userId);
    }
}
