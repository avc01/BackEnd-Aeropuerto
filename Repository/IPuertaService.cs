using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IPuertaService
    {
        int CreatePuerta(PuertaWriteDto puerta);

        IEnumerable<PuertaReadDto> GetAllPuertas();

        PuertaReadDto GetPuertaById(int id);

        int DeletePuertaById(int id);
    }
}
