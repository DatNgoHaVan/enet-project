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
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DatabaseContext _context;
        private DbSet<T> _entities;
        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        //Create Method
        public void Create(T entity)
        {
            Entities.Add(entity);
        }

        //Find all method
        // public async Task<IEnumerable<T>> FindAllAsync()
        // {
        //     return await _context.Set<T>().ToListAsync();
        // }

        //Find with condition method
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Entities.AsQueryable().Where(expression);
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

        public IQueryable<T> FindAll() => Entities.AsQueryable();
    }
}
