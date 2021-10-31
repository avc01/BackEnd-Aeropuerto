﻿using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
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
        private readonly ICrypt<VueloDto> _crypt;

        public VueloService(AppDbContext context, IMapper mapper, ICrypt<VueloDto> crypt)
        {
            _context = context;
            _mapper = mapper;
            _crypt = crypt;
        }

        public IEnumerable<VueloDto> GetAllVuelos()
        {
            var result = _context.Vuelos.ToList();

            var resultMapped = _mapper.Map<IEnumerable<VueloDto>>(result);

            var resultDecrypted = _crypt.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public int CreateVuelo(VueloDto vuelo)
        {
            if (vuelo == null)
            {
                throw new ArgumentNullException(nameof(vuelo));
            }

            var resultEncrypted = _crypt.EncryptData(vuelo);

            var resultMapped = _mapper.Map<Vuelo>(resultEncrypted);

            _context.Vuelos.Add(resultMapped);

            return _context.SaveChanges();
        }
    }
}