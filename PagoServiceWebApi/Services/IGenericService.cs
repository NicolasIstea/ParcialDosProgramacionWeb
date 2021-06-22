using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetEntities();
        Task<T> GetById(int id);
        Task<T> UpdateEntity(T entity);
        Task DeleteEntity(int id);
        Task<T> AddEntity(T entity);

    }
}