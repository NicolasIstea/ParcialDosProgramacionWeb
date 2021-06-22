using DataAccess.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MetodoDePagoService : GenericService<MetodoDePago>, IMetodoDePagoService
    {
        private readonly IMetodoDePagoRepository _pagoRepository;

        public MetodoDePagoService(IMetodoDePagoRepository pagoRepository) : base(pagoRepository) 
        {
            _pagoRepository = pagoRepository;
        }

    }
}
