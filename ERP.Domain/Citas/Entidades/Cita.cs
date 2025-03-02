// Archivo: Cita.cs 
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Domain.Pacientes.Entidades;

namespace ERP.Domain.Citas.Entidades
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
      
        public EstadoCita Estado { get; set; } // Pendiente, Confirmada, Cancelada, Completada

        [MaxLength(255)]
        public string Motivo { get; set; }

        // Relaciones
        [ForeignKey("IdPaciente")]
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("IdMedico")]
        public virtual Usuario Medico { get; set; }
    }
}
