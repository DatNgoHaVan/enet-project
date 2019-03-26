using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface IRegisterRepository
    {
        //Represents an asynchronous operation that return a User.
        Task<User> Register(User user, string password);

        //Represents an asynchronous operation that return true/false for user exist already
        Task<bool> UserExist(string username);
    }
}