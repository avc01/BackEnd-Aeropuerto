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
    public class VueloService : IVueloService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<VueloReadDto> _cryptRead;
        private readonly ICrypt<VueloWriteDto> _cryptWrite;

        public VueloService(AppDbContext context, IMapper mapper, ICrypt<VueloReadDto> cryptRead, ICrypt<VueloWriteDto> cryptWrite)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
        }

        public IEnumerable<VueloReadDto> GetAllVuelos()
        {
            var result = _context.Vuelos.ToList();

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

            _context.Vuelos.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}
