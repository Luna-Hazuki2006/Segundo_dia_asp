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
    public class ObjetivoController : ControllerBase
    {
        private IObjetivoService _servicio;

        public ObjetivoController(IObjetivoService ObjetivoService){
           _servicio = ObjetivoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get(){

            var Objetivos = await _servicio.GetAll();

            return Ok(Objetivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get(int id){

            var Objetivos = await _servicio.GetObjetivoById(id);

            return Ok(Objetivos);
        }

        // POST api/<ObjetivoController>
        [HttpPost]
        public async Task<ActionResult<Objetivo>> Post([FromBody] Objetivo Objetivo)
        {
            try
            {
                var createdObjetivo =
                    await _servicio.CreateObjetivo(Objetivo);

                return Ok(createdObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Objetivo>> Put(int id, [FromBody] Objetivo Objetivo)
        {
            try
            {
                var updatedObjetivo =
                    await _servicio.UpdateObjetivo(id, Objetivo);

                return Ok(updatedObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}