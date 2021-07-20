using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null);
        Task<T> Add(T entity);
        Task Delete(int id);
        Task<T> Update(T entity);
        Task SaveChanges();

    }
}
