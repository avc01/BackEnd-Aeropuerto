using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class VueloWriteDto
    {
        [Required]
        public string Procedencia { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int ConsecutivoId { get; set; }

        [Required]
        public int AerolineaId { get; set; }

        [Required]
        public int PuertaId { get; set; }

        [Required]
        public int EstadoVueloId { get; set; }
    }
}
