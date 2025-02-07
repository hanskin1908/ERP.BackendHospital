using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IRolServicio
    {
        Task<IEnumerable<RolDTO>> ObtenerRoles();
        Task<RolDTO> CrearRol(RolDTO dto);
        Task<RolDTO> ActualizarRol(RolDTO dto);
        Task<bool> EliminarRol(int id);
    }
}
