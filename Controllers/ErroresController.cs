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
    public class ErroresController : ControllerBase
    {
        private readonly IErrorService _aeroService;

        public ErroresController(IErrorService aeroService)
        {
            _aeroService = aeroService;
        }

        [HttpGet]
        [Description("Busca todos los errores dentro de la base de datos")]
        public ActionResult<IEnumerable<ErrorReadDto>> GetErrores()
        {
            var result = _aeroService.GetAllErrores();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        [Description("Crea un error en la base de datos")]
        public ActionResult CreateError([FromBody] ErrorWriteDto error)
        {
            var result = _aeroService.CreateError(error);

            if (result > 0)
            {
                return Created("api/CreateError", error);
            }

            return BadRequest();
        }

    }
}
