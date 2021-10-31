using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Tarjetas")]
    public class Tarjeta
    {
        [Key]
        public int TarjetaId { get; set; }

        [CreditCard]
        [Required]
        public int NumeroTarjeta { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int CodigoTarjeta { get; set; }

        [Required]
        public DateTime FechaExp { get; set; }

        // Navigation properties

        [ForeignKey("Usuarios")]
        [Required]
        public int UsuarioId { get; set; }

        [NotMapped]
        public Usuario Usuarios { get; set; }
    }
}
