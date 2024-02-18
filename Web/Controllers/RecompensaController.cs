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

        /// <summary>
        /// Método para devolver todos los tipos de recompensa
        /// </summary>
        /// <returns>Una lista de objetos de recompensa</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Experiencia": 0.0, 
        ///         "Objetos": [...], 
        ///         "Enemigos": [...], 
        ///         "Monedas": 0
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(){

            var Recompensas = await _servicio.GetAll();

            return Ok(Recompensas);
        }

        /// <summary>
        /// Método para obtener una recompensa
        /// </summary>
        /// <param name="Id">La id de la recompensa</param>
        /// <returns>Objeto de tipo de recompensa</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Experiencia": 0.0, 
        ///     "Objetos": [...], 
        ///     "Enemigos": [...], 
        ///     "Monedas": 0
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(int Id){

            var Recompensas = await _servicio.GetRecompensaById(Id);

            return Ok(Recompensas);
        }

        /// <summary>
        /// Método para creación de una recompensa
        /// </summary>
        /// <param name="Recompensa">La instancia de la clase de recompensa</param>
        /// <returns>Objeto de la nueva recompensa</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Experiencia": 0.0, 
        ///     "Objetos": [...], 
        ///     "Enemigos": [...], 
        ///     "Monedas": 0
        /// }
        /// </remarks>
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

        /// <summary>
        /// Método para modificar una recompensa
        /// </summary>
        /// <param name="Id">Es la id de la recompensa a modificar</param>
        /// <param name="Recompensa">Es el objeto de la recompensa modificada</param>
        /// <returns>La recompensa modificada</returns>
        /// <remarks>
        /// Ejemplo de una recompensa devuelta 
        /// {
        ///     "Id": 0, 
        ///     "Experiencia": 0.0, 
        ///     "Objetos": [...], 
        ///     "Enemigos": [...], 
        ///     "Monedas": 0
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Recompensa>> Put(int Id, [FromBody] Recompensa Recompensa)
        {
            try
            {
                var updatedRecompensa =
                    await _servicio.UpdateRecompensa(Id, Recompensa);

                return Ok(updatedRecompensa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}