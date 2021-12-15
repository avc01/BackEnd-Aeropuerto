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
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _aeroService;

        public ComprasController(ICompraService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpPost]
        public IActionResult CreateCompra(CompraWriteDto compraWriteDto)
        {
            var result = _aeroService.CreateCompra(compraWriteDto);

            if (result > 0)
            {
                return new JsonResult(new { fueComprado = true });
            }

            return new JsonResult(new { fueComprado = false });
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompraReadDto>> GetCompras()
        {
            var result = _aeroService.GetCompras();

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("compras-correo/{correo}")]
        public ActionResult<IEnumerable<CompraReadDto>> GetComprasDeUsuario(string correo)
        {
            var result = _aeroService.GetComprasDeUsuarioByCorreo(correo);

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
