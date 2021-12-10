using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface ITarjetaService
    {
        int RegistrarTarjeta(TarjetaWriteDto tarjeta);

        IEnumerable<TarjetaReadDto> GetAllTarjetas();

        IEnumerable<TarjetaReadDto> GetTarjetasByCorreoUsuario(string correo);

        int DeleteTarjetaById(int tarjetaId);
    }
}
