using System.Collections.Generic;

namespace ERP.Domain.Menus.Entidades
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        // Relación: roles asociados a este menú
        public List<MenuRol> MenuRoles { get; set; }
    }
}
