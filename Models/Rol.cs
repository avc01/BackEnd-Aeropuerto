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
        public int Tipo { get; set; }

        // Navigation properties

        [NotMapped]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
