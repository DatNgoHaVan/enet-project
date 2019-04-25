using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface ILoginService
    {
        Task<User> Login(string username, string password);
    }
}