using LibreriaApi.Modelos;

namespace LibreriaApi2.Repositorio.IRepositorio
{
    public interface ILibreriaRepositorio:IRepositorio<Libreria>
    {
        Task<Libreria> actualizar(Libreria entidad);
    }
}
