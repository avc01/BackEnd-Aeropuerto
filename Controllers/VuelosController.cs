using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd_Aeropuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IVueloService _aeroService;

        public VuelosController(IVueloService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VueloReadDto>> GetVuelos() 
        {
            var result = _aeroService.GetAllVuelos();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateVuelo([FromBody]VueloReadDto vuelo)
        {
            var result = _aeroService.CreateVuelo(vuelo);
  
            if (result > 0)
            {
                return Created("api/CreateVuelo", vuelo);
            }

            return BadRequest();
        }
    }
}
