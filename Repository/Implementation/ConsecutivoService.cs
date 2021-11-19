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
    public class ConsecutivoService : IConsecutivoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<ConsecutivoReadDto> _cryptRead;
        private readonly ICrypt<ConsecutivoWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;

        public ConsecutivoService(AppDbContext context, IMapper mapper, ICrypt<ConsecutivoReadDto> cryptRead, ICrypt<ConsecutivoWriteDto> cryptWrite, IErrorService errorService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
        }

        public IEnumerable<ConsecutivoReadDto> GetAllConsecutivos()
        {
            var result = _context.Consecutivos.FromSqlInterpolated<Consecutivo>($"sp_GetConsecutivos")
                .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<ConsecutivoReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public ConsecutivoReadDto GetConsecutivoById(int id) 
        {
            var result = _context.Consecutivos
                .FromSqlInterpolated<Consecutivo>($"sp_GetConsecutivoById {id}")
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<ConsecutivoReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }

        public int CreateConsecutivo(ConsecutivoWriteDto consecutivo)
        {
            if (consecutivo == null)
            {
                throw new ArgumentNullException(nameof(consecutivo));
            }

            var resultEncrypted = _cryptWrite.EncryptData(consecutivo);

            var resultMapped = _mapper.Map<Consecutivo>(resultEncrypted);

            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateConsecutivo {resultMapped.Descripcion}, {resultMapped.NumeroConsecutivo}, {resultMapped.Prefijo}, {resultMapped.RangoInicial}, {resultMapped.RangoFinal}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteConsecutivoById(int id) 
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteConsecutivoById {id}");

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
