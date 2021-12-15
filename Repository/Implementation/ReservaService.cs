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
    public class ReservaService : IReservaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<ReservaReadDto> _cryptRead;
        private readonly ICrypt<ReservaWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;
        private readonly IConsecutivoService _consecutivoService;
        private readonly IUsuarioService _usuarioService;

        public ReservaService(
            AppDbContext context,
            IMapper mapper,
            ICrypt<ReservaReadDto> cryptRead,
            ICrypt<ReservaWriteDto> cryptWrite,
            IErrorService errorService,
            IConsecutivoService consecutivoService,
            IUsuarioService usuarioService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
            _consecutivoService = consecutivoService;
            _usuarioService = usuarioService;
        }

        public int CreateReserva(int cantidad, double total, int vueloId, string correo)
        {
            // creo informacion que se solicita.
            var fechaHoraValue = TimeHelper.GetLongDate();
            var numeroReservacionValue = ErrorNumberHelper.NumeroReservacion();
            var bookingIdValue = ErrorNumberHelper.RandomString();

            // traigo informacion de otros servicios con stored procedures.
            var consecutivoPorDefectoReservas = _consecutivoService.GetConsecutivoById(47);
            var consecutivoIdValue = consecutivoPorDefectoReservas.ConsecutivoId;
            var consecutivoValue = $"{consecutivoPorDefectoReservas.Prefijo}-{consecutivoPorDefectoReservas.NumeroConsecutivo}";
            var usuarioIdValue = _usuarioService.GetUsuarioProfileByEmail(correo).UsuarioId;

            // mapeo el objeto Reserva.
            ReservaWriteDto reservaWriteDto = new ReservaWriteDto() 
            { 
                FechaHora = fechaHoraValue,
                NumeroReservacion = numeroReservacionValue,
                BookingId = bookingIdValue,
                Cantidad = cantidad,
                Total = total,
                ConsecutivoId = consecutivoIdValue,
                VueloId = vueloId,
                UsuarioId = usuarioIdValue,
                Consecutivo = consecutivoValue
            };

            // Encrypto y mapeo.
            var resultEncrypted = _cryptWrite.EncryptData(reservaWriteDto);
            var resultMapped = _mapper.Map<Reserva>(resultEncrypted);

            // Creo en la base de datos con Stored Procedure.
            try
            { 
                _context.Database.ExecuteSqlInterpolated($"sp_CreateReserva {resultMapped.FechaHora}, {resultMapped.NumeroReservacion}, {resultMapped.BookingId}, {resultMapped.Cantidad}, {resultMapped.Total}, {resultMapped.ConsecutivoId}, {resultMapped.VueloId}, {resultMapped.UsuarioId}, {resultMapped.Consecutivo}");
                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteReservaById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteReservaById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public IEnumerable<ReservaReadDto> GetAllReservas()
        {
            var result = _context.Reservas.FromSqlInterpolated<Reserva>($"sp_GetReservas")
                .ToList();

            if (result is null) return null;

            var resultMapped = _mapper.Map<IEnumerable<ReservaReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public object GetReservasByEmail(string correo)
        {
            try
            {
                var usuarioId = _usuarioService.GetUsuarioProfileByEmail(correo).UsuarioId;

                var reservas = GetAllReservas();

                var reservasDeUsuario = reservas.Where(x => x.UsuarioId == usuarioId);

                if (reservasDeUsuario is null) return null;

                return reservasDeUsuario;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return null;
            }
        }
    }
}
