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
    public class TarjetasController : ControllerBase
    {
        private readonly ITarjetaService _aeroService;

        public TarjetasController(ITarjetaService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTarjetaById([FromRoute] int id)
        {
            var result = _aeroService.DeleteTarjetaById(id);

            if (result > 0)
            {
                return new JsonResult(new { fueBorrada = true });
            }

            return new JsonResult(new { fueBorrada = false });
        }

        [HttpPost]
        public IActionResult CreateTarjeta([FromBody] TarjetaWriteDto tarjeta)
        {
            var result = _aeroService.RegistrarTarjeta(tarjeta);

            if (result > 0)
            {
                return new JsonResult(new { fueCreado = true });
            }

            return new JsonResult(new { fueCreado = false });
        }

        [HttpGet("{correo}")]
        public ActionResult<IEnumerable<TarjetaReadDto>> GetTarjetasByCorreoUsuario([FromRoute] string correo)
        {
            var result = _aeroService.GetTarjetasByCorreoUsuario(correo);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TarjetaReadDto>> GetTarjetas()
        {
            var result = _aeroService.GetAllTarjetas();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
