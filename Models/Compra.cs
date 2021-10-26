using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        // Navigation properties

        [Required]
        public int ConsecutivoId { get; set; }

        [Required]
        public int VueloId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public Vuelo Vuelos { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
