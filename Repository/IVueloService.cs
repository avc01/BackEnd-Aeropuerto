using BackEnd_Aeropuerto.Dtos;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IVueloService
    {
        int CreateVuelo(VueloReadDto vuelo);

        IEnumerable<VueloReadDto> GetAllVuelos();
    }
}
