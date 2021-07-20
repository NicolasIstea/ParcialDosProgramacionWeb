using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginRepository(PagoServicioDbContext pagoServicioDbContext) { }

    }
}
