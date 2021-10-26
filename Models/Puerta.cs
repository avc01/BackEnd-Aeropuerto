using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Puerta
    {
        [Key]
        public int PuertaId { get; set; }

        [Required]
        public int NumeroPuerta { get; set; }

        [Required]
        public string Detalle { get; set; }

        // Navigation properties

        [Required]
        public int ConsecutivoId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public List<Vuelo> Vuelos { get; set; }
    }
}
