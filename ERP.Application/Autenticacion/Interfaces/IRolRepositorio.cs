using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IRolRepositorio
    {
        Task<IEnumerable<Rol>> ObtenerTodos();
        Task<Rol> ObtenerPorId(int id);
        Task Crear(Rol rol);
        Task Actualizar(Rol rol);
        Task<bool> Eliminar(int id);
    }
}
