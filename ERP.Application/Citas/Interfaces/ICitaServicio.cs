// Archivo: ICitaServicio.cs 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Citas.DTOs;

namespace ERP.Application.Citas.Interfaces
{
    public interface ICitaServicio
    {
        Task<CitaDTO> ObtenerPorIdAsync(int idCita);
        Task<List<CitaDTO>> ObtenerCitasPorPacienteAsync(int idPaciente);
        Task<List<CitaDTO>> ObtenerCitasPorMedicoAsync(int idMedico);
        Task CrearCitaAsync(CitaDTO citaDTO);
        Task ActualizarCitaAsync(CitaDTO citaDTO);
        Task EliminarCitaAsync(int idCita);
    }
}
