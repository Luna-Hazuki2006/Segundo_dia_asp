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

        /// <summary>
        /// Método para devolver todos los personajes
        /// </summary>
        /// <returns>Una lista de objetos de personajes</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Nivel": 0, 
        ///         "Tipo_Id": 0, 
        ///         "Salud": 0.0, 
        ///         "Energia": 0.0, 
        ///         "Fuerza": 0.0, 
        ///         "Inteligencia": 0.0, 
        ///         "Agilidad": 0.0, 
        ///         "Defensa": 0.0, 
        ///         "Resistencia": 0.0, 
        ///         "Experiencia": 0.0, 
        ///         "Inventario_Id": 0
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(){

            var Personajes = await _servicio.GetAll();

            return Ok(Personajes);
        }
        
        /// <summary>
        /// Método para obtener un personaje
        /// </summary>
        /// <param name="Id">La id del personaje</param>
        /// <returns>Objeto de personaje</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel": 0, 
        ///     "Tipo_Id": 0, 
        ///     "Salud": 0.0, 
        ///     "Energia": 0.0, 
        ///     "Fuerza": 0.0, 
        ///     "Inteligencia": 0.0, 
        ///     "Agilidad": 0.0, 
        ///     "Defensa": 0.0, 
        ///     "Resistencia": 0.0, 
        ///     "Experiencia": 0.0, 
        ///     "Inventario_Id": 0
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(int Id){

            var Personajes = await _servicio.GetPersonajeById(Id);

            return Ok(Personajes);
        }

        /// <summary>
        /// Método para creación de un personaje
        /// </summary>
        /// <param name="personaje">La instancia de la clase personaje</param>
        /// <returns>Objeto del nuevo personaje</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel": 0, 
        ///     "Tipo_Id": 0, 
        ///     "Salud": 0.0, 
        ///     "Energia": 0.0, 
        ///     "Fuerza": 0.0, 
        ///     "Inteligencia": 0.0, 
        ///     "Agilidad": 0.0, 
        ///     "Defensa": 0.0, 
        ///     "Resistencia": 0.0, 
        ///     "Experiencia": 0.0, 
        ///     "Inventario_Id": 0
        /// }
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

        /// <summary>
        /// Método para modificar un personaje
        /// </summary>
        /// <param name="Id">Es la id del personaje a modificar</param>
        /// <param name="personaje">Es el objeto del personaje modificado</param>
        /// <returns>El personaje modificado</returns>
        /// <remarks>
        /// Ejemplo de un personaje devuelto
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel": 0, 
        ///     "Tipo_Id": 0, 
        ///     "Salud": 0.0, 
        ///     "Energia": 0.0, 
        ///     "Fuerza": 0.0, 
        ///     "Inteligencia": 0.0, 
        ///     "Agilidad": 0.0, 
        ///     "Defensa": 0.0, 
        ///     "Resistencia": 0.0, 
        ///     "Experiencia": 0.0, 
        ///     "Inventario_Id": 0
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Personaje>> Put(int Id, [FromBody] Personaje personaje)
        {
            try
            {
                var updatedPersonaje =
                    await _servicio.UpdatePersonaje(Id, personaje);

                return Ok(updatedPersonaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}