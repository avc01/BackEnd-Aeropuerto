using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Puertas")]
    public class Puerta
    {
        [Key]
        public int PuertaId { get; set; }

        [Required]
        public int NumeroPuerta { get; set; }

        [Required]
        public string Detalle { get; set; }

        // Navigation properties

        [ForeignKey("Consecutivos")]
        [Required]
        public int ConsecutivoId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public ICollection<Vuelo> Vuelos { get; set; }
    }
}
