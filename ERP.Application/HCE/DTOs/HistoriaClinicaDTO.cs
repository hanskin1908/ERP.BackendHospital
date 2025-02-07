using System;

namespace ERP.Application.HCE.DTOs
{
    public class HistoriaClinicaDTO
    {
        public int IdHistoriaClinica { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }
    }
}
