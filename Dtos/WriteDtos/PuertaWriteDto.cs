using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class PuertaWriteDto
    {
        [Required]
        public int NumeroPuerta { get; set; }

        [Required]
        public string Detalle { get; set; }

        [Required]
        public int ConsecutivoId { get; set; }
    }
}
