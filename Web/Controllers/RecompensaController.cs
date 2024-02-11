using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecompensaController : ControllerBase
    {
        private IRecompensaService _servicio;

        public RecompensaController(IRecompensaService RecompensaService){
           _servicio = RecompensaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(){

            var Recompensas = await _servicio.GetAll();

            return Ok(Recompensas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(int id){

            var Recompensas = await _servicio.GetRecompensaById(id);

            return Ok(Recompensas);
        }

        // POST api/<RecompensaController>
        [HttpPost]
        public async Task<ActionResult<Recompensa>> Post([FromBody] Recompensa Recompensa)
        {
            try
            {
                var createdRecompensa =
                    await _servicio.CreateRecompensa(Recompensa);

                return Ok(createdRecompensa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Recompensa>> Put(int id, [FromBody] Recompensa Recompensa)
        {
            try
            {
                var updatedRecompensa =
                    await _servicio.UpdateRecompensa(id, Recompensa);

                return Ok(updatedRecompensa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}