using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IVueloService
    {
        int CreateVuelo(VueloWriteDto vuelo);

        IEnumerable<VueloReadDto> GetAllVuelos();
    }
}
