namespace ERP.Domain.Menus.Entidades
{
    public class MenuRol
    {
        public int IdMenu { get; set; }
        public Menu Menu { get; set; }

        public int IdRol { get; set; }
        // Se puede incluir navegación a la entidad Rol si es necesario
    }
}
