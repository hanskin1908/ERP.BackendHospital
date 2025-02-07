using System;
using System.Linq;
using System.Threading.Tasks;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Domain.Menus.Entidades;
using ERP.Domain.Suscripcions.Entidades;
using ERP.Domain.Pacientes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task Inicializar(ContextoDatos contexto)
        {
            // Aplica las migraciones pendientes (si no se han aplicado ya)
            await contexto.Database.MigrateAsync();

            // -------------------------
            // SEMILLA - Módulo Autenticación
            // -------------------------
            if (!contexto.Roles.Any())
            {
                var rolAdmin = new Rol { NombreRol = "Administrador" };
                var rolMedico = new Rol { NombreRol = "Medico" };
                var rolRecep = new Rol { NombreRol = "Recepcionista" };

                contexto.Roles.AddRange(rolAdmin, rolMedico, rolRecep);
                await contexto.SaveChangesAsync();
            }

            if (!contexto.Usuarios.Any())
            {
                // Obtener roles necesarios
                var rolAdmin = contexto.Roles.FirstOrDefault(r => r.NombreRol == "Administrador");
                var rolMedico = contexto.Roles.FirstOrDefault(r => r.NombreRol == "Medico");

                // Usuario Administrador
                var usuarioAdmin = new Usuario
                {
                    NombreUsuario = "admin",
                    // Se utiliza BCrypt para generar el hash de la contraseña "admin123"
                    ContrasenaHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    UsuarioRoles = new System.Collections.Generic.List<UsuarioRol>()
                };

                if (rolAdmin != null)
                    usuarioAdmin.UsuarioRoles.Add(new UsuarioRol { IdRol = rolAdmin.IdRol });

                // Usuario Médico
                var usuarioMedico = new Usuario
                {
                    NombreUsuario = "medico1",
                    ContrasenaHash = BCrypt.Net.BCrypt.HashPassword("medico123"),
                    UsuarioRoles = new System.Collections.Generic.List<UsuarioRol>()
                };

                if (rolMedico != null)
                    usuarioMedico.UsuarioRoles.Add(new UsuarioRol { IdRol = rolMedico.IdRol });

                contexto.Usuarios.AddRange(usuarioAdmin, usuarioMedico);
                await contexto.SaveChangesAsync();
            }

            // -------------------------
            // SEMILLA - Módulo Menú
            // -------------------------
            if (!contexto.Menus.Any())
            {
                var rolAdmin = contexto.Roles.FirstOrDefault(r => r.NombreRol == "Administrador");
                var rolMedico = contexto.Roles.FirstOrDefault(r => r.NombreRol == "Medico");

                var menuDashboard = new Menu
                {
                    Titulo = "Dashboard",
                    Url = "/dashboard",
                    MenuRoles = new System.Collections.Generic.List<MenuRol>()
                };

                var menuReportes = new Menu
                {
                    Titulo = "Reportes",
                    Url = "/reportes",
                    MenuRoles = new System.Collections.Generic.List<MenuRol>()
                };

                if (rolAdmin != null)
                {
                    menuDashboard.MenuRoles.Add(new MenuRol { IdRol = rolAdmin.IdRol });
                    menuReportes.MenuRoles.Add(new MenuRol { IdRol = rolAdmin.IdRol });
                }

                if (rolMedico != null)
                {
                    // Por ejemplo, asignar el menú de Dashboard también a médicos
                    menuDashboard.MenuRoles.Add(new MenuRol { IdRol = rolMedico.IdRol });
                }

                contexto.Menus.AddRange(menuDashboard, menuReportes);
                await contexto.SaveChangesAsync();
            }

            // -------------------------
            // SEMILLA - Módulo Suscripción
            // -------------------------
            if (!contexto.Suscripciones.Any())
            {
                var suscripcion = new Suscripcion
                {
                    IdClinica = 1, // Suponiendo que la clínica predeterminada tiene ID 1
                    Estado = "Activo",
                    FechaInicio = DateTime.UtcNow,
                    FechaFin = DateTime.UtcNow.AddYears(1),
                    UltimoPago = DateTime.UtcNow,
                    Plan = "Basico"
                };

                contexto.Suscripciones.Add(suscripcion);
                await contexto.SaveChangesAsync();
            }

            // -------------------------
            // SEMILLA - Módulo Pacientes (Sprint 2)
            // -------------------------
            if (!contexto.Pacientes.Any())
            {
                var paciente1 = new Paciente
                {
                    Nombre = "Juan Pérez",
                    FechaNacimiento = new DateTime(1980, 5, 20)
                };

                var paciente2 = new Paciente
                {
                    Nombre = "María García",
                    FechaNacimiento = new DateTime(1990, 8, 15)
                };

                contexto.Pacientes.AddRange(paciente1, paciente2);
                await contexto.SaveChangesAsync();
            }
        }
    }
}
