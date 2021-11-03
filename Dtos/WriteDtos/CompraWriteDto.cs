using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class CompraWriteDto
    {
        [Required]
        public double Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int ConsecutivoId { get; set; }

        [Required]
        public int VueloId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
