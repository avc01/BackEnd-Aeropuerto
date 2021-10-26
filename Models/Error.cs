using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Error
    {
        [Key]
        public int ErrorId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Mensaje { get; set; }
    }
}
