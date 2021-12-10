using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class TarjetaReadDto
    {
        public int TarjetaId { get; set; }

        public long NumeroTarjeta { get; set; }

        public string Marca { get; set; }

        public string Tipo { get; set; }

        public int CodigoTarjeta { get; set; }

        public string MesExp { get; set; }

        public string AnoExp { get; set; }

        public int UsuarioId { get; set; }
    }
}
