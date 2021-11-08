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

        public ConsecutivoService(AppDbContext context, IMapper mapper, ICrypt<ConsecutivoReadDto> cryptRead, ICrypt<ConsecutivoWriteDto> cryptWrite)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
        }

        public IEnumerable<ConsecutivoReadDto> GetAllConsecutivos()
        {
            var result = _context.Consecutivos.FromSqlInterpolated<Consecutivo>($"sp_GetConsecutivos")
                .ToList();

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

            _context.Consecutivos.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}
