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
    public class VueloService : IVueloService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<VueloReadDto> _cryptRead;
        private readonly ICrypt<VueloWriteDto> _cryptWrite;
        private readonly IConsecutivoService _consecutivoService;
        private readonly IErrorService _errorService;
        private readonly IAerolineaService _aerolineaService;
        private readonly IEstadoVueloService _estadoVueloService;
        private readonly IPuertaService _puertaService;

        public VueloService(
            AppDbContext context, 
            IMapper mapper, 
            ICrypt<VueloReadDto> cryptRead, 
            ICrypt<VueloWriteDto> cryptWrite, 
            IConsecutivoService consecutivoService, 
            IErrorService errorService,
            IAerolineaService aerolineaService,
            IEstadoVueloService estadoVueloService,
            IPuertaService puertaService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _consecutivoService = consecutivoService;
            _errorService = errorService;
            _aerolineaService = aerolineaService;
            _estadoVueloService = estadoVueloService;
            _puertaService = puertaService;
        }

        public IEnumerable<VueloReadDto> GetAllVuelos()
        {
            var result = _context.Vuelos.FromSqlInterpolated<Vuelo>($"sp_GetVuelos")
                .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<VueloReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public int CreateVuelo(VueloWriteDto vuelo)
        {
            if (vuelo == null)
            {
                throw new ArgumentNullException(nameof(vuelo));
            }

            var resultEncrypted = _cryptWrite.EncryptData(vuelo);

            var resultMapped = _mapper.Map<Vuelo>(resultEncrypted);

            try
            {
                var result = _consecutivoService.GetConsecutivoById(resultMapped.ConsecutivoId);

                _context.Database.ExecuteSqlInterpolated($"sp_CreateVuelo {resultMapped.Procedencia}, {resultMapped.Destino}, {resultMapped.FechaHora}, {resultMapped.ConsecutivoId}, {resultMapped.AerolineaId}, {resultMapped.PuertaId}, {resultMapped.EstadoVueloId}, { (result != null ? _cryptWrite.EncryptSingleString($"{result.Prefijo}-{result.NumeroConsecutivo}") : null) }");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public VueloReadDto GetVueloById(int id)
        {
            var result = _context.Vuelos
                .FromSqlInterpolated<Vuelo>($"sp_GetVueloById {id}")
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<VueloReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }

        public int DeleteVueloById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteVueloById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public object GetVueloEntrantes() 
        {
            // Calls Stored Procedures.
            var queryVuelos = GetAllVuelos();
            var queryAerolineas = _aerolineaService.GetAllAerolineas();
            var queryEstados = _estadoVueloService.GetAllEstadoVuelos();
            var queryPuertas = _puertaService.GetAllPuertas();

            // Filters
            var query = (from vuelo in queryVuelos
                              join aerolinea in queryAerolineas on vuelo.AerolineaId equals aerolinea.AerolineaId
                              join estado in queryEstados on vuelo.EstadoVueloId equals estado.EstadoVueloId
                              join puerta in queryPuertas on vuelo.PuertaId equals puerta.PuertaId
                              where estado.Tipo == "Entrante"
                              select new
                              {
                                  VueloId = vuelo.VueloId,
                                  Procedencia = vuelo.Procedencia,
                                  Destino = vuelo.Destino,
                                  FechaHora = vuelo.FechaHora,
                                  Consecutivo = vuelo.Consecutivo,
                                  Aerolinea = aerolinea.Nombre,
                                  Puerta = puerta.NumeroPuerta,
                                  Estado = estado.Estado
                              }).ToList();
            return query;
        }

        public object GetVueloSalientes()
        {
            // Calls
            var queryVuelos = GetAllVuelos();
            var queryAerolineas = _aerolineaService.GetAllAerolineas();
            var queryEstados = _estadoVueloService.GetAllEstadoVuelos();
            var queryPuertas = _puertaService.GetAllPuertas();

            // Filters
            var query = (from vuelo in queryVuelos
                         join aerolinea in queryAerolineas on vuelo.AerolineaId equals aerolinea.AerolineaId
                         join estado in queryEstados on vuelo.EstadoVueloId equals estado.EstadoVueloId
                         join puerta in queryPuertas on vuelo.PuertaId equals puerta.PuertaId
                         where estado.Tipo == "Saliente"
                         select new
                         {
                             VueloId = vuelo.VueloId,
                             Procedencia = vuelo.Procedencia,
                             Destino = vuelo.Destino,
                             FechaHora = vuelo.FechaHora,
                             Consecutivo = vuelo.Consecutivo,
                             Aerolinea = aerolinea.Nombre,
                             Puerta = puerta.NumeroPuerta,
                             Estado = estado.Estado
                         }).ToList();
            return query;
        }

        public object GetVuelosDisponiblesCompraReserva()
        {
            // Calls to Stored Procedures
            var queryVuelos = GetAllVuelos();
            var queryAerolineas = _aerolineaService.GetAllAerolineas();
            var queryEstados = _estadoVueloService.GetAllEstadoVuelos();
            var queryPuertas = _puertaService.GetAllPuertas();

            // Filters
            var query = (from vuelo in queryVuelos
                         join aerolinea in queryAerolineas on vuelo.AerolineaId equals aerolinea.AerolineaId
                         join estado in queryEstados on vuelo.EstadoVueloId equals estado.EstadoVueloId
                         join puerta in queryPuertas on vuelo.PuertaId equals puerta.PuertaId
                         where estado.Estado == "Confirmado"
                         select new
                         {
                             VueloId = vuelo.VueloId,
                             Procedencia = vuelo.Procedencia,
                             Destino = vuelo.Destino,
                             FechaHora = vuelo.FechaHora,
                             Consecutivo = vuelo.Consecutivo,
                             Aerolinea = aerolinea.Nombre,
                             Puerta = puerta.NumeroPuerta,
                             Estado = estado.Estado
                         }).ToList();
            return query;
        }
    }
}
