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

        /// <summary>
        /// Método para devolver todos los enemigos
        /// </summary>
        /// <returns>Una lista de objetos de enemigo</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Nivel_Amenaza": 0, 
        ///         "Vida": 0.0, 
        ///         "Recompensas": [...], 
        ///         "Habilidades": [...]
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(){

            var Enemigos = await _servicio.GetAll();

            return Ok(Enemigos);
        }

        /// <summary>
        /// Método para obtener un enemigo
        /// </summary>
        /// <param name="Id">La id del enemigo</param>
        /// <returns>Objeto de Enemigo</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel_Amenaza": 0, 
        ///     "Vida": 0.0, 
        ///     "Recompensas": [...], 
        ///     "Habilidades": [...]
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(int Id){

            var Enemigos = await _servicio.GetEnemigoById(Id);

            return Ok(Enemigos);
        }

        /// <summary>
        /// Método para creación de un enemigo
        /// </summary>
        /// <param name="Enemigo">La instancia de la clase de enemigo</param>
        /// <returns>Objeto del nuevo enemigo</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel_Amenaza": 0, 
        ///     "Vida": 0.0, 
        ///     "Recompensas": [...], 
        ///     "Habilidades": [...]
        /// }
        /// </remarks>
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

        /// <summary>
        /// Método para modificar un enemigo
        /// </summary>
        /// <param name="Id">Es la id del enemigo a modificar</param>
        /// <param name="Enemigo">Es el objeto del enemigo modificado</param>
        /// <returns>El enemigo modificado</returns>
        /// <remarks>
        /// Ejemplo de un enemigo devuelto
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Nivel_Amenaza": 0, 
        ///     "Vida": 0.0, 
        ///     "Recompensas": [...], 
        ///     "Habilidades": [...]
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Enemigo>> Put(int Id, [FromBody] Enemigo Enemigo)
        {
            try
            {
                var updatedEnemigo =
                    await _servicio.UpdateEnemigo(Id, Enemigo);

                return Ok(updatedEnemigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}