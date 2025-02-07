namespace ERP.Domain.Autenticacion.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        // Relación: roles asignados al usuario
        public List<UsuarioRol> UsuarioRoles { get; set; }
    }
}
// Archivo: Usuario.cs 
