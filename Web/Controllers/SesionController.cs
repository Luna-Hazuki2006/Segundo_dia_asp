using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private ISesionService _servicio;

        public SesionController(ISesionService SesionService){
           _servicio = SesionService;
        }
    }
}