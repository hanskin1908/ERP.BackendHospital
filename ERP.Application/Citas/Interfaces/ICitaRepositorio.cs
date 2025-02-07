using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Citas.Entidades;

namespace ERP.Application.Citas.Interfaces
{
    public interface ICitaRepositorio
    {
        Task<Cita> ObtenerPorIdAsync(int idCita);
        Task<List<Cita>> ObtenerCitasPorPacienteAsync(int idPaciente);
        Task<List<Cita>> ObtenerCitasPorMedicoAsync(int idMedico);
        Task CrearCitaAsync(Cita cita);
        Task ActualizarCitaAsync(Cita cita);
        Task EliminarCitaAsync(int idCita);
        Task<bool> ExisteCitaEnHorarioAsync(int idMedico, DateTime fechaHora);
    }
}
