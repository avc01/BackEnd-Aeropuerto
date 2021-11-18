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
    public class PuertasController : ControllerBase
    {
        private readonly IPuertaService _aeroService;

        public PuertasController(IPuertaService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PuertaReadDto>> GetPuertas()
        {
            var result = _aeroService.GetAllPuertas();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PuertaReadDto> GetPuertaById([FromRoute] int id)
        {
            var result = _aeroService.GetPuertaById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreatePuerta([FromBody]PuertaWriteDto puerta)
        {
            var result = _aeroService.CreatePuerta(puerta);

            if (result > 0)
            {
                return Created("api/CreatePuerta", puerta);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePuertaById([FromRoute]int id)
        {
            var result = _aeroService.DeletePuertaById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
