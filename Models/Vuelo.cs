using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Vuelos")]
    public class Vuelo
    {  
        [Key]
        public int VueloId { get; set; }

        [Required]
        public string Procedencia { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public string FechaHora { get; set; }

        // Navigation properties

        [ForeignKey("Consecutivos")]
        [Required]
        public int ConsecutivoId { get; set; }

        [ForeignKey("Aerolineas")]
        [Required]
        public int AerolineaId { get; set; }

        [ForeignKey("Puertas")]
        [Required]
        public int PuertaId { get; set; }

        [ForeignKey("EstadoVuelos")]
        [Required]
        public int EstadoVueloId { get; set; }

        public string? Consecutivo { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public Aerolinea Aerolineas { get; set; }

        public Puerta Puertas { get; set; }

        public EstadoVuelo EstadoVuelos { get; set; }
    }
}
