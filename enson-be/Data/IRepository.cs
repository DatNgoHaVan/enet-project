using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();
        void Add(T entity);

        void SaveChanges(T entity);

        Task SaveChangesAsync();

        void Remove(T entity);

        
    }
}