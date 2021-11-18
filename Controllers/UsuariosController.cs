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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _aeroService;

        public UsuariosController(IUsuarioService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
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
        public ActionResult<UsuarioReadDto> GetUsuarioById([FromRoute] int id)
        {
            var result = _aeroService.GetUsuarioById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateUsuario([FromBody] UsuarioWriteDto usuario)
        {
            var result = _aeroService.CreateUsuario(usuario);

            if (result > 0)
            {
                return Created("api/CreateUsuario", usuario);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuarioById([FromRoute] int id)
        {
            var result = _aeroService.DeleteUsuarioById(id);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult ChangePassword([FromRoute]int id, [FromRoute]string newPassword) 
        {
            var result = _aeroService.ChangePassword(id, newPassword);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
