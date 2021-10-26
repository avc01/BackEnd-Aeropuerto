using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Usuarios")]
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

        public ICollection<Compra> Compras { get; set; }

        public ICollection<Reserva> Reservas { get; set; }

        public ICollection<Tarjeta> Tarjetas { get; set; }

        public ICollection<Bitacora> Bitacoras { get; set; }

        public ICollection<Rol> Roles { get; set; }
    }
}
