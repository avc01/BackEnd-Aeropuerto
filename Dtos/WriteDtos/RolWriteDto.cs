using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class RolWriteDto
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
