using DataAccess.Repositories;
using Models;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PagoService : GenericService<Pago>, IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        public PagoService(IPagoRepository pagoRepository) : base(pagoRepository) 
        {
            _pagoRepository = pagoRepository;
        }

        public override async Task<Pago> AddEntity(Pago entity)
        {
            //validaciones
            if (entity == null)
            {
                throw new ValidationPagoException("Debe completar todos los datos");
            }

            if(entity.Deuda > 10000 || entity.Deuda < 100)
            {
                throw new ValidationPagoException("La deuda debe ser menor a 10000 pero mayor a 100");
            }


            return await base.AddEntity(entity);
        }

        public async Task<Pago> GetPagoMayorDeuda()
        {
            return await _pagoRepository.GetPagoMayorDeuda();
        }
    }
}
