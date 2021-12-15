using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class CompraWriteDto
    {
        public string FechaHora { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public int ConsecutivoId { get; set; }

        [Required]
        public int VueloId { get; set; }

        public int UsuarioId { get; set; }

        public string Consecutivo { get; set; }

        [Required]
        public string CorreoUsuario { get; set; }
    }
}
