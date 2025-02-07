using System.Collections.Generic;

namespace ERP.Application.Autenticacion.DTOs
{
    public class UsuarioAdminDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public List<int> IdsRoles { get; set; }
    }
}
