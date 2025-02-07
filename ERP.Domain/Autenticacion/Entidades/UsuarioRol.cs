namespace ERP.Domain.Autenticacion.Entidades
{
    public class UsuarioRol
    {
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
// Archivo: UsuarioRol.cs 
