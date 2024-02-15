using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entidades;
using Services.Services;
using Core.Servicios;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private IPersonajeService _servicio;

        public PersonajeController(IPersonajeService personajeService){
           _servicio = personajeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(){

            var Personajes = await _servicio.GetAll();

            return Ok(Personajes);
        }
        
        /// <summary>
        /// Cosa que objetener
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(int id){

            var Personajes = await _servicio.GetPersonajeById(id);

            return Ok(Personajes);
        }

        // POST api/<PersonajeController>
        /// <summary>
        /// Cosas a actualizar
        /// </summary>
        /// <param name="id">Prueba</param>
        /// <returns>Algo para devolver</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Personaje>> Post([FromBody] Personaje personaje)
        {
            try
            {
                var createdPersonaje =
                    await _servicio.CreatePersonaje(personaje);

                return Ok(createdPersonaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Personaje>> Put(int id, [FromBody] Personaje personaje)
        {
            try
            {
                var updatedPersonaje =
                    await _servicio.UpdatePersonaje(id, personaje);

                return Ok(updatedPersonaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}