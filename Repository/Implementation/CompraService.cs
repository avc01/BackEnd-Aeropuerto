using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Helpers;
using BackEnd_Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class CompraService : ICompraService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<CompraReadDto> _cryptRead;
        private readonly ICrypt<CompraWriteDto> _cryptWrite;
        private readonly IConsecutivoService _consecutivoService;
        private readonly IErrorService _errorService;
        private readonly IUsuarioService _usuarioService;

        public CompraService(
            AppDbContext context, 
            IMapper mapper, 
            ICrypt<CompraReadDto> cryptRead, 
            ICrypt<CompraWriteDto> cryptWrite, 
            IConsecutivoService consecutivoService, 
            IErrorService errorService,
            IUsuarioService usuarioService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _consecutivoService = consecutivoService;
            _errorService = errorService;
            _usuarioService = usuarioService;
        }

        public int CreateCompra(CompraWriteDto compraWriteDto)
        {
            // creo informacion que se solicita.
            compraWriteDto.FechaHora = TimeHelper.GetLongDate();

            // traigo informacion de otros servicios con stored procedures.
            var consecutivoPorDefectoCompras = _consecutivoService.GetConsecutivoById(49);
            compraWriteDto.ConsecutivoId = consecutivoPorDefectoCompras.ConsecutivoId;
            compraWriteDto.Consecutivo = $"{consecutivoPorDefectoCompras.Prefijo}-{consecutivoPorDefectoCompras.NumeroConsecutivo}";
            compraWriteDto.UsuarioId = _usuarioService.GetUsuarioProfileByEmail(compraWriteDto.CorreoUsuario).UsuarioId;

            // Encrypto y mapeo.
            var resultEncrypted = _cryptWrite.EncryptData(compraWriteDto);
            var resultMapped = _mapper.Map<Compra>(resultEncrypted);

            // Creo en la base de datos con Stored Procedure.
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateCompra {resultMapped.FechaHora}, {resultMapped.Precio}, {resultMapped.Cantidad}, {resultMapped.ConsecutivoId}, {resultMapped.VueloId}, {resultMapped.UsuarioId}, {resultMapped.Consecutivo}");
                
                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public IEnumerable<CompraReadDto> GetCompras()
        {
            try
            {
                var result = _context.Compras.FromSqlInterpolated<Compra>($"sp_GetCompras")
                .ToList();

                if (result is null) return null;

                var resultMapped = _mapper.Map<IEnumerable<CompraReadDto>>(result);

                var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

                return resultDecrypted;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return null;
            }
        }

        public object GetComprasDeUsuarioByCorreo(string correo)
        {
            try
            {
                var usuarioId = _usuarioService.GetUsuarioProfileByEmail(correo).UsuarioId;

                var compras = GetCompras();

                var comprasdeUsuario = compras.Where(x => x.UsuarioId == usuarioId);
               
                if (comprasdeUsuario is null) return null;

                return comprasdeUsuario;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return null;
            }
        }
    }
}
