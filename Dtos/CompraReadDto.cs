using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class CompraReadDto
    {
        public int CompraId { get; set; }

        public DateTime FechaHora { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public int ConsecutivoId { get; set; }

        public int VueloId { get; set; }

        public int UsuarioId { get; set; }
    }
}
