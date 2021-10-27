using BackEnd_Aeropuerto.DataEncryption;
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
    public class ConsecutivosController : ControllerBase
    {
        private readonly IAeropuertoService _aeroService;
        private readonly ICrypt<Consecutivo> _crypt;

        public ConsecutivosController(IAeropuertoService aeroService, ICrypt<Consecutivo> crypt)
        {
            _aeroService = aeroService;
            _crypt = crypt;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Consecutivo>> GetConsecutivos()
        {
            var resultado = _aeroService.GetAllConsecutivos();

            var data = _crypt.DecryptDataMultipleRows(resultado);

            if (!data.Any())
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult CreateConsecutivo([FromBody]Consecutivo consecutivo)
        {
            var data = _crypt.EncryptData(consecutivo);

            var result = _aeroService.CreateConsecutivo(data);

            if (result > 0)
            {
                return Created("api/CreateConsecutivo", consecutivo);
            }

            return BadRequest();
        }
    }
}
