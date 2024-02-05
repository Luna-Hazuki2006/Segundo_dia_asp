using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController
    {
        private ITiendaService _servicio;

        public TiendaController(ITiendaService TiendaService){
           _servicio = TiendaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(){

            var Tiendas = await _servicio.GetAll();

            return Ok(Tiendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(int id){

            var Tiendas = await _servicio.GetTiendaById(id);

            return Ok(Tiendas);
        }

        // POST api/<TiendaController>
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

        [HttpPut]
        public async Task<ActionResult<Tienda>> Put(int id, [FromBody] Tienda Tienda)
        {
            try
            {
                var updatedTienda =
                    await _servicio.UpdateTienda(Tienda);

                return Ok(updatedTienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}