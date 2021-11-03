using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Models;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IAerolineaService
    { 
        int CreateAerolinea(AerolineaReadDto aerolinea);

        IEnumerable<AerolineaReadDto> GetAllAerolineas();
    }
}
