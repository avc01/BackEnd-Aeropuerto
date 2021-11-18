using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Errores")]
    public class Error
    {
        [Key]
        public int ErrorId { get; set; }

        public string FechaHora { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Mensaje { get; set; }
    }
}
