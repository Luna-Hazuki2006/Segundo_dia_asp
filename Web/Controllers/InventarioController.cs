using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private IInventarioService _servicio;

        public InventarioController(IInventarioService InventarioService){
           _servicio = InventarioService;
        }

        /// <summary>
        /// Método para devolver todos los inventarios
        /// </summary>
        /// <returns>Una lista de objetos de inventarios</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Personaje": {...}, 
        ///         "Espacio_Disponible": 0, 
        ///         "Objetos": [...], 
        ///         "Peso_Total": 0.0
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> Get(){

            var Inventarios = await _servicio.GetAll();

            return Ok(Inventarios);
        }

        /// <summary>
        /// Método para obtener un inventario
        /// </summary>
        /// <param name="Id">La id del inventario</param>
        /// <returns>Objeto de Inventario</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Personaje": {...}, 
        ///     "Espacio_Disponible": 0, 
        ///     "Objetos": [...], 
        ///     "Peso_Total": 0.0
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Inventario>>> Get(int Id){

            var Inventarios = await _servicio.GetInventarioById(Id);

            return Ok(Inventarios);
        }

        /// <summary>
        /// Método para creación de un inventario
        /// </summary>
        /// <param name="Inventario">La instancia de la clase de Inventario</param>
        /// <returns>Objeto del nuevo inventario</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Personaje": {...}, 
        ///     "Espacio_Disponible": 0, 
        ///     "Objetos": [...], 
        ///     "Peso_Total": 0.0
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Inventario>> Post([FromBody] Inventario Inventario)
        {
            try
            {
                var createdInventario =
                    await _servicio.CreateInventario(Inventario);

                return Ok(createdInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un inventario
        /// </summary>
        /// <param name="Id">Es la id del inventario a modificar</param>
        /// <param name="Inventario">Es el objeto del inventario modificado</param>
        /// <returns>El inventario modificado</returns>
        /// <remarks>
        /// Ejemplo de un inventario devuelto
        /// {
        ///     "Id": 0, 
        ///     "Personaje": {...}, 
        ///     "Espacio_Disponible": 0, 
        ///     "Objetos": [...], 
        ///     "Peso_Total": 0.0
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Inventario>> Put(int Id, [FromBody] Inventario Inventario)
        {
            try
            {
                var updatedInventario =
                    await _servicio.UpdateInventario(Id, Inventario);

                return Ok(updatedInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}