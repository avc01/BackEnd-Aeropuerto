using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _aeroService;

        public UsuariosController(IUsuarioService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        [Description("Busca todos los usuarios")]
        public ActionResult<IEnumerable<UsuarioReadDto>> GetUsuarios()
        {
            var result = _aeroService.GetAllUsuarios();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Description("Busca un usuario mediante id")]
        public ActionResult<UsuarioReadDto> GetUsuarioById([FromRoute] int id)
        {
            var result = _aeroService.GetUsuarioById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("user-profile-by-mail/{correo}")]
        public ActionResult<UsuarioReadDto> GetUsuarioProfileByEmail([FromRoute] string correo)
        {
            var result = _aeroService.GetUsuarioProfileByEmail(correo);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("usuario-login")]
        public IActionResult GetUsuarioByEmail(string correo,string clave)
        {
            var result = _aeroService.GetUsuarioByEmail(correo, clave);

            if (result is false)
            {
                return new JsonResult(new { EstaLogeado = false });
            }

            return new JsonResult(result);
        }

        [HttpPost]
        [Description("Crea un usuario")]
        public IActionResult CreateUsuario([FromBody] UsuarioWriteDto usuario)
        {
            var result = _aeroService.CreateUsuario(usuario);

            if (result > 0)
            {
                return new JsonResult(new { fueCreado = true });
            }

            return new JsonResult(new { fueCreado = false });
        }

        [HttpDelete("{id}")]
        [Description("Elimina un usuario mediante id")]
        public IActionResult DeleteUsuarioById([FromRoute] int id)
        {
            var result = _aeroService.DeleteUsuarioById(id);

            if (result > 0)
            {
                return new JsonResult(new { fueBorrado = true });
            }

            return new JsonResult(new { fueBorrado = false });
        }

        [HttpPut("id/{id}/contra/{newPassword}")]
        [Description("Cambia la password del usuario")]
        public IActionResult ChangePassword(int id, string newPassword) 
        {
            var result = _aeroService.ChangePassword(id, newPassword);

            if (result > 0)
            {
                return new JsonResult(new { fueCambiada = true});
            }

            return new JsonResult(new { fueCambiada = false });
        }
    }
}
