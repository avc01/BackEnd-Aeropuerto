using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Aerolinea
    {
        [Key]
        public int AerolineaId { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Navigation properties

        [Required]
        public int ConsecutivoId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public List<Vuelo> Vuelos { get; set; }
    }
}
