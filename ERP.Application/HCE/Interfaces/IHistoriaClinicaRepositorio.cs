using System.Threading.Tasks;
using ERP.Domain.HCE.Entidades;

namespace ERP.Application.HCE.Interfaces
{
    public interface IHistoriaClinicaRepositorio
    {
        Task<HistoriaClinica> ObtenerPorIdPacienteAsync(int idPaciente);
        Task CrearHistoriaClinicaAsync(HistoriaClinica historia);
        Task ActualizarHistoriaClinicaAsync(HistoriaClinica historia);
    }
}
