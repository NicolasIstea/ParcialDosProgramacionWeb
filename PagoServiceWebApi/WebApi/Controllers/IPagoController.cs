using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    internal interface IPagoController : IGenericController<Pago>
    {
        Task<ActionResult<Pago>> GetPagoMayorDeuda();
    }
}