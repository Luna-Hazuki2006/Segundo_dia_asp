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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> Get(){

            var Bancos = await _servicio.GetAll();

            return Ok(Bancos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Banco>>> Get(int id){

            var Bancos = await _servicio.GetBancoById(id);

            return Ok(Bancos);
        }

        // POST api/<BancoController>
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

        [HttpPut]
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