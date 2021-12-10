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

        [Required]
        public long NumeroTarjeta { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int CodigoTarjeta { get; set; }

        [Required]
        public string MesExp { get; set; }

        [Required]
        public string AnoExp { get; set; }

        // Navigation properties

        [ForeignKey("Usuarios")]
        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
