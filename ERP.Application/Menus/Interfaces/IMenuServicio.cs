// Archivo: IMenuServicio.cs 
using System.Collections.Generic;
using System.Threading.Tasks;

using ERP.Application.Menus.DTOs;

namespace ERP.Application.Menus.Interfaces
{
    public interface IMenuServicio
    {
        Task<IEnumerable<MenuDTO>> ObtenerMenuPorIdUsuario(int idUsuario);
    }
}
