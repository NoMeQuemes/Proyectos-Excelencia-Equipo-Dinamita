using System.ComponentModel.DataAnnotations;

namespace TodoList_API.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public int UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
