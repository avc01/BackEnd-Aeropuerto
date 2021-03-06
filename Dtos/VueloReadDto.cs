using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class VueloReadDto
    {
        public int VueloId { get; set; }

        public string Procedencia { get; set; }

        public string Destino { get; set; }

        public string FechaHora { get; set; }

        public int ConsecutivoId { get; set; }

        public int AerolineaId { get; set; }

        public int PuertaId { get; set; }

        public int EstadoVueloId { get; set; }

        public string? Consecutivo { get; set; }
    }
}
