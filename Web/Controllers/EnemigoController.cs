using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemigoController : ControllerBase
    {
        private IEnemigoService _servicio;

        public EnemigoController(IEnemigoService EnemigoService){
           _servicio = EnemigoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(){

            var Enemigos = await _servicio.GetAll();

            return Ok(Enemigos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(int id){

            var Enemigos = await _servicio.GetEnemigoById(id);

            return Ok(Enemigos);
        }

        // POST api/<EnemigoController>
        [HttpPost]
        public async Task<ActionResult<Enemigo>> Post([FromBody] Enemigo Enemigo)
        {
            try
            {
                var createdEnemigo =
                    await _servicio.CreateEnemigo(Enemigo);

                return Ok(createdEnemigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Enemigo>> Put(int id, [FromBody] Enemigo Enemigo)
        {
            try
            {
                var updatedEnemigo =
                    await _servicio.UpdateEnemigo(id, Enemigo);

                return Ok(updatedEnemigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}