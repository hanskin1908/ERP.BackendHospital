namespace ERP.Application.Citas.DTOs
{
    public class AgendaMedicaDTO
    {
        public int IdAgenda { get; set; }
        public int IdMedico { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
