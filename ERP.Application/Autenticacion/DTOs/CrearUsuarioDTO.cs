namespace ERP.Application.Autenticacion.DTOs
{
    public class CrearUsuarioDTO
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public System.Collections.Generic.List<int> IdsRoles { get; set; }
    }
}
