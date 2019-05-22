using System.Threading.Tasks;
using enet_be.Models;

namespace enet_be.Data
{
    public interface ILoginService
    {
        Task<User> Login(string username, string password);
    }
}