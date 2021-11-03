using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class ReservaReadDto
    {
        public int ReservaId { get; set; }

        public DateTime FechaHora { get; set; }

        public int NumeroReservacion { get; set; }

        public string BookingId { get; set; }

        public int Cantidad { get; set; }

        public double Total { get; set; }

        public int ConsecutivoId { get; set; }

        public int VueloId { get; set; }

        public int UsuarioId { get; set; }
    }
}
