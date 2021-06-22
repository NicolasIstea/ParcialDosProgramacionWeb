using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class PagoController : GenericController<Pago>, IPagoController
    {
        private readonly IPagoService _pagoService;
        public PagoController(IPagoService pagoService) : base(pagoService)
        {
            _pagoService = pagoService;
        }
         
        [HttpGet]
        [Route("mayordeuda")]
        public async Task<ActionResult<Pago>> GetPagoMayorDeuda()
        {
            var result = await _pagoService.GetPagoMayorDeuda();

            if(result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        
    }
}
