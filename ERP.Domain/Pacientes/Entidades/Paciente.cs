// Archivo: Paciente.cs 
using ERP.Domain.Citas.Entidades;
using System;

namespace ERP.Domain.Pacientes.Entidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        // Otros campos opcionales: DNI, Dirección, Teléfono, etc.
    }
}
