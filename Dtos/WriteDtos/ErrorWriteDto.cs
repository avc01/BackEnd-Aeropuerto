using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class ErrorWriteDto
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public string Mensaje { get; set; }
    }
}
