using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface IRegisterService
    {
        //Represents an asynchronous operation that return a User.
        Task<User> Register(User user, string password);

        //Represents an asynchronous operation that return true/false for user exist already
        Task<bool> UserExist(string username);

        //Represents an asynchronous operation that return true/false for email exist already
        Task<bool> EmailExist(string email);
    }
}