using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;

namespace Web.Controllers
{
    public class MisionController
    {
        private IMisionService _servicio;

        public MisionController(IMisionService MisionService){
           _servicio = MisionService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(){

            var Misions = await _servicio.GetAll();

            return Ok(Misions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Mision>>> Get(int id){

            var Misions = await _servicio.GetMisionById(id);

            return Ok(Misions);
        }

        // POST api/<MisionController>
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

        [HttpPut]
        public async Task<ActionResult<Mision>> Put(int id, [FromBody] Mision Mision)
        {
            try
            {
                var updatedMision =
                    await _servicio.UpdateMision(Mision);

                return Ok(updatedMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}