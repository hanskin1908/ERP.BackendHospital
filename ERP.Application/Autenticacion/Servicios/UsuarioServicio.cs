using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IEnumerable<UsuarioAdminDTO>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioRepositorio.ObtenerTodos();
            // Mapeo simple; en producción se recomienda usar AutoMapper o similar.
            return usuarios.Select(u => new UsuarioAdminDTO
            {
                IdUsuario = u.IdUsuario,
                NombreUsuario = u.NombreUsuario,
                IdsRoles = u.UsuarioRoles?.Select(ur => ur.IdRol).ToList() ?? new List<int>()
            });
        }

        public async Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _usuarioRepositorio.ObtenerPorNombreUsuarioAsync(nombreUsuario);
        }

        public async Task<UsuarioAdminDTO> ObtenerUsuarioPorId(int id)
        {
            var u = await _usuarioRepositorio.ObtenerPorId(id);
            if (u == null) return null;
            return new UsuarioAdminDTO
            {
                IdUsuario = u.IdUsuario,
                NombreUsuario = u.NombreUsuario,
                IdsRoles = u.UsuarioRoles?.Select(ur => ur.IdRol).ToList() ?? new List<int>()
            };
        }

        public async Task<UsuarioAdminDTO> CrearUsuario(CrearUsuarioDTO dto)
        {
            // Se genera el hash de la contraseña
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena);
            var usuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                ContrasenaHash = hash,
                UsuarioRoles = dto.IdsRoles.Select(idRol => new UsuarioRol { IdRol = idRol }).ToList()
            };

            await _usuarioRepositorio.Crear(usuario);
            return new UsuarioAdminDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                IdsRoles = usuario.UsuarioRoles.Select(ur => ur.IdRol).ToList()
            };
        }

        public async Task<UsuarioAdminDTO> ActualizarUsuario(ActualizarUsuarioDTO dto)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorId(dto.IdUsuario);
            if (usuario == null)
                return null;
            usuario.NombreUsuario = dto.NombreUsuario;
            // Se actualizan los roles (simplificado: se reemplazan)
            usuario.UsuarioRoles = dto.IdsRoles.Select(idRol => new UsuarioRol { IdRol = idRol, IdUsuario = dto.IdUsuario }).ToList();
            await _usuarioRepositorio.Actualizar(usuario);
            return new UsuarioAdminDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                IdsRoles = usuario.UsuarioRoles.Select(ur => ur.IdRol).ToList()
            };
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            return await _usuarioRepositorio.Eliminar(id);
        }
    }
}
