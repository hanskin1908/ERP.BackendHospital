// Archivo: HistoriaClinica.cs 
using ERP.Domain.Pacientes.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.HCE.Entidades
{
    public class HistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoriaClinica { get; set; }

        [Required]
        public int IdPaciente { get; set; } // FK a Paciente

        [Required]
        public DateTime FechaRegistro { get; set; }

        [MaxLength(500)]
        public string Diagnostico { get; set; }

        [MaxLength(500)]
        public string Tratamiento { get; set; }

        public string Observaciones { get; set; }

        // Relación: Se asume que la entidad Paciente ya existe en el dominio (Sprint 2)
        [ForeignKey("IdPaciente")]
        public virtual Paciente Paciente { get; set; }
    }
}
