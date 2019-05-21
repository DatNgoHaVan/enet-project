using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface ILoginRepository
    {
        Task<User> Login(string username, string password);
    }
}