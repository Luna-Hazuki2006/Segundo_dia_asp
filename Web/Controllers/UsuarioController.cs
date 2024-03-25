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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _servicio;

        public UsuarioController(IUsuarioService usuarioService){
           _servicio = usuarioService;
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
        [HttpGet("update/{Cedula}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get(string Cedula){

            var Usuarios = await _servicio.Consultar(Cedula);

            return Ok(Usuarios);
        }

        /// <summary>
        /// Método para creación de un Usuario
        /// </summary>
        /// <param name="Usuario">La instancia de la clase Usuario</param>
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
        [HttpPost("create")]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            try
            {
                var createdUsuario =
                    await _servicio.Registrar(usuario);

                return Ok(createdUsuario);
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
    }
}