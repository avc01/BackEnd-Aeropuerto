using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class AerolineaService : IAerolineaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AerolineaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Aerolinea> GetAllAerolineas()
        {
            return _context.Aerolineas.ToList();
        }

        public int CreateAerolinea(Aerolinea aerolinea)
        {
            if (aerolinea == null)
            {
                throw new ArgumentNullException(nameof(aerolinea));
            }
            _context.Aerolineas.Add(aerolinea);
            return _context.SaveChanges();
        }
    }
}
