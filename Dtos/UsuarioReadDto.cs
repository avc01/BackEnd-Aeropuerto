namespace BackEnd_Aeropuerto.Dtos
{
    public class UsuarioReadDto
    {
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public string ConfirmaContraseña { get; set; }

        public string Correo { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; }
    }
}
