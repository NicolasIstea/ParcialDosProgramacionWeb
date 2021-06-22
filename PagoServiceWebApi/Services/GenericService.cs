using DataAccess.Repositories;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public virtual async Task<T> AddEntity(T entity)
        {
            var result = await _genericRepository.Add(entity);

            return result;
        }

        public virtual async Task DeleteEntity(int id)
        {
            await _genericRepository.Delete(id);
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _genericRepository.GetById(id);

            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetEntities()
        {
            var entities = await _genericRepository.GetAll();

            return entities;
        }

        public virtual Task<T> UpdateEntity(T entity)
        {
            var result = _genericRepository.Update(entity);

            return result;
        }
    }
}
