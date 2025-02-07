// Archivo: MenuServicio.cs 
using ERP.Application.Menus.DTOs;
using ERP.Application.Menus.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ERP.Application.Menus.Servicios
{
    public class MenuServicio : IMenuServicio
    {
        private readonly IMenuRepositorio _repositorioMenu;

        public MenuServicio(IMenuRepositorio repositorioMenu)
        {
            _repositorioMenu = repositorioMenu;
        }

        public async Task<IEnumerable<MenuDTO>> ObtenerMenuPorIdUsuario(int idUsuario)
        {
            IEnumerable<int> roles = await _repositorioMenu.ObtenerRolesDelUsuario(idUsuario);
            IEnumerable<Domain.Menus.Entidades.Menu> menus = await _repositorioMenu.ObtenerMenusPorRoles(roles);
            return MenuMapeador.ConvertirADTO(menus);
        }
    }
}
