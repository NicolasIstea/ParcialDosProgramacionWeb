using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MetodoDePagoRepository : GenericRepository<MetodoDePago>, IMetodoDePagoRepository
    {
        public MetodoDePagoRepository(PagoServicioDbContext pagoServicioDbContext):base(pagoServicioDbContext) {}
    }
}
