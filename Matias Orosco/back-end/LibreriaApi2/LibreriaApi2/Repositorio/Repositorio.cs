using LibreriaApi.Datos;
using LibreriaApi2.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApi2.Repositorio
{
    public class Repositorio<T> : IRepositorrio<T> where T : class
    {
        private readonly AplicationDbContext _db;
        internal DbSet<T>? dbSet;

        public Repositorio(AplicationDbContext db)
        {
            _db = db;
                this.dbSet = _db.Set<T>();
        }


        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
           await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> Filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if(!tracked)
            {
                query = query.AsNoTracking();
            }
            if (Filtro != null)
            {
                query= query.Where(Filtro);
               
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);

            }
            return await query.ToListAsync();

        }

        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }

       
    }
}
