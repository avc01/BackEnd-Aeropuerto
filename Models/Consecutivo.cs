using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Index(nameof(NumeroConsecutivo), IsUnique = true)]
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

        public Aerolinea Aerolineas { get; set; }

        public Puerta Puertas { get; set; }

        public Pais Paises { get; set; }

        public Compra Compras { get; set; }

        public Reserva Reservas { get; set; }

        public Vuelo Vuelos { get; set; }
    }
}
