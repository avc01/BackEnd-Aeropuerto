using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Models;
using BackEnd_Aeropuerto.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd_Aeropuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineasController : ControllerBase
    {
        private readonly IAerolineaService _aeroService;

        public AerolineasController(IAerolineaService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AerolineaReadDto>> GetAerolineas()
        {
            var result = _aeroService.GetAllAerolineas();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateAerolinea([FromBody]AerolineaWriteDto aerolinea)
        {
            var result = _aeroService.CreateAerolinea(aerolinea);

            if (result > 0)
            {
                return Created("api/CreateAerolinea", aerolinea);
            }

            return BadRequest();
        }
    }
}
