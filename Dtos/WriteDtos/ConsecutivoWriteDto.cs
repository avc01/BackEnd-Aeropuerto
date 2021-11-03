using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class ConsecutivoWriteDto
    {
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int NumeroConsecutivo { get; set; }

        public string? Prefijo { get; set; }

        public int? RangoInicial { get; set; }

        public int? RangoFinal { get; set; }
    }
}
