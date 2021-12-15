using BackEnd_Aeropuerto.Dtos;
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
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _aeroService;

        public ReservasController(IReservaService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpPost("cantidad/{cantidad}/total/{total}/vueloid/{vueloId}/correo/{correo}")]
        public IActionResult CreateReserva(int cantidad, double total, int vueloId, string correo)
        {
            var result = _aeroService.CreateReserva(cantidad, total, vueloId, correo);

            if (result > 0)
            {
                return new JsonResult(new { fueReservado = true });
            }

            return new JsonResult(new { fueReservado = false });
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservaReadDto>> GetReservas()
        {
            var result = _aeroService.GetAllReservas();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservaById([FromRoute] int id)
        {
            var result = _aeroService.DeleteReservaById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("reservas-correo/{correo}")]
        public ActionResult<IEnumerable<ReservaReadDto>> GetReservasDeUsuario(string correo)
        {
            var result = _aeroService.GetReservasByEmail(correo);

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
