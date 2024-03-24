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
        /// Método para devolver todos los tipos de personajes
        /// </summary>
        /// <returns>Una lista de objetos de tipos de personajes</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Descripcion": "string"
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Personaje>>> Get(){

            var Tipo_Personajes = await _servicio.GetAll();

            return Ok(Tipo_Personajes);
        }

        /// <summary>
        /// Método para obtener un tipo de personaje
        /// </summary>
        /// <param name="Id">La id del tipo de personaje</param>
        /// <returns>Objeto de tipo de personaje</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string"
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Tipo_Personaje>>> Get(int Id){

            var Tipo_Personajes = await _servicio.GetTipo_PersonajeById(Id);

            return Ok(Tipo_Personajes);
        }

        /// <summary>
        /// Método para creación de un tipo de personaje
        /// </summary>
        /// <param name="Tipo_Personaje">La instancia de la clase de tipo_personaje</param>
        /// <returns>Objeto del nuevo tipo de personaje</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string"
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Tipo_Personaje>> Post([FromBody] Tipo_Personaje Tipo_Personaje)
        {
            try
            {
                var createdTipo_Personaje =
                    await _servicio.CreateTipo_Personaje(Tipo_Personaje);
                Console.WriteLine(createdTipo_Personaje);

                return Ok(createdTipo_Personaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un tipo de personaje
        /// </summary>
        /// <param name="Id">Es la id del tipo de personaje a modificar</param>
        /// <param name="Tipo_Personaje">Es el objeto del tipo de personaje modificado</param>
        /// <returns>El tipo de personaje modificado</returns>
        /// <remarks>
        /// Ejemplo de un tipo de personaje devuelto
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string"
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Tipo_Personaje>> Put(int Id, [FromBody] Tipo_Personaje Tipo_Personaje)
        {
            try
            {
                var updatedTipo_Personaje =
                    await _servicio.UpdateTipo_Personaje(Id, Tipo_Personaje);

                return Ok(updatedTipo_Personaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}