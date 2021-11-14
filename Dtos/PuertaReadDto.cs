namespace BackEnd_Aeropuerto.Dtos
{
    public class PuertaReadDto
    {
        public int PuertaId { get; set; }

        public int NumeroPuerta { get; set; }

        public string Detalle { get; set; }

        public int ConsecutivoId { get; set; }

        public string? Consecutivo { get; set; }
    }
}
