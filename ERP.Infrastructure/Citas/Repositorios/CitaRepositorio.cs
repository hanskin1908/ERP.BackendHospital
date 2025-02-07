// Archivo: CitaRepositorio.cs 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ERP.Domain.Citas.Entidades;
using ERP.Application.Citas.Interfaces;
using ERP.Infrastructure.Data;

namespace ERP.Infrastructure.Citas.Repositorios
{
    public class CitaRepositorio : ICitaRepositorio
    {
        private readonly ContextoDatos _contexto;

        public CitaRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<Cita> ObtenerPorIdAsync(int idCita)
        {
            return await _contexto.Cita
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.IdCita == idCita);
        }

        public async Task<List<Cita>> ObtenerCitasPorPacienteAsync(int idPaciente)
        {
            return await _contexto.Cita
                .Where(c => c.IdPaciente == idPaciente)
                .ToListAsync();
        }

        public async Task<List<Cita>> ObtenerCitasPorMedicoAsync(int idMedico)
        {
            return await _contexto.Cita
                .Where(c => c.IdMedico == idMedico)
                .ToListAsync();
        }

        public async Task CrearCitaAsync(Cita cita)
        {
            await _contexto.Cita.AddAsync(cita);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarCitaAsync(Cita cita)
        {
            _contexto.Cita.Update(cita);
            await _contexto.SaveChangesAsync();
        }

        public async Task EliminarCitaAsync(int idCita)
        {
            var cita = await ObtenerPorIdAsync(idCita);
            if (cita != null)
            {
                _contexto.Cita.Remove(cita);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCitaEnHorarioAsync(int idMedico, DateTime fechaHora)
        {
            return await _contexto.Cita
                .AnyAsync(c => c.IdMedico == idMedico && c.FechaHora == fechaHora);
        }
    }
}
