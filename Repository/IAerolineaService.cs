using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IAerolineaService
    { 
        int CreateAerolinea(AerolineaWriteDto aerolinea);

        IEnumerable<AerolineaReadDto> GetAllAerolineas();

        AerolineaReadDto GetAerolineaById(int id);

        int DeleteAerolineaById(int id);
    }
}
