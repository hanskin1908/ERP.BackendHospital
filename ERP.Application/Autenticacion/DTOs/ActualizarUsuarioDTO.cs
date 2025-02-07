namespace ERP.Application.Autenticacion.DTOs
{
    public class ActualizarUsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public System.Collections.Generic.List<int> IdsRoles { get; set; }
    }
}
