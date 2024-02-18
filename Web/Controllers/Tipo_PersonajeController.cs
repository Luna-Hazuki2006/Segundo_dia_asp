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
    public class Tipo_PersonajeController : ControllerBase
    {
        private ITipo_PersonajeService _servicio;

        public Tipo_PersonajeController(ITipo_PersonajeService Tipo_PersonajeService){
           _servicio = Tipo_PersonajeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Personaje>>> Get(){

            var Tipo_Personajes = await _servicio.GetAll();

            return Ok(Tipo_Personajes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tipo_Personaje>>> Get(int id){

            var Tipo_Personajes = await _servicio.GetTipo_PersonajeById(id);

            return Ok(Tipo_Personajes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tipo_Personaje"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Tipo_Personaje>> Post([FromBody] Tipo_Personaje Tipo_Personaje)
        {
            try
            {
                var createdTipo_Personaje =
                    await _servicio.CreateTipo_Personaje(Tipo_Personaje);

                return Ok(createdTipo_Personaje);
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
        /// <param name="Tipo_Personaje"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Tipo_Personaje>> Put(int id, [FromBody] Tipo_Personaje Tipo_Personaje)
        {
            try
            {
                var updatedTipo_Personaje =
                    await _servicio.UpdateTipo_Personaje(id, Tipo_Personaje);

                return Ok(updatedTipo_Personaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}