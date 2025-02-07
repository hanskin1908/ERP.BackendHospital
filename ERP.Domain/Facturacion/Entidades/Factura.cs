// Archivo: Factura.cs 
using ERP.Domain.Pacientes.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Facturacion.Entidades
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFactura { get; set; }

        [Required]
        public int IdPaciente { get; set; } // FK a Paciente

        [Required]
        public DateTime FechaEmision { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        [MaxLength(50)]
        public EstadoFactura Estado { get; set; }  // Por ejemplo: "Pendiente", "Pagada", "Vencida"

        // Relación: Se asume que la entidad Paciente ya existe
        [ForeignKey("IdPaciente")]
        public virtual Paciente Paciente { get; set; }
    }
}
