using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Bitacoras")]
    public class Bitacora
    {
        [Key]
        public int BitacoraId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaHora { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Detalle { get; set; }

        // Navigation properties

        [ForeignKey("Usuarios")]
        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
