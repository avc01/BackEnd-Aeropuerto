using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Vuelo
    {  
        [Key]
        public int VueloId { get; set; }

        [Required]
        public string Procedencia { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        // Navigation properties

        [Required]
        public int ConsecutivoId { get; set; }
       
        [Required]
        public int AerolineaId { get; set; }
       
        [Required]
        public int PuertaId { get; set; }
       
        [Required]
        public int EstadoVueloId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public Aerolinea Aerolineas { get; set; }

        public Puerta Puertas { get; set; }

        public EstadoVuelo EstadoVuelos { get; set; }
    }
}
