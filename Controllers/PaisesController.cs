using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisService _aeroService;

        public PaisesController(IPaisService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaisReadDto>> GetPaises()
        {
            var result = _aeroService.GetAllPaises();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PaisReadDto> GetPaisById([FromRoute] int id)
        {
            var result = _aeroService.GetPaisById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreatePais([FromBody] PaisWriteDto pais)
        {
            var result = _aeroService.CreatePais(pais);

            if (result > 0)
            {
                return Created("api/CreatePais", pais);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePaisById([FromRoute] int id)
        {
            var result = _aeroService.DeletePaisById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
