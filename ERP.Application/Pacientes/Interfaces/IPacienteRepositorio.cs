using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Pacientes.Entidades;

namespace ERP.Application.Pacientes.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<IEnumerable<Paciente>> ObtenerTodos();
        Task<Paciente> ObtenerPorId(int id);
        Task Crear(Paciente paciente);
        Task Actualizar(Paciente paciente);
        Task<bool> Eliminar(int id);
    }
}
