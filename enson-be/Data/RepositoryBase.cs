using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Data
{
    //Inherit IRepository with type T is a class
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DatabaseContext _context;
        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        //Create Method
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //Find all method
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //Find with condition method
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        //Delete method
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //Save async method
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        //Update method
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IQueryable<T> FindAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
