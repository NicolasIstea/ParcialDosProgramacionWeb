using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPagoRepository : IGenericRepository<Pago>
    {
        Task<Pago> GetPagoMayorDeuda();
    }
}
