using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Compare("Contraseña")]
        [Required]
        public string ConfirmaContraseña { get; set; }

        [EmailAddress]
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Pregunta { get; set; }

        [Required]
        public string Respuesta { get; set; }

        // Navigation properties

        [Required]
        public int RolId { get; set; }

        public Rol Roles { get; set; }
    }
}
