// Archivo: PacienteDTO.cs 
using System;

namespace ERP.Application.Pacientes.DTOs
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        // Otros campos si se requieren
    }
}
