using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
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
        private readonly ICrypt<AerolineaReadDto> _crypt;

        public AerolineaService(AppDbContext context, IMapper mapper, ICrypt<AerolineaReadDto> crypt)
        {
            _context = context;
            _mapper = mapper;
            _crypt = crypt;
        }

        public IEnumerable<AerolineaReadDto> GetAllAerolineas()
        {
            var result = _context.Aerolineas.ToList();

            var resultMapped = _mapper.Map<IEnumerable<AerolineaReadDto>>(result);

            var resultDecrypted = _crypt.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public int CreateAerolinea(AerolineaReadDto aerolinea)
        {
            if (aerolinea == null)
            {
                throw new ArgumentNullException(nameof(aerolinea));
            }

            var resultEncrypted = _crypt.EncryptData(aerolinea);

            var resultMapped = _mapper.Map<Aerolinea>(resultEncrypted);

            _context.Aerolineas.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}
