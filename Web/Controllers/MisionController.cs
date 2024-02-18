using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MisionController : ControllerBase
    {
        private IMisionService _servicio;

        public MisionController(IMisionService MisionService){
           _servicio = MisionService;
        }

        /// <summary>
        /// Método para devolver todas las misiones
        /// </summary>
        /// <returns>Una lista de objetos de misiones</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Objetivos": [...], 
        ///         "Recompensas": [...], 
        ///         "Estado": "string"
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(){

            var Misions = await _servicio.GetAll();

            return Ok(Misions);
        }

        /// <summary>
        /// Método para obtener una mision
        /// </summary>
        /// <param name="Id">La id de la mision</param>
        /// <returns>Objeto de mision</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Objetivos": [...], 
        ///     "Recompensas": [...], 
        ///     "Estado": "string"
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(int Id){

            var Misions = await _servicio.GetMisionById(Id);

            return Ok(Misions);
        }

        /// <summary>
        /// Método para creación de una misión
        /// </summary>
        /// <param name="Mision">La instancia de la clase de mision</param>
        /// <returns>Objeto de la nueva mision</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Objetivos": [...], 
        ///     "Recompensas": [...], 
        ///     "Estado": "string"
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Mision>> Post([FromBody] Mision Mision)
        {
            try
            {
                var createdMision =
                    await _servicio.CreateMision(Mision);

                return Ok(createdMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar una mision
        /// </summary>
        /// <param name="Id">Es la id de la misión a modificar</param>
        /// <param name="Mision">Es el objeto de la Mision</param>
        /// <returns>La mision modificada</returns>
        /// <remarks>
        /// Ejemplo de una mision devuelta 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Objetivos": [...], 
        ///     "Recompensas": [...], 
        ///     "Estado": "string"
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Mision>> Put(int Id, [FromBody] Mision Mision)
        {
            try
            {
                var updatedMision =
                    await _servicio.UpdateMision(Id, Mision);

                return Ok(updatedMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}