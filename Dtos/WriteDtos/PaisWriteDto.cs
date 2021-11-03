using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class PaisWriteDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int ConsecutivoId { get; set; }
    }
}
