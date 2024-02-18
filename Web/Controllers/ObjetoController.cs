using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetoController : ControllerBase
    {
        private IObjetoService _servicio;

        public ObjetoController(IObjetoService ObjetoService){
           _servicio = ObjetoService;
        }

        /// <summary>
        /// Método para devolver todos los objetos
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Descripcion": "string", 
        ///         "Tipo": "string", 
        ///         "Valor": 0.0
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objeto>>> Get(){

            var Objetos = await _servicio.GetAll();

            return Ok(Objetos);
        }

        /// <summary>
        /// Método para obtener un objeto
        /// </summary>
        /// <param name="Id">La id del objeto</param>
        /// <returns>Objeto de "Objeto"</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Tipo": "string", 
        ///     "Valor": 0.0
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Objeto>>> Get(int Id){

            var Objetos = await _servicio.GetObjetoById(Id);

            return Ok(Objetos);
        }

        /// <summary>
        /// Método para creación de un objeto
        /// </summary>
        /// <param name="Objeto">La instancia de la clase de objeto</param>
        /// <returns>Objeto del nuevo objeto</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Tipo": "string", 
        ///     "Valor": 0.0
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Objeto>> Post([FromBody] Objeto Objeto)
        {
            try
            {
                var createdObjeto =
                    await _servicio.CreateObjeto(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un objeto
        /// </summary>
        /// <param name="Id">Es la id del objeto a modificar</param>
        /// <param name="Objeto">Es el objeto de la clase "Objeto"</param>
        /// <returns>El objeto modificado</returns>
        /// <remarks>
        /// Ejemplo de un objeto devuelto
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Tipo": "string", 
        ///     "Valor": 0.0
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Objeto>> Put(int Id, [FromBody] Objeto Objeto)
        {
            try
            {
                var updatedObjeto =
                    await _servicio.UpdateObjeto(Id, Objeto);

                return Ok(updatedObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}