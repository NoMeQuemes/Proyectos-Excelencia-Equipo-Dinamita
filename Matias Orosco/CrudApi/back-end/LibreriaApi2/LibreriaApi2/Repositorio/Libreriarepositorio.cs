using LibreriaApi.Datos;
using LibreriaApi.Modelos;
using LibreriaApi2.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApi2.Repositorio
{
    public class Libreriarepositorio : Repositorio<Libreria>, ILibreriaRepositorio
    {

        private readonly AplicationDbContext _db;
        public Libreriarepositorio(AplicationDbContext db) :base(db) 
        { 
            _db= db;
        }
        public async Task<Libreria> actualizar(Libreria entidad)
        {
            entidad.fechaUpdate= DateTime.Now;
            _db.librerias.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
