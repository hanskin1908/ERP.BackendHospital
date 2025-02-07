// Archivo: SuscripcionDTO.cs 
using System;

namespace ERP.Application.Suscripcions.DTOs
{
    public class SuscripcionDTO
    {
        public int IdSuscripcion { get; set; }
        public int IdClinica { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime UltimoPago { get; set; }
        public string Plan { get; set; }
    }
}
