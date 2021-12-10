using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class TarjetaService : ITarjetaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<TarjetaReadDto> _cryptRead;
        private readonly ICrypt<TarjetaWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;
        private readonly IUsuarioService _usuarioService;

        public TarjetaService(
            AppDbContext context,
            IMapper mapper,
            ICrypt<TarjetaReadDto> cryptRead,
            ICrypt<TarjetaWriteDto> cryptWrite,
            IErrorService errorService,
            IUsuarioService usuarioService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
            _usuarioService = usuarioService;
        }

        public int DeleteTarjetaById(int tarjetaId)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteTarjetaById {tarjetaId}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public IEnumerable<TarjetaReadDto> GetAllTarjetas()
        {
            var result = _context.Tarjetas.FromSqlInterpolated<Tarjeta>($"sp_GetTarjetas")
                .ToList();

            if (result is null) return null;

            var resultMapped = _mapper.Map<IEnumerable<TarjetaReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public IEnumerable<TarjetaReadDto> GetTarjetasByCorreoUsuario(string correo)
        {
            try
            {
                var usuarioIdResult = _usuarioService.GetUsuarioProfileByEmail(correo).UsuarioId;

                var result = _context.Tarjetas
               .FromSqlInterpolated<Tarjeta>($"sp_GetTarjetasByUsuarioId {usuarioIdResult}")
               .ToList();

                if (result is null) return null;

                var resultMapped = _mapper.Map<IEnumerable<TarjetaReadDto>>(result);

                var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

                return resultDecrypted;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return null;
            }
        }

        public int RegistrarTarjeta(TarjetaWriteDto tarjeta)
        {
            if (tarjeta is null)
            {
                throw new ArgumentNullException(nameof(tarjeta));
            }

            var usuarioIdResult = _usuarioService.GetUsuarioProfileByEmail(tarjeta.CorreoUsuario).UsuarioId;
            tarjeta.UsuarioId = usuarioIdResult;

            var resultEncrypted = _cryptWrite.EncryptData(tarjeta);
            var resultMapped = _mapper.Map<Tarjeta>(resultEncrypted);

            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateTarjeta {resultMapped.NumeroTarjeta},{resultMapped.Marca},{resultMapped.Tipo},{resultMapped.CodigoTarjeta},{resultMapped.UsuarioId},{resultMapped.AnoExp},{resultMapped.MesExp}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }
    }
}
