// Archivo: AgendaMedica.cs 
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Domain.Citas.Entidades
{
    public class AgendaMedica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgenda { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        [MaxLength(20)]
        public string DiaSemana { get; set; } // Lunes - Domingo

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        // Relaciones
        [ForeignKey("IdMedico")]
        public virtual Usuario Medico { get; set; }
    }
}
