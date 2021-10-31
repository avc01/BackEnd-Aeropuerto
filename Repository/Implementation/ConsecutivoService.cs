using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
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
        private readonly ICrypt<ConsecutivoDto> _crypt;

        public ConsecutivoService(AppDbContext context, IMapper mapper, ICrypt<ConsecutivoDto> crypt)
        {
            _context = context;
            _mapper = mapper;
            _crypt = crypt;
        }

        public IEnumerable<ConsecutivoDto> GetAllConsecutivos()
        {
            var result = _context.Consecutivos.ToList();

            var resultMapped = _mapper.Map<IEnumerable<ConsecutivoDto>>(result);

            var resultDecrypted = _crypt.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public ConsecutivoDto GetConsecutivoById(int id) 
        {
            var result = _context.Consecutivos
                .FromSqlInterpolated<Consecutivo>($"sp_GetConsecutivoById {id}")
                .ToList()
                .FirstOrDefault();

            var resultMapped = _mapper.Map<ConsecutivoDto>(result);

            var resultDecrypted = _crypt.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }

        public int CreateConsecutivo(ConsecutivoDto consecutivo)
        {
            if (consecutivo == null)
            {
                throw new ArgumentNullException(nameof(consecutivo));
            }

            var resultEncrypted = _crypt.EncryptData(consecutivo);

            var resultMapped = _mapper.Map<Consecutivo>(resultEncrypted);

            _context.Consecutivos.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}
