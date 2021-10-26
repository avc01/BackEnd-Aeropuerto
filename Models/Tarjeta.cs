using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
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

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
