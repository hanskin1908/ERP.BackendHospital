using Microsoft.EntityFrameworkCore;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Domain.Menus.Entidades;
using ERP.Domain.Suscripcions.Entidades;
using ERP.Domain.Pacientes.Entidades;
using ERP.Domain.Citas.Entidades;
using ERP.Domain.HCE.Entidades;
using ERP.Domain.Facturacion.Entidades; // Agregado para el Sprint 2

namespace ERP.Infrastructure.Data
{
    public class ContextoDatos : DbContext
    {
        public ContextoDatos(DbContextOptions<ContextoDatos> opciones)
            : base(opciones)
        {
        }

        // Tablas del m�dulo de Autenticaci�n (Sprint 1)
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        // Tablas del m�dulo de Men� (Sprint 1)
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRol> MenuRoles { get; set; }

        // Tabla del m�dulo de Suscripci�n (Sprint 1)
        public DbSet<Suscripcion> Suscripciones { get; set; }

        // Tabla del m�dulo de Pacientes (Sprint 2)
        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<AgendaMedica> AgendaMedica { get; set; }

        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Factura> Facturas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelo)
        {
            // ------------------------------
            // Configuraci�n Sprint 1
            // ------------------------------

            // Configuraci�n de la llave compuesta y relaciones para UsuarioRol

            modelo.Entity<Usuario>()
    .HasKey(u => u.IdUsuario); // Define la clave primaria expl�citamente

            modelo.Entity<Menu>()
.HasKey(u => u.IdMenu);

            modelo.Entity<Suscripcion>()
.HasKey(u => u.IdSuscripcion);
            modelo.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.IdUsuario, ur.IdRol });

            modelo.Entity<Rol>()
      .HasKey(r => r.IdRol); // Define IdRol como clave primaria expl�citamente



            modelo.Entity<UsuarioRol>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(ur => ur.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelo.Entity<UsuarioRol>()
                .HasOne(ur => ur.Rol)
                .WithMany() // Si Rol no define colecci�n de UsuarioRoles, se deja vac�o
                .HasForeignKey(ur => ur.IdRol)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuraci�n de la llave compuesta y relaciones para MenuRol
            modelo.Entity<MenuRol>()
                .HasKey(mr => new { mr.IdMenu, mr.IdRol });

            modelo.Entity<MenuRol>()
                .HasOne(mr => mr.Menu)
                .WithMany(m => m.MenuRoles)
                .HasForeignKey(mr => mr.IdMenu)
                .OnDelete(DeleteBehavior.Cascade);

            modelo.Entity<MenuRol>()
                .HasOne<Rol>()
                .WithMany()
                .HasForeignKey(mr => mr.IdRol)
                .OnDelete(DeleteBehavior.Cascade);


            // ------------------------------
            // Configuraci�n Sprint 2
            // ------------------------------

            // Configuraci�n b�sica para la entidad Paciente
            modelo.Entity<Paciente>()
                .HasKey(p => p.IdPaciente);

            // Se pueden agregar validaciones adicionales, por ejemplo:
            modelo.Entity<Paciente>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            base.OnModelCreating(modelo);

            modelo.Entity<Cita>()
       .HasKey(c => c.IdCita);

            modelo.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelo.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuraci�n de Agenda M�dica
            modelo.Entity<AgendaMedica>()
                .HasKey(a => a.IdAgenda);

            modelo.Entity<AgendaMedica>()
                .HasOne(a => a.Medico)
                .WithMany()
                .HasForeignKey(a => a.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelo.Entity<HistoriaClinica>()
              .HasKey(hc => hc.IdHistoriaClinica);

            modelo.Entity<HistoriaClinica>()
                .Property(hc => hc.Diagnostico)
                .HasMaxLength(500);

            modelo.Entity<HistoriaClinica>()
                .Property(hc => hc.Tratamiento)
                .HasMaxLength(500);

            // Configuraci�n de Factura
            modelo.Entity<Factura>()
                .HasKey(f => f.IdFactura);

            modelo.Entity<Factura>()
                .Property(f => f.Estado)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}

// Archivo: ContextoDatos.cs 
