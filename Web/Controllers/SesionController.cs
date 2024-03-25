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
    public class SesionController : ControllerBase
    {
        private ISesionService _servicio;

        public SesionController(ISesionService SesionService){
           _servicio = SesionService;
        }

        /// <summary>
        /// Método para creación de una sesion
        /// </summary>
        /// <param name="cedula">La cedula del usuario</param>
        /// <param name="contraseña">La contraseña del usuario</param>
        /// <returns>Objeto de la nueva sesion</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Token": "adsd.sdfsdf.aerere", 
        ///     "Cedula_usuario": "12232332", 
        /// }
        /// </remarks>
        [HttpPost("/create")]
        public async Task<ActionResult<Sesion>> Post([FromBody] Usuario usuario)
        {
            try
            {
                var sesionCreada =
                    await _servicio.Iniciar_Sesion(usuario.Cedula, usuario.Contraseña);

                return Ok(sesionCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Este método se encarga de validar los tokens de las sesiones
        /// </summary>
        /// <param name="token">El token de la sesion a validar</param>
        /// <returns>Un valor booleano indicando si es valido o no</returns>
        [HttpPost("/validate")]
        public async Task<ActionResult<bool>> Post([FromBody] string token)
        {
            try
            {
                var resultado = _servicio.Validar(token);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para cerrar una sesión y borrarla
        /// </summary>
        /// <param name="sesion">El objeto de la sesion</param>
        /// <returns>Una cadena vacía</returns>
        [HttpDelete("/logout")]
        public async Task<ActionResult<string>> Delete([FromBody] Sesion sesion) {
            try
            {
                _servicio.Cerrar_Sesion(sesion);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}