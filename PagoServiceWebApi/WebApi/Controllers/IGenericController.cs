using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    internal interface IGenericController<T> where T : BaseEntity
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<List<T>>> GetEntities();
        Task<ActionResult<T>> AddEntity(T entity);
        Task<ActionResult<T>> UpdateEntity(T entity);
        Task<ActionResult> DeleteEntity(int id); 
    }
}