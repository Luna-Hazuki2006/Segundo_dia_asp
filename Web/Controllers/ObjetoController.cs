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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objeto>>> Get(){

            var Objetos = await _servicio.GetAll();

            return Ok(Objetos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Objeto>>> Get(int id){

            var Objetos = await _servicio.GetObjetoById(id);

            return Ok(Objetos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Objeto"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Objeto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Objeto>> Put(int id, [FromBody] Objeto Objeto)
        {
            try
            {
                var updatedObjeto =
                    await _servicio.UpdateObjeto(id, Objeto);

                return Ok(updatedObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}