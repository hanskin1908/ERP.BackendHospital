using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Servicios
{
    public class RolServicio : IRolServicio
    {
        private readonly IRolRepositorio _rolRepositorio;
        public RolServicio(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public async Task<IEnumerable<RolDTO>> ObtenerRoles()
        {
            var roles = await _rolRepositorio.ObtenerTodos();
            return roles.Select(r => new RolDTO
            {
                IdRol = r.IdRol,
                NombreRol = r.NombreRol
            });
        }

        public async Task<RolDTO> CrearRol(RolDTO dto)
        {
            var rol = new Rol { NombreRol = dto.NombreRol };
            await _rolRepositorio.Crear(rol);
            dto.IdRol = rol.IdRol;
            return dto;
        }

        public async Task<RolDTO> ActualizarRol(RolDTO dto)
        {
            var rol = await _rolRepositorio.ObtenerPorId(dto.IdRol);
            if (rol == null) return null;
            rol.NombreRol = dto.NombreRol;
            await _rolRepositorio.Actualizar(rol);
            return dto;
        }

        public async Task<bool> EliminarRol(int id)
        {
            return await _rolRepositorio.Eliminar(id);
        }
    }
}
