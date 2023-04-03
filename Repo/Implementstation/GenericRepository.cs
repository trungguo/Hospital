using Microsoft.EntityFrameworkCore;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Implementstation
{
    public class GenericRepository<T> : IDisposable,IGenericRepository <T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context; 
            dbset = _context.Set<T>();
        }
        public void Add(T entity)   
        {
            dbset.Add(entity);
        }
        public async Task<T> AddAsync(T entity)
        {
            dbset.Add(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);
        }
        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);
            return entity;
        }
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public IEnumerable<T>   GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var Incluperties in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                query = query.Include(includeProperties);
                }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }            
        }
        public T GetById(object id)
        {
            return dbset.Find(id);
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await dbset.FindAsync(id);
        }
        public void Update(T entity)
        {
            dbset.Update(entity);
            _context.Entry(entity).State= EntityState.Modified;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State= EntityState.Modified;
            return entity;
        }      
    }       
}
