// Archivo: MenuRepositorio.cs 
using System.Collections.Generic;
using System.Threading.Tasks;


using ERP.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ERP.Application.Menus.Interfaces;
using ERP.Domain.Menus.Entidades;

namespace ERP.Infrastructure.Menus.Repositorios
{
    public class MenuRepositorio : IMenuRepositorio
    {
        private readonly ContextoDatos _contexto;
        public MenuRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<int>> ObtenerRolesDelUsuario(int idUsuario)
        {
            // Consultar la tabla UsuarioRol para obtener los IdRol asociados al usuario
            var roles = await _contexto.UsuarioRoles
                .Where(ur => ur.IdUsuario == idUsuario)
                .Select(ur => ur.IdRol)
                .ToListAsync();
            return roles;
        }

        public async Task<IEnumerable<Menu>> ObtenerMenusPorRoles(IEnumerable<int> roles)
        {
            // Consultar la relación MenuRol para obtener los menús permitidos
            var menus = await _contexto.MenuRoles
                .Where(mr => roles.Contains(mr.IdRol))
                .Select(mr => mr.Menu)
                .Distinct()
                .ToListAsync();
            return menus;
        }
    }
}
