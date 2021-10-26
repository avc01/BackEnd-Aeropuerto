using BackEnd_Aeropuerto.Models;
using System.Collections.Generic;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IAeropuertoService
    {
        int CreateVuelo(Vuelo vuelo);

        IEnumerable<Vuelo> GetAllVuelos();

        int CreateAerolinea(Aerolinea aerolinea);

        IEnumerable<Aerolinea> GetAllAerolineas();

        int CreateConsecutivo(Consecutivo consecutivo);

        IEnumerable<Consecutivo> GetAllConsecutivos();
    }
}