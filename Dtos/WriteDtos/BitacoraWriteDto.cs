using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class BitacoraWriteDto
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Detalle { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
