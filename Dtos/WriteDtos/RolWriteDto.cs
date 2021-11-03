using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class RolWriteDto
    {
        [Required]
        public int Tipo { get; set; }
    }
}
