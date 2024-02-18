using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private ITiendaService _servicio;

        public TiendaController(ITiendaService TiendaService){
           _servicio = TiendaService;
        }

        /// <summary>
        /// Método para devolver todas las tiendas
        /// </summary>
        /// <returns>Una lista de objetos de tienda</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Inventario_Tienda": [...], 
        ///         "Precios": [...], 
        ///         "Stock": [...], 
        ///         "Dinero_Tienda": 0.0
        ///     }
        /// ]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(){

            var Tiendas = await _servicio.GetAll();

            return Ok(Tiendas);
        }

        /// <summary>
        /// Método para obtener una tienda
        /// </summary>
        /// <param name="Id">La id de la tienda</param>
        /// <returns>Objeto de tienda</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Inventario_Tienda": [...], 
        ///     "Precios": [...], 
        ///     "Stock": [...], 
        ///     "Dinero_Tienda": 0.0
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Tienda>>> Get(int Id){

            var Tiendas = await _servicio.GetTiendaById(Id);

            return Ok(Tiendas);
        }

        /// <summary>
        /// Método para creación de una tienda
        /// </summary>
        /// <param name="Tienda">La instancia de la clase de tienda</param>
        /// <returns>Objeto de la nueva tienda</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Inventario_Tienda": [...], 
        ///     "Precios": [...], 
        ///     "Stock": [...], 
        ///     "Dinero_Tienda": 0.0
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Tienda>> Post([FromBody] Tienda Tienda)
        {
            try
            {
                var createdTienda =
                    await _servicio.CreateTienda(Tienda);

                return Ok(createdTienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar una tienda
        /// </summary>
        /// <param name="Id">Es la id de la tienda a modificar</param>
        /// <param name="Tienda">Es el objeto de la tienda modificada</param>
        /// <returns>La tienda modificada</returns>
        /// <remarks>
        /// Ejemplo de una tienda devuelta
        /// {
        ///     "Id": 0, 
        ///     "Inventario_Tienda": [...], 
        ///     "Precios": [...], 
        ///     "Stock": [...], 
        ///     "Dinero_Tienda": 0.0
        /// }
        /// </remarks>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Tienda>> Put(int Id, [FromBody] Tienda Tienda)
        {
            try
            {
                var updatedTienda =
                    await _servicio.UpdateTienda(Id, Tienda);

                return Ok(updatedTienda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}