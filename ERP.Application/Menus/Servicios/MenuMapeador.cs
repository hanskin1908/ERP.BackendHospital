// Archivo: MenuMapeador.cs 
using System.Collections.Generic;
using System.Linq;

using ERP.Application.Menus.DTOs;

using ERP.Domain.Menus.Entidades;

namespace ERP.Application.Menus.Servicios
{
    public static class MenuMapeador
    {
        public static IEnumerable<MenuDTO> ConvertirADTO(IEnumerable<Menu> menus)
        {
            return menus.Select(m => new MenuDTO
            {
                IdMenu = m.IdMenu,
                Titulo = m.Titulo,
                Url = m.Url
            });
        }
    }
}
