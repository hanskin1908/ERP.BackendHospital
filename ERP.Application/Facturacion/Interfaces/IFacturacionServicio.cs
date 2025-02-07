// Archivo: IFacturacionServicio.cs 
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Facturacion.DTOs;

namespace ERP.Application.Facturacion.Interfaces
{
    public interface IFacturacionServicio
    {
        Task<FacturaDTO> ObtenerFacturaPorIdAsync(int idFactura);
        Task<List<FacturaDTO>> ObtenerFacturasPorPacienteAsync(int idPaciente);
        Task GenerarFacturaAsync(FacturaDTO facturaDTO);
        Task ActualizarFacturaAsync(FacturaDTO facturaDTO);
    }
}
