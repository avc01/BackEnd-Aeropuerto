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

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class EstadoVueloService : IEstadoVueloService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<EstadoVueloReadDto> _cryptRead;
        private readonly ICrypt<EstadoVueloWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;

        public EstadoVueloService(AppDbContext context, IMapper mapper, ICrypt<EstadoVueloReadDto> cryptRead, ICrypt<EstadoVueloWriteDto> cryptWrite, IErrorService errorService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
        }

        public int CreateEstadoVuelo(EstadoVueloWriteDto estadoVuelo)
        {
            if (estadoVuelo == null)
            {
                throw new ArgumentNullException(nameof(estadoVuelo));
            }

            var resultEncrypted = _cryptWrite.EncryptData(estadoVuelo);

            var resultMapped = _mapper.Map<EstadoVuelo>(resultEncrypted);

            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateEstadoVuelo {resultMapped.Estado}, {resultMapped.Tipo}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteEstadoVueloById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteEstadoVueloById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public IEnumerable<EstadoVueloReadDto> GetAllEstadoVuelos()
        {
            var result = _context.EstadoVuelos.FromSqlInterpolated<EstadoVuelo>($"sp_GetEstadoVuelos")
                .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<EstadoVueloReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public EstadoVueloReadDto GetEstadoVueloById(int id)
        {
            var result = _context.EstadoVuelos
               .FromSqlInterpolated<EstadoVuelo>($"sp_GetEstadoVueloById {id}")
               .ToList()
               .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<EstadoVueloReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }
    }
}
