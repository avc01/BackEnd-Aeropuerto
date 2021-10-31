using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class VueloDto
    {
        public int VueloId { get; set; }

        public string Procedencia { get; set; }

        public string Destino { get; set; }

        public DateTime FechaHora { get; set; }

        public int ConsecutivoId { get; set; }

        public int AerolineaId { get; set; }

        public int PuertaId { get; set; }

        public int EstadoVueloId { get; set; }
    }
}
