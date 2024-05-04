
using LibreriaApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApi.Datos
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
           
        }

        public DbSet<Libreria> librerias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libreria>().HasData(

               new Libreria()
               {
                   Id = 1,
                   Nombre = "Superman",
                   Detalles = "Es fuerte",
                   Paginas = 3,
                   Totales = 10,
                   Creador = "Yo",
                   fecha = DateTime.Now,
                   fechaUpdate = DateTime.Now



               },


                new Libreria()
                {
                    Id = 2,
                    Nombre = "Iroman",
                    Detalles = "Es fuerte",
                    Paginas = 4,
                    Totales = 14,
                    Creador = "Yo2",
                    fecha = DateTime.Now,
                    fechaUpdate = DateTime.Now



                }
                );
                
                
        }

    }
}