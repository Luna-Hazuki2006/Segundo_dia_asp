using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MisionController : ControllerBase
    {
        private IMisionService _servicio;

        public MisionController(IMisionService MisionService){
           _servicio = MisionService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(){

            var Misions = await _servicio.GetAll();

            return Ok(Misions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(int id){

            var Misions = await _servicio.GetMisionById(id);

            return Ok(Misions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mision"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Mision>> Post([FromBody] Mision Mision)
        {
            try
            {
                var createdMision =
                    await _servicio.CreateMision(Mision);

                return Ok(createdMision);
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
        /// <param name="Mision"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Mision>> Put(int id, [FromBody] Mision Mision)
        {
            try
            {
                var updatedMision =
                    await _servicio.UpdateMision(id, Mision);

                return Ok(updatedMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}