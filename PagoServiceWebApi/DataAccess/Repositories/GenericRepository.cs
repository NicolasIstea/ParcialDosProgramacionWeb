using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly PagoServicioDbContext _context = null;
        public readonly DbSet<T> table = null;

        public GenericRepository(PagoServicioDbContext pagoServicioDbContext)
        {
            _context = pagoServicioDbContext;
            table = _context.Set<T>();
        }

        public virtual async Task<T> Add(T entity)
        {
            await table.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            table.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = table;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await table.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
            return entity;
        }
    }
}
