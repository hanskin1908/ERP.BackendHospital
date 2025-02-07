using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task<Usuario> ObtenerPorId(int id);
        Task Crear(Usuario usuario);
        Task Actualizar(Usuario usuario);
        Task<bool> Eliminar(int id);

        Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
    }
}
