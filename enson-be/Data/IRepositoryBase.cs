using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public interface IRepositoryBase<T>
    {
        //Task<IEnumerable<T>> FindAllAsync();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task SaveAsync();
    }
}
