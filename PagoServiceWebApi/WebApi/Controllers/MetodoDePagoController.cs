using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
