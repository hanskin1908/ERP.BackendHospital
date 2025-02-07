// Archivo: CitaDTO.cs 
using System;

namespace ERP.Application.Citas.DTOs
{
    public class CitaDTO
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
    }
}
