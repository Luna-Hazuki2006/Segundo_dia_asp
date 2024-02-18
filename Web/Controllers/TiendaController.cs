using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private ITiendaService _servicio;

        public TiendaController(ITiendaService TiendaService){
           _servicio = TiendaService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(){

            var Tiendas = await _servicio.GetAll();

            return Ok(Tiendas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(int id){

            var Tiendas = await _servicio.GetTiendaById(id);

            return Ok(Tiendas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tienda"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Tienda>> Post([FromBody] Tienda Tienda)
        {
            try
            {
                var createdTienda =
                    await _servicio.CreateTienda(Tienda);

                return Ok(createdTienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Tienda"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Tienda>> Put(int id, [FromBody] Tienda Tienda)
        {
            try
            {
                var updatedTienda =
                    await _servicio.UpdateTienda(id, Tienda);

                return Ok(updatedTienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}