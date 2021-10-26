using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public class AeropuertoService : IAeropuertoService
    {
        private readonly AppDbContext _context;

        public AeropuertoService(AppDbContext context)
        {
            _context = context;
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

        public IEnumerable<Consecutivo> GetAllConsecutivos()
        {
            return _context.Consecutivos.ToList();
        }

        public int CreateConsecutivo(Consecutivo consecutivo)
        {
            if (consecutivo == null)
            {
                throw new ArgumentNullException(nameof(consecutivo));
            }
            _context.Consecutivos.Add(consecutivo);
            return _context.SaveChanges();
        }
    }
}
