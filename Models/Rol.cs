using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        public int Tipo { get; set; }

        // Navigation properties

        public Usuario Usuarios { get; set; }
    }
}
