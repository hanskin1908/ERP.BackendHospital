using System.Threading.Tasks;
using ERP.Application.HCE.DTOs;
using ERP.Application.HCE.Interfaces;
using ERP.Domain.HCE.Entidades;
 // Se asume que crearemos esta carpeta en Infrastructure

namespace ERP.Application.HCE.Servicios
{
    public class HistoriaClinicaServicio : IHistoriaClinicaServicio
    {
        private readonly IHistoriaClinicaRepositorio _repositorioHistoria;

        public HistoriaClinicaServicio(IHistoriaClinicaRepositorio repositorioHistoria)
        {
            _repositorioHistoria = repositorioHistoria;
        }

        public async Task<HistoriaClinicaDTO> ObtenerHistoriaPorIdPacienteAsync(int idPaciente)
        {
            var historia = await _repositorioHistoria.ObtenerPorIdPacienteAsync(idPaciente);
            if (historia == null)
                return null;

            return new HistoriaClinicaDTO
            {
                IdHistoriaClinica = historia.IdHistoriaClinica,
                IdPaciente = historia.IdPaciente,
                FechaRegistro = historia.FechaRegistro,
                Diagnostico = historia.Diagnostico,
                Tratamiento = historia.Tratamiento,
                Observaciones = historia.Observaciones
            };
        }

        public async Task CrearHistoriaClinicaAsync(HistoriaClinicaDTO historiaDTO)
        {
            var historia = new HistoriaClinica
            {
                IdPaciente = historiaDTO.IdPaciente,
                FechaRegistro = historiaDTO.FechaRegistro,
                Diagnostico = historiaDTO.Diagnostico,
                Tratamiento = historiaDTO.Tratamiento,
                Observaciones = historiaDTO.Observaciones
            };

            await _repositorioHistoria.CrearHistoriaClinicaAsync(historia);
        }

        public async Task ActualizarHistoriaClinicaAsync(HistoriaClinicaDTO historiaDTO)
        {
            var historia = new HistoriaClinica
            {
                IdHistoriaClinica = historiaDTO.IdHistoriaClinica,
                IdPaciente = historiaDTO.IdPaciente,
                FechaRegistro = historiaDTO.FechaRegistro,
                Diagnostico = historiaDTO.Diagnostico,
                Tratamiento = historiaDTO.Tratamiento,
                Observaciones = historiaDTO.Observaciones
            };

            await _repositorioHistoria.ActualizarHistoriaClinicaAsync(historia);
        }
    }
}
