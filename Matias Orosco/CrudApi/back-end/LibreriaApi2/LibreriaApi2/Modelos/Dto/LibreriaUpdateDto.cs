using System.ComponentModel.DataAnnotations;

namespace LibreriaApi.Modelos.Dto
{
    public class LibreriaUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required string Detalles { get; set; }
        [Required]
        public int Paginas { get; set; }
        [Required]

        public int Totales { get; set; }
        [Required]
        public required string Creador { get; set; }
       
    }
}
