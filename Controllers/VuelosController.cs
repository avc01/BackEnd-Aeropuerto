using BackEnd_Aeropuerto.Models;
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
    public class VuelosController : ControllerBase
    {
        private readonly IVueloService _aeroService;

        public VuelosController(IVueloService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vuelo>> GetVuelos() 
        {
            var resultado = _aeroService.GetAllVuelos();

            if (!resultado.Any())
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult CreateVuelo([FromBody]Vuelo vuelo)
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
