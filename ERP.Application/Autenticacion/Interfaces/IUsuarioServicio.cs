using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<IEnumerable<UsuarioAdminDTO>> ObtenerUsuarios();
        Task<UsuarioAdminDTO> ObtenerUsuarioPorId(int id);
        Task<UsuarioAdminDTO> CrearUsuario(CrearUsuarioDTO dto);
        Task<UsuarioAdminDTO> ActualizarUsuario(ActualizarUsuarioDTO dto);
        Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
        Task<bool> EliminarUsuario(int id);
    }
}
