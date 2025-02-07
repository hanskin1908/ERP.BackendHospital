// Archivo: IMenuRepositorio.cs 
using ERP.Domain.Menus.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ERP.Application.Menus.Interfaces
{
    public interface IMenuRepositorio
    {
        Task<IEnumerable<int>> ObtenerRolesDelUsuario(int idUsuario);
        Task<IEnumerable<Menu>> ObtenerMenusPorRoles(IEnumerable<int> roles);
    }
}
