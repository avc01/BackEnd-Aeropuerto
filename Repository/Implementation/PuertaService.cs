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
    public class PuertaService : IPuertaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<PuertaReadDto> _cryptRead;
        private readonly ICrypt<PuertaWriteDto> _cryptWrite;
        private readonly IConsecutivoService _consecutivoService;

        public PuertaService(AppDbContext context, IMapper mapper, ICrypt<PuertaReadDto> cryptRead, ICrypt<PuertaWriteDto> cryptWrite, IConsecutivoService consecutivoService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _consecutivoService = consecutivoService;
        }

        public int CreatePuerta(PuertaWriteDto puerta)
        {
            if (puerta == null)
            {
                throw new ArgumentNullException(nameof(puerta));
            }

            var resultEncrypted = _cryptWrite.EncryptData(puerta);

            var resultMapped = _mapper.Map<Puerta>(resultEncrypted);

            try
            {
                var result = _consecutivoService.GetConsecutivoById(resultMapped.ConsecutivoId);

                _context.Database.ExecuteSqlInterpolated($"sp_CreatePuerta {resultMapped.NumeroPuerta}, {resultMapped.Detalle}, {resultMapped.ConsecutivoId}, { (result != null ? _cryptWrite.EncryptSingleString($"{result.Prefijo}-{result.NumeroConsecutivo}") : null) }");

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeletePuertaById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeletePuertaById {id}");

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<PuertaReadDto> GetAllPuertas()
        {
            var result = _context.Puertas.FromSqlInterpolated<Puerta>($"sp_GetPuertas")
                .ToList();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<IEnumerable<PuertaReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public PuertaReadDto GetPuertaById(int id)
        {
            var result = _context.Puertas
               .FromSqlInterpolated<Puerta>($"sp_GetPuertaById {id}")
               .ToList()
               .FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var resultMapped = _mapper.Map<PuertaReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }
    }
}
