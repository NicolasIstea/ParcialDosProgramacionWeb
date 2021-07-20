using Models;
using Services;

namespace WebApi.Controllers
{
    public class MetodoDePagoController : GenericController<MetodoDePago>, IMetodoDePagoController
    {
        private readonly IMetodoDePagoService _metodoDePagoService;

        public MetodoDePagoController(IMetodoDePagoService genericService) : base(genericService)
        {
            _metodoDePagoService = genericService;
        }

    }
}
