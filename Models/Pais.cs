using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Aeropuerto.Models
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Navigation properties

        [ForeignKey("Consecutivos")]
        [Required]
        public int ConsecutivoId { get; set; }

        [NotMapped]
        public Consecutivo Consecutivos { get; set; }
    }
}
