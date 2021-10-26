#pragma warning disable CS8632

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Consecutivo
    {
        [Key]
        public int ConsecutivoId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int NumeroConsecutivo { get; set; }
        
        public string? Prefijo { get; set; }
        
        public int? RangoInicial { get; set; }

        public int? RangoFinal { get; set; }
    }
}
