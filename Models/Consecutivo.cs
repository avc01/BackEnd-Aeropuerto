using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Consecutivos")]
    public class Consecutivo
    {
        [Key]
        public int ConsecutivoId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int NumeroConsecutivo { get; set; }
        
        public string? Prefijo { get; set; }
        
        public int? RangoInicial { get; set; }

        public int? RangoFinal { get; set; }

        // Navigation properties

        [NotMapped]
        public Aerolinea Aerolineas { get; set; }

        [NotMapped]
        public Puerta Puertas { get; set; }

        [NotMapped]
        public Pais Paises { get; set; }

        [NotMapped]
        public Compra Compras { get; set; }

        [NotMapped]
        public Reserva Reservas { get; set; }

        [NotMapped]
        public Vuelo Vuelos { get; set; }
    }
}
