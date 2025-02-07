using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.HCE.DTOs;

namespace ERP.Application.HCE.Interfaces
{
    public interface IHistoriaClinicaServicio
    {
        Task<HistoriaClinicaDTO> ObtenerHistoriaPorIdPacienteAsync(int idPaciente);
        Task CrearHistoriaClinicaAsync(HistoriaClinicaDTO historiaDTO);
        Task ActualizarHistoriaClinicaAsync(HistoriaClinicaDTO historiaDTO);
    }
}
