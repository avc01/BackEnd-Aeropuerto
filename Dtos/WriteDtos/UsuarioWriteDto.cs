using System.ComponentModel.DataAnnotations;

namespace BackEnd_Aeropuerto.Dtos.WriteDtos
{
    public class UsuarioWriteDto
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Compare("Contraseña")]
        [Required]
        public string ConfirmaContraseña { get; set; }

        [EmailAddress]
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Pregunta { get; set; }

        [Required]
        public string Respuesta { get; set; }
    }
}
