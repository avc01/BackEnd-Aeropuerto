using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class TarjetaReadDto
    {
        public int TarjetaId { get; set; }

        public int NumeroTarjeta { get; set; }

        public string Marca { get; set; }

        public string Tipo { get; set; }

        public int CodigoTarjeta { get; set; }

        public DateTime FechaExp { get; set; }

        public int UsuarioId { get; set; }
    }
}
