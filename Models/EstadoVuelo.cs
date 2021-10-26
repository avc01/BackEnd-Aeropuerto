using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class EstadoVuelo
    {
        [Key]
        public int EstadoVueloId { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Tipo { get; set; }

        // Navigation properties

        public List<Vuelo> Vuelos { get; set; }
    }
}
