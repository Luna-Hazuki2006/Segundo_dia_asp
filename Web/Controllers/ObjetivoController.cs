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
    public class ObjetivoController : ControllerBase
    {
        private IObjetivoService _servicio;

        public ObjetivoController(IObjetivoService ObjetivoService){
           _servicio = ObjetivoService;
        }

        /// <summary>
        /// Método para devolver todos los objetivos
        /// </summary>
        /// <returns>Una lista de objetivos</returns>
        /// <remarks>
        /// Ejemplo de lista devuelta 
        /// [
        ///     {
        ///         "Id": 0, 
        ///         "Nombre": "string", 
        ///         "Descripcion": "string", 
        ///         "Hecho": false
        ///     }
        /// ]
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get(){

            var Objetivos = await _servicio.GetAll();

            return Ok(Objetivos);
        }

        /// <summary>
        /// Método para obtener un objetivo
        /// </summary>
        /// <param name="Id">La id del objetivo</param>
        /// <returns>Objeto de Objetivo</returns>
        /// <remarks>
        /// Ejemplo de objetivo devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Hecho": false
        /// }
        /// </remarks>
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get(int Id){

            var Objetivos = await _servicio.GetObjetivoById(Id);

            return Ok(Objetivos);
        }

        /// <summary>
        /// Método para creación de un objetivo
        /// </summary>
        /// <param name="Objetivo">La instancia de la clase de objetivo</param>
        /// <returns>Objeto del nuevo objetivo</returns>
        /// <remarks>
        /// Ejemplo de un Json request
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Hecho": false
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Objetivo>> Post([FromBody] Objetivo Objetivo)
        {
            try
            {
                var createdObjetivo =
                    await _servicio.CreateObjetivo(Objetivo);

                return Ok(createdObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar un tipo de personaje
        /// </summary>
        /// <param name="Id">Es la id del objetivo a modificar</param>
        /// <param name="Objetivo">Es el objetivo modificado</param>
        /// <returns>El objetivo modificado</returns>
        /// <remarks>
        /// Ejemplo de un objetivo devuelto 
        /// {
        ///     "Id": 0, 
        ///     "Nombre": "string", 
        ///     "Descripcion": "string", 
        ///     "Hecho": false
        /// }
        /// </remarks>
        [HttpPut]
        public async Task<ActionResult<Objetivo>> Put(int Id, [FromBody] Objetivo Objetivo)
        {
            try
            {
                var updatedObjetivo =
                    await _servicio.UpdateObjetivo(Id, Objetivo);

                return Ok(updatedObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}