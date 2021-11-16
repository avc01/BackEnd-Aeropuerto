using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IEstadoVueloService
    {
        int CreateEstadoVuelo(EstadoVueloWriteDto estadoVuelo);

        IEnumerable<EstadoVueloReadDto> GetAllEstadoVuelos();

        EstadoVueloReadDto GetEstadoVueloById(int id);

        int DeleteEstadoVueloById(int id);
    }
}
