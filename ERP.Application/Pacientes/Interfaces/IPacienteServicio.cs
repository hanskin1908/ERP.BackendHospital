// Archivo: IPacienteServicio.cs 
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Pacientes.DTOs;

namespace ERP.Application.Pacientes.Interfaces
{
    public interface IPacienteServicio
    {
        Task<IEnumerable<PacienteDTO>> ObtenerPacientes();
        Task<PacienteDTO> ObtenerPacientePorId(int id);
        Task<PacienteDTO> CrearPaciente(PacienteDTO dto);
        Task<PacienteDTO> ActualizarPaciente(PacienteDTO dto);
        Task<bool> EliminarPaciente(int id);
    }
}
