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
        /// Método para devolver todos los usuarios
        /// </summary>
        /// <returns>Una lista de objetos de usuarios</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Cedula": "1323343", 
        ///         "Nombres": "string", 
        ///         "Apellidos": "string", 
        ///         "Apodo": "string", 
        ///         "Correo": "string", 
        ///         "Contraseña": "string", 
        ///         "Nacimiento": 2021-03-23, 
        ///         "Género": "string", 
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get(){

            var Usuarios = await _servicio.Listar();

            return Ok(Usuarios);
        }
        
        /// <summary>
        /// Método para obtener un Usuario
        /// </summary>
        /// <param name="Cedula">La cedula del Usuario</param>
        /// <returns>Objeto de Usuario</returns>
        /// <remarks>
        /// Ejemplo de objeto devuelto 
        /// {
        ///     "Cedula": "1323343", 
        ///     "Nombres": "string", 
        ///     "Apellidos": "string", 
        ///     "Apodo": "string", 
        ///     "Correo": "string", 
        ///     "Contraseña": "string", 
        ///     "Nacimiento": 2021-03-23, 
        ///     "Género": "string", 
        /// }
        /// </remarks>
        [HttpGet("{Cedula}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get(string Cedula){

            var Usuarios = await _servicio.Consultar(Cedula);

            return Ok(Usuarios);
        }

        /// <summary>
        /// Método para creación de un Usuario
        /// </summary>
        /// <param name="Sesion">La instancia de la clase Usuario</param>
        /// <returns>Objeto del nuevo Usuario</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Cedula": "1323343", 
        ///     "Nombres": "string", 
        ///     "Apellidos": "string", 
        ///     "Apodo": "string", 
        ///     "Correo": "string", 
        ///     "Contraseña": "string", 
        ///     "Nacimiento": 2021-03-23, 
        ///     "Género": "string", 
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Sesion>> Post([FromBody] string cedula, string contraseña)
        {
            try
            {
                var sesionCreada =
                    await _servicio.Iniciar_Sesion(cedula, contraseña);

                return Ok(sesionCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un Usuario
        /// </summary>
        /// <param name="Cedula">Es la cedula del Usuario a modificar</param>
        /// <param name="Usuario">Es el objeto del Usuario modificado</param>
        /// <returns>El Usuario modificado</returns>
        /// <remarks>
        /// Ejemplo de un Usuario devuelto
        /// {
        ///     "Cedula": "1323343", 
        ///     "Nombres": "string", 
        ///     "Apellidos": "string", 
        ///     "Apodo": "string", 
        ///     "Correo": "string", 
        ///     "Contraseña": "string", 
        ///     "Nacimiento": 2021-03-23, 
        ///     "Género": "string", 
        /// }
        /// </remarks>
        [HttpPut("{Cedula}")]
        public async Task<ActionResult<Usuario>> Put(string Cedula, [FromBody] Usuario Usuario)
        {
            try
            {
                var updatedUsuario =
                    await _servicio.ActualizarDatos(Cedula, Usuario);

                return Ok(updatedUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<string> Delete() {
            
        }
    }
}