using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Facturacion.Entidades;

namespace ERP.Application.Facturacion.Interfaces
{
    public interface IFacturaRepositorio
    {
        Task<Factura> ObtenerPorIdAsync(int idFactura);
        Task<List<Factura>> ObtenerPorPacienteAsync(int idPaciente);
        Task CrearFacturaAsync(Factura factura);
        Task ActualizarFacturaAsync(Factura factura);
    }
}
