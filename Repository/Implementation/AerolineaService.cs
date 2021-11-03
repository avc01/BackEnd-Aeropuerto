using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Models;
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

        public AerolineaService(AppDbContext context, IMapper mapper, ICrypt<AerolineaReadDto> cryptRead, ICrypt<AerolineaWriteDto> cryptWrite)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
        }

        public IEnumerable<AerolineaReadDto> GetAllAerolineas()
        {
            var result = _context.Aerolineas.ToList();

            var resultMapped = _mapper.Map<IEnumerable<AerolineaReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

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

            _context.Aerolineas.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}
