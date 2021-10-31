using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class VueloService : IVueloService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VueloService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Vuelo> GetAllVuelos()
        {
            return _context.Vuelos.ToList();
        }

        public int CreateVuelo(Vuelo vuelo)
        {
            if (vuelo == null)
            {
                throw new ArgumentNullException(nameof(vuelo));
            }
            _context.Vuelos.Add(vuelo);
            return _context.SaveChanges();
        }
    }
}
