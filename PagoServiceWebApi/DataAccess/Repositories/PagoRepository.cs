using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {

        public PagoRepository(PagoServicioDbContext context) : base(context) 
        {
        }

        private IQueryable<Pago> Incluir()
        {
            return this._context.Set<Pago>()
                .Include(p => p.MetodoDePago);
        }

        public async Task<Pago> GetPagoMayorDeuda()
        {
            var pagoMayorDeuda = await table
                .OrderByDescending(x => x.Deuda)
                .FirstOrDefaultAsync();

            return pagoMayorDeuda;
        }

        public override async Task<IEnumerable<Pago>> GetAll()
        {
            return await Incluir().ToListAsync();
        }

        public override async Task<Pago> GetById(int id)
        {
            return await Incluir().FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

    }
}
