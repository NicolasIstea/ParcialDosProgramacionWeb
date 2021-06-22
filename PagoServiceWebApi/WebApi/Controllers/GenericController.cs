using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T> : ControllerBase, IGenericController<T> where T : BaseEntity
    {
        private readonly IGenericService<T> _genericService;
        public GenericController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        public async Task<ActionResult<T>> AddEntity([FromBody] T entity)
        {
            T entidad;

            try
            {
                entidad = await _genericService.AddEntity(entity);
            }
            catch (ValidationPagoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("AddEntity",entidad);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEntity([FromRoute] int id)
        {

            try
            {
                await _genericService.DeleteEntity(id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
            
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<T>> GetById([FromRoute] int id)
        {
            T entidad;

            try
            {
                entidad = await _genericService.GetById(id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(entidad);
        }

        [HttpGet]
        public async Task<ActionResult<List<T>>> GetEntities()
        {
            IEnumerable<T> entities;

            try
            {
                entities = await _genericService.GetEntities();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            if(entities == null)
            {
                return NoContent();
            }

            return Ok(entities.ToList());
        }

        [HttpPut]
        public async Task<ActionResult<T>> UpdateEntity(T entity)
        {
            T entidad;

            if(entity == null)
            {
                return BadRequest();
            }

            try
            {
                entidad = await _genericService.UpdateEntity(entity);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(entidad);
        }
    }
}
