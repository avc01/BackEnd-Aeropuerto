using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class TarjetaWriteDto
    {
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
        public string MesExp { get; set; }

        [Required]
        public string AnoExp { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
