using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Bitacora
    {
        [Key]
        public int BitacoraId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Detalle { get; set; }

        // Navigation properties

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
