using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private IInventarioService _servicio;

        public InventarioController(IInventarioService InventarioService){
           _servicio = InventarioService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> Get(){

            var Inventarios = await _servicio.GetAll();

            return Ok(Inventarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Inventario>>> Get(int id){

            var Inventarios = await _servicio.GetInventarioById(id);

            return Ok(Inventarios);
        }

        // POST api/<InventarioController>
        [HttpPost]
        public async Task<ActionResult<Inventario>> Post([FromBody] Inventario Inventario)
        {
            try
            {
                var createdInventario =
                    await _servicio.CreateInventario(Inventario);

                return Ok(createdInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Inventario>> Put(int id, [FromBody] Inventario Inventario)
        {
            try
            {
                var updatedInventario =
                    await _servicio.UpdateInventario(id, Inventario);

                return Ok(updatedInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}