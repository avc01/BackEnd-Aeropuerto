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
    public class PaisService : IPaisService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<PaisReadDto> _cryptRead;
        private readonly ICrypt<PaisWriteDto> _cryptWrite;
        private readonly IConsecutivoService _consecutivoService;

        public PaisService(AppDbContext context, IMapper mapper, ICrypt<PaisReadDto> cryptRead, ICrypt<PaisWriteDto> cryptWrite, IConsecutivoService consecutivoService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _consecutivoService = consecutivoService;
        }

        public int CreatePais(PaisWriteDto pais)
        {
            if (pais == null)
            {
                throw new ArgumentNullException(nameof(pais));
            }

            var resultEncrypted = _cryptWrite.EncryptData(pais);

            var resultMapped = _mapper.Map<Pais>(resultEncrypted);

            try
            {
                var result = _consecutivoService.GetConsecutivoById(resultMapped.ConsecutivoId);

                _context.Database.ExecuteSqlInterpolated($"sp_CreatePais {resultMapped.Nombre}, {resultMapped.ConsecutivoId}, { (result != null ? _cryptWrite.EncryptSingleString($"{result.Prefijo}-{result.NumeroConsecutivo}") : null) }");

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeletePaisById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeletePaisById {id}");

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<PaisReadDto> GetAllPaises()
        {
            var result = _context.Paises.FromSqlInterpolated<Pais>($"sp_GetPaises")
                .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<PaisReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public PaisReadDto GetPaisById(int id)
        {
            var result = _context.Paises
                .FromSqlInterpolated<Pais>($"sp_GetPaisById {id}")
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<PaisReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }
    }
}
