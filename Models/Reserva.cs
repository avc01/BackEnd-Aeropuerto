using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int NumeroReservacion { get; set; }

        [Required]
        public string BookingId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double Total { get; set; }

        // Navigation properties

        [Required]
        public int ConsecutivoId { get; set; }

        [Required]
        public int VueloId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Consecutivo Consecutivos { get; set; }

        public Vuelo Vuelos { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
