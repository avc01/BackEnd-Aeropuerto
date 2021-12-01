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

        [HttpGet("{id}")]
        public ActionResult<VueloReadDto> GetVueloById([FromRoute]int id)
        {
            var result = _aeroService.GetVueloById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateVuelo([FromBody]VueloWriteDto vuelo)
        {
            var result = _aeroService.CreateVuelo(vuelo);
  
            if (result > 0)
            {
                return Created("api/CreateVuelo", vuelo);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVueloById([FromRoute]int id)
        {
            var result = _aeroService.DeleteVueloById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("vuelos-entrantes")]
        public IActionResult GetVuelosEntrantes()
        {
            var result = _aeroService.GetVueloEntrantes();

            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        [HttpGet("vuelos-salientes")]
        public IActionResult GetVuelosSalientes()
        {
            var result = _aeroService.GetVueloSalientes();

            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }
    }
}
