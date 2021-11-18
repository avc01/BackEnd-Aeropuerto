using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class BitacoraReadDto
    {
        public int BitacoraId { get; set; }

        public string FechaHora { get; set; }

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        public int UsuarioId { get; set; }
    }
}
