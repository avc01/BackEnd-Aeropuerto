using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IErrorService
    {
        int CreateError(ErrorWriteDto error);

        IEnumerable<ErrorReadDto> GetAllErrores();

        int DeleteErrorById(int id);
    }
}
