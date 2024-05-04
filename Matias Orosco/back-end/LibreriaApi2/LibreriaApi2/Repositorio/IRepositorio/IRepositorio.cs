using System.Linq.Expressions;


namespace LibreriaApi2.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    
    {

        Task Crear(T entidad);

      Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null);

        Task<T> Obtener(Expression<Func<T, bool>> Filtro = null, bool tracked = true);

       
        Task Grabar();

      Task Remover(T entidad);








    }
}


