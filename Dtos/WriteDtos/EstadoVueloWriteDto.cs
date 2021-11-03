using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class EstadoVueloWriteDto
    {
        [Required]
        public string Estado { get; set; }

        [Required]
        public string Tipo { get; set; }
    }
}
