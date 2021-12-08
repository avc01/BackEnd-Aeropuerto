using BackEnd_Aeropuerto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IReservaService
    {
        int CreateReserva(int cantidad, double total, int vueloId, string correo);

        IEnumerable<ReservaReadDto> GetAllReservas();

        object GetReservasByEmail(string correo);

        int DeleteReservaById(int id);
    }
}
