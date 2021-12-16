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
    public class RolesController : ControllerBase
    {
        private readonly IRolService _aeroService;

        public RolesController(IRolService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var result = _aeroService.GetAllRoles();

            if (result is null) return NotFound();

            return new JsonResult(result);
        }

        [HttpGet("roles-usuarios")]
        public IActionResult GetRolesUsuarios()
        {
            var result = _aeroService.GetAllRolesUsuarios();

            if (result is null) return NotFound();

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateRol([FromBody] RolWriteDto rol)
        {
            var result = _aeroService.AsignarRolAUsuario(rol);

            if (result > 0)
            {
                return new JsonResult(new { fueAsignado = true });
            }

            return new JsonResult(new { fueAsignado = false });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRolById([FromRoute] int id)
        {
            var result = _aeroService.DeleteRolById(id);

            if (result > 0)
            {
                return new JsonResult(new { fueBorrado = true });
            }

            return new JsonResult(new { fueBorrado = false });
        }
    }
}
