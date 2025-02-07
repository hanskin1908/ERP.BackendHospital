// Archivo: FacturaDTO.cs 
using ERP.Domain.Facturacion.Entidades;
using System;

namespace ERP.Application.Facturacion.DTOs
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public EstadoFactura Estado { get; set; }
    }
}
