using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {
        private IBancoService _servicio;

        public BancoController(IBancoService BancoService){
           _servicio = BancoService;
        }

        /// <summary>
        /// Método para devolver todos los bancos
        /// </summary>
        /// <returns>Una lista de objetos de bancos</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Cuenta_Bacaria": 0.0, 
        ///         "Intereses": 0.0, 
        ///         "Prestamos": 0.0, 
        ///         "Seguridad": 0
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> Get(){

            var Bancos = await _servicio.GetAll();

            return Ok(Bancos);
        }

        /// <summary>
        /// Método para obtener un banco
        /// </summary>
        /// <param name="id">La id del banco</param>
        /// <returns>Objeto de Banco</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Cuenta_Bacaria": 0.0, 
        ///     "Intereses": 0.0, 
        ///     "Prestamos": 0.0, 
        ///     "Seguridad": 0
        /// }
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Banco>>> Get(int id){

            var Bancos = await _servicio.GetBancoById(id);

            return Ok(Bancos);
        }

        /// <summary>
        /// Método para creación de un banco
        /// </summary>
        /// <param name="Banco">La instancia de la clase de banco</param>
        /// <returns>Objeto del nuevo banco</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Cuenta_Bacaria": 0.0, 
        ///     "Intereses": 0.0, 
        ///     "Prestamos": 0.0, 
        ///     "Seguridad": 0
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Banco>> Post([FromBody] Banco Banco)
        {
            try
            {
                var createdBanco =
                    await _servicio.CreateBanco(Banco);

                return Ok(createdBanco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un banco
        /// </summary>
        /// <param name="id">Es la id del banco a modificar</param>
        /// <param name="Banco">Es el objeto del banco modificado</param>
        /// <returns>El banco modificado</returns>
        /// <remarks>
        /// Ejemplo de un banco devuelto
        /// {
        ///     "Id": 0, 
        ///     "Cuenta_Bacaria": 0.0, 
        ///     "Intereses": 0.0, 
        ///     "Prestamos": 0.0, 
        ///     "Seguridad": 0
        /// }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<ActionResult<Banco>> Put(int id, [FromBody] Banco Banco)
        {
            try
            {
                var updatedBanco =
                    await _servicio.UpdateBanco(id, Banco);

                return Ok(updatedBanco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}