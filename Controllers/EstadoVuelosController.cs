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
    public class EstadoVuelosController : ControllerBase
    {
        private readonly IEstadoVueloService _aeroService;

        public EstadoVuelosController(IEstadoVueloService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EstadoVueloReadDto>> GetEstadoVuelos()
        {
            var result = _aeroService.GetAllEstadoVuelos();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<EstadoVueloReadDto>> GetEstadoVueloById([FromRoute]int id)
        {
            var result = _aeroService.GetEstadoVueloById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateEstadoVuelo([FromBody]EstadoVueloWriteDto estadoVuelo)
        {
            var result = _aeroService.CreateEstadoVuelo(estadoVuelo);

            if (result > 0)
            {
                return Created("api/CreateEstadoVuelo", estadoVuelo);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEstadoVueloById([FromRoute]int id)
        {
            var result = _aeroService.DeleteEstadoVueloById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
