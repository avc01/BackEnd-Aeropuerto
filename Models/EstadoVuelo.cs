using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("EstadoVuelos")]
    public class EstadoVuelo
    {
        [Key]
        public int EstadoVueloId { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Tipo { get; set; }

        // Navigation properties

        public ICollection<Vuelo> Vuelos { get; set; }
    }
}
