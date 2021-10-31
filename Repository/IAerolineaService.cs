using BackEnd_Aeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IAerolineaService
    { 
        int CreateAerolinea(Aerolinea aerolinea);

        IEnumerable<Aerolinea> GetAllAerolineas();
    }
}
