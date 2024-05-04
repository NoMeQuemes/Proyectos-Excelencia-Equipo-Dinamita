using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaApi.Modelos
{
    public class Libreria
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Nombre { get; set; }
         public required string Detalles { get; set; }
        public int Paginas { get; set; }

        public int Totales { get; set; }

        public required string Creador { get; set; }
        public DateTime fecha { get; set; }

        public DateTime fechaUpdate { get; set; }


    }
}
