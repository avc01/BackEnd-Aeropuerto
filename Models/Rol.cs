using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        public string Tipo { get; set; }

        // Navigation properties

        [ForeignKey("Usuarios")]
        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
