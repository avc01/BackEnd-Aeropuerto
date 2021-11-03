using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IConsecutivoService
    {
        int CreateConsecutivo(ConsecutivoWriteDto consecutivo);

        IEnumerable<ConsecutivoReadDto> GetAllConsecutivos();

        ConsecutivoReadDto GetConsecutivoById(int id);
    }
}