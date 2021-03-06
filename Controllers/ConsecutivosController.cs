using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd_Aeropuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsecutivosController : ControllerBase
    {
        private readonly IConsecutivoService _aeroService;
       
        public ConsecutivosController(IConsecutivoService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsecutivoReadDto>> GetConsecutivos()
        {
            var result = _aeroService.GetAllConsecutivos();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ConsecutivoReadDto> GetConsecutivoById([FromRoute]int id) 
        {
            var result = _aeroService.GetConsecutivoById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateConsecutivo([FromBody]ConsecutivoWriteDto consecutivo)
        {
            var result = _aeroService.CreateConsecutivo(consecutivo);

            if (result > 0)
            {
                return Created("api/CreateConsecutivo", consecutivo);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteConsecutivoById([FromRoute]int id) 
        {
            var result = _aeroService.DeleteConsecutivoById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
