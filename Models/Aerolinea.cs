using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Aerolineas")]
    public class Aerolinea
    {
        [Key]
        public int AerolineaId { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Navigation properties

        [ForeignKey("Consecutivos")]
        [Required]
        public int ConsecutivoId { get; set; }

        public Consecutivo Consecutivos { get; set; }











        public ICollection<Vuelo> Vuelos { get; set; }
    }
}
