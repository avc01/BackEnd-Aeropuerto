using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IPaisService
    {
        int CreatePais(PaisWriteDto pais);

        IEnumerable<PaisReadDto> GetAllPaises();

        PaisReadDto GetPaisById(int id);

        int DeletePaisById(int id);
    }
}
