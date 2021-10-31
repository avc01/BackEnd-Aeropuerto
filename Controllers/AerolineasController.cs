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
        public ActionResult<IEnumerable<Aerolinea>> GetAerolineas()
        {
            var resultado = _aeroService.GetAllAerolineas();

            if (!resultado.Any())
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult CreateAerolinea([FromBody]Aerolinea aerolinea)
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
