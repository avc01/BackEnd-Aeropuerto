using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Models;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IConsecutivoService
    {
        int CreateConsecutivo(ConsecutivoReadDto consecutivo);

        IEnumerable<ConsecutivoReadDto> GetAllConsecutivos();

        ConsecutivoReadDto GetConsecutivoById(int id);
    }
}