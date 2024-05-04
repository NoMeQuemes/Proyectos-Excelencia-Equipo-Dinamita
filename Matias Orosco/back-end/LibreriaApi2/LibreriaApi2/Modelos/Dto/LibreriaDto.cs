using System.ComponentModel.DataAnnotations;

namespace LibreriaApi.Modelos.Dto
{
    public class LibreriaDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Detalles { get; set; }
        public int Paginas { get; set; }

        public int Totales { get; set; }

        public required string Creador { get; set; }
       
    }
}
