using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Autenticacion.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ContextoDatos _contexto;
        public UsuarioRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            return await _contexto.Usuarios
                .Include(u => u.UsuarioRoles)
                .ToListAsync();
        }
        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await _contexto.Usuarios
                .Include(u => u.UsuarioRoles)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _contexto.Usuarios
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task Crear(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }
        public async Task Actualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }
        public async Task<bool> Eliminar(int id)
        {
            var usuario = await ObtenerPorId(id);
            if (usuario == null) return false;
            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
