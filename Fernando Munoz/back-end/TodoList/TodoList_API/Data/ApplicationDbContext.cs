using Microsoft.EntityFrameworkCore;
using TodoList_API.Models;

namespace TodoList_API.Data
{
    public class ApplicationDbContext :DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /* Con esta función usamos los datos que estan en el modelo para que 
         * cuando ejecutemos la migración
         * se agreguen o actualicen en la base de datos
         */
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea()
                {
                    Id = 1,
                    Titulo = "Sacar a pasear perros",
                    Detalle = "hola",
                    UsuarioCreador = 1,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    FechaEliminacion = DateTime.Now,

                },
                new Tarea()
                {
                    Id = 2,
                    Titulo = "Ir a hacer las compras",
                    Detalle = "hola",
                    UsuarioCreador = 2,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    FechaEliminacion = DateTime.Now,

                }
             );
        }

    }
}
