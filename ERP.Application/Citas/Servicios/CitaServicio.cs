// Archivo: CitaServicio.cs 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Citas.DTOs;
using ERP.Application.Citas.Interfaces;
using ERP.Domain.Citas.Entidades;

namespace ERP.Application.Citas.Servicios
{
    public class CitaServicio : ICitaServicio
    {
        private readonly ICitaRepositorio _citaRepositorio;

        public CitaServicio(ICitaRepositorio citaRepositorio)
        {
            _citaRepositorio = citaRepositorio;
        }

        public async Task<CitaDTO> ObtenerPorIdAsync(int idCita)
        {
            var cita = await _citaRepositorio.ObtenerPorIdAsync(idCita);
            return cita == null ? null : MapearCita(cita);
        }

        public async Task<List<CitaDTO>> ObtenerCitasPorPacienteAsync(int idPaciente)
        {
            var citas = await _citaRepositorio.ObtenerCitasPorPacienteAsync(idPaciente);
            return citas.Select(MapearCita).ToList();
        }

        public async Task<List<CitaDTO>> ObtenerCitasPorMedicoAsync(int idMedico)
        {
            var citas = await _citaRepositorio.ObtenerCitasPorMedicoAsync(idMedico);
            return citas.Select(MapearCita).ToList();
        }

        public async Task CrearCitaAsync(CitaDTO citaDTO)
        {
            var existeCita = await _citaRepositorio.ExisteCitaEnHorarioAsync(citaDTO.IdMedico, citaDTO.FechaHora);
            if (existeCita)
                throw new InvalidOperationException("El médico ya tiene una cita en este horario.");

            var cita = new Cita
            {
                IdPaciente = citaDTO.IdPaciente,
                IdMedico = citaDTO.IdMedico,
                FechaHora = citaDTO.FechaHora,
                Estado = "Pendiente",
                Motivo = citaDTO.Motivo
            };

            await _citaRepositorio.CrearCitaAsync(cita);
        }

        public async Task ActualizarCitaAsync(CitaDTO citaDTO)
        {
            var cita = await _citaRepositorio.ObtenerPorIdAsync(citaDTO.IdCita);
            if (cita == null) throw new KeyNotFoundException("Cita no encontrada.");

            cita.FechaHora = citaDTO.FechaHora;
            cita.Estado = citaDTO.Estado;
            cita.Motivo = citaDTO.Motivo;

            await _citaRepositorio.ActualizarCitaAsync(cita);
        }

        public async Task EliminarCitaAsync(int idCita)
        {
            await _citaRepositorio.EliminarCitaAsync(idCita);
        }

        private static CitaDTO MapearCita(Cita cita)
        {
            return new CitaDTO
            {
                IdCita = cita.IdCita,
                IdPaciente = cita.IdPaciente,
                IdMedico = cita.IdMedico,
                FechaHora = cita.FechaHora,
                Estado = cita.Estado,
                Motivo = cita.Motivo
            };
        }
    }
}
