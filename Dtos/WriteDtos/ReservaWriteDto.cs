using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class ReservaWriteDto
    {
        [Required]
        public string FechaHora { get; set; }

        [Required]
        public int NumeroReservacion { get; set; }

        [Required]
        public string BookingId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public int ConsecutivoId { get; set; }

        [Required]
        public int VueloId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string? Consecutivo { get; set; }
    }
}
