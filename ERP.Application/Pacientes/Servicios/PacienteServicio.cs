// Archivo: PacienteServicio.cs 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Pacientes.DTOs;
using ERP.Application.Pacientes.Interfaces;
using ERP.Domain.Pacientes.Entidades;

namespace ERP.Application.Pacientes.Servicios
{
    public class PacienteServicio : IPacienteServicio
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteServicio(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<IEnumerable<PacienteDTO>> ObtenerPacientes()
        {
            var pacientes = await _pacienteRepositorio.ObtenerTodos();
            return pacientes.Select(p => new PacienteDTO
            {
                IdPaciente = p.IdPaciente,
                Nombre = p.Nombre,
                FechaNacimiento = p.FechaNacimiento
            });
        }

        public async Task<PacienteDTO> ObtenerPacientePorId(int id)
        {
            var p = await _pacienteRepositorio.ObtenerPorId(id);
            if (p == null) return null;
            return new PacienteDTO
            {
                IdPaciente = p.IdPaciente,
                Nombre = p.Nombre,
                FechaNacimiento = p.FechaNacimiento
            };
        }

        public async Task<PacienteDTO> CrearPaciente(PacienteDTO dto)
        {
            var paciente = new Paciente
            {
                Nombre = dto.Nombre,
                FechaNacimiento = dto.FechaNacimiento
            };
            await _pacienteRepositorio.Crear(paciente);
            dto.IdPaciente = paciente.IdPaciente;
            return dto;
        }

        public async Task<PacienteDTO> ActualizarPaciente(PacienteDTO dto)
        {
            var paciente = await _pacienteRepositorio.ObtenerPorId(dto.IdPaciente);
            if (paciente == null) return null;
            paciente.Nombre = dto.Nombre;
            paciente.FechaNacimiento = dto.FechaNacimiento;
            await _pacienteRepositorio.Actualizar(paciente);
            return dto;
        }

        public async Task<bool> EliminarPaciente(int id)
        {
            return await _pacienteRepositorio.Eliminar(id);
        }
    }
}
