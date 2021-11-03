namespace BackEnd_Aeropuerto.Dtos
{
    public class ConsecutivoReadDto
    {
        public int ConsecutivoId { get; set; }

        public string Descripcion { get; set; }

        public int NumeroConsecutivo { get; set; }

        public string? Prefijo { get; set; }

        public int? RangoInicial { get; set; }

        public int? RangoFinal { get; set; }
    }
}
