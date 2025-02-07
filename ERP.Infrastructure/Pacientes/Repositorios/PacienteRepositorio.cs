// Archivo: PacienteRepositorio.cs 
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Pacientes.Interfaces;
using ERP.Domain.Pacientes.Entidades;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Pacientes.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ContextoDatos _contexto;
        public PacienteRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<Paciente>> ObtenerTodos()
        {
            return await _contexto.Set<Paciente>().ToListAsync();
        }
        public async Task<Paciente> ObtenerPorId(int id)
        {
            return await _contexto.Set<Paciente>().FindAsync(id);
        }
        public async Task Crear(Paciente paciente)
        {
            _contexto.Set<Paciente>().Add(paciente);
            await _contexto.SaveChangesAsync();
        }
        public async Task Actualizar(Paciente paciente)
        {
            _contexto.Set<Paciente>().Update(paciente);
            await _contexto.SaveChangesAsync();
        }
        public async Task<bool> Eliminar(int id)
        {
            var paciente = await ObtenerPorId(id);
            if (paciente == null) return false;
            _contexto.Set<Paciente>().Remove(paciente);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
