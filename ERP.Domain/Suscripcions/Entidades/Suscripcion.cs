// Archivo: Suscripcion.cs 
using System;

namespace ERP.Domain.Suscripcions.Entidades
{
    public class Suscripcion
    {
        public int IdSuscripcion { get; set; }
        public int IdClinica { get; set; }
        public string Estado { get; set; } // Ejemplo: Activo, Suspendido, Expirado
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime UltimoPago { get; set; }
        public string Plan { get; set; } // Ejemplo: Basico, Premium, Enterprise
    }
}
