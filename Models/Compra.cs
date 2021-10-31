using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Compras")]
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaHora { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        // Navigation properties

        [ForeignKey("Consecutivos")]
        [Required]
        public int ConsecutivoId { get; set; }

        [ForeignKey("Vuelos")]
        [Required]
        public int VueloId { get; set; }

        [ForeignKey("Usuarios")]
        [Required]
        public int UsuarioId { get; set; }

        [NotMapped]
        public Consecutivo Consecutivos { get; set; }

        [NotMapped]
        public Vuelo Vuelos { get; set; }

        [NotMapped]
        public Usuario Usuarios { get; set; }
    }
}
