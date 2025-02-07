using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ERP.Domain.HCE.Entidades;
using ERP.Application.HCE.Interfaces;
using ERP.Infrastructure.Data;

namespace ERP.Infrastructure.HCE.Repositorios
{
    public class HistoriaClinicaRepositorio : IHistoriaClinicaRepositorio
    {
        private readonly ContextoDatos _contexto;

        public HistoriaClinicaRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<HistoriaClinica> ObtenerPorIdPacienteAsync(int idPaciente)
        {
            return await _contexto.HistoriasClinicas
                .FirstOrDefaultAsync(hc => hc.IdPaciente == idPaciente);
        }

        public async Task CrearHistoriaClinicaAsync(HistoriaClinica historia)
        {
            await _contexto.HistoriasClinicas.AddAsync(historia);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarHistoriaClinicaAsync(HistoriaClinica historia)
        {
            _contexto.HistoriasClinicas.Update(historia);
            await _contexto.SaveChangesAsync();
        }
    }
}
