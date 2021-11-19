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
    public class AerolineaService : IAerolineaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<AerolineaReadDto> _cryptRead;
        private readonly ICrypt<AerolineaWriteDto> _cryptWrite;
        private readonly IConsecutivoService _consecutivoService;
        private readonly IErrorService _errorService;

        public AerolineaService(AppDbContext context, IMapper mapper, ICrypt<AerolineaReadDto> cryptRead, ICrypt<AerolineaWriteDto> cryptWrite, IConsecutivoService consecutivoService, IErrorService errorService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _consecutivoService = consecutivoService;
            _errorService = errorService;
        }

        public IEnumerable<AerolineaReadDto> GetAllAerolineas()
        {
            var result = _context.Aerolineas.FromSqlInterpolated<Aerolinea>($"sp_GetAerolineas")
               .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<AerolineaReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public AerolineaReadDto GetAerolineaById(int id)
        {
            var result = _context.Aerolineas
                .FromSqlInterpolated<Aerolinea>($"sp_GetAerolineaById {id}")
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<AerolineaReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }

        public int CreateAerolinea(AerolineaWriteDto aerolinea)
        {
            if (aerolinea == null)
            {
                throw new ArgumentNullException(nameof(aerolinea));
            }

            var resultEncrypted = _cryptWrite.EncryptData(aerolinea);

            var resultMapped = _mapper.Map<Aerolinea>(resultEncrypted);

            try
            {
                var result = _consecutivoService.GetConsecutivoById(resultMapped.ConsecutivoId);

                _context.Database.ExecuteSqlInterpolated($"sp_CreateAerolinea {resultMapped.Nombre}, {resultMapped.ConsecutivoId}, { (result != null ? _cryptWrite.EncryptSingleString($"{result.Prefijo}-{result.NumeroConsecutivo}"):null) }");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteAerolineaById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteAerolineaById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message});

                return 0;
            }
        }
    }
}
