using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Facturacion.DTOs;
using ERP.Application.Facturacion.Interfaces;
using ERP.Domain.Facturacion.Entidades;
 // Se asume que crearemos esta carpeta en Infrastructure

namespace ERP.Application.Facturacion.Servicios
{
    public class FacturacionServicio : IFacturacionServicio
    {
        private readonly IFacturaRepositorio _facturaRepositorio;

        public FacturacionServicio(IFacturaRepositorio facturaRepositorio)
        {
            _facturaRepositorio = facturaRepositorio;
        }

        public async Task<FacturaDTO> ObtenerFacturaPorIdAsync(int idFactura)
        {
            var factura = await _facturaRepositorio.ObtenerPorIdAsync(idFactura);
            if (factura == null)
                return null;

            return new FacturaDTO
            {
                IdFactura = factura.IdFactura,
                IdPaciente = factura.IdPaciente,
                FechaEmision = factura.FechaEmision,
                Monto = factura.Monto,
                Estado = factura.Estado
            };
        }

        public async Task<List<FacturaDTO>> ObtenerFacturasPorPacienteAsync(int idPaciente)
        {
            var facturas = await _facturaRepositorio.ObtenerPorPacienteAsync(idPaciente);
            return facturas.Select(f => new FacturaDTO
            {
                IdFactura = f.IdFactura,
                IdPaciente = f.IdPaciente,
                FechaEmision = f.FechaEmision,
                Monto = f.Monto,
                Estado = f.Estado
            }).ToList();
        }

        public async Task GenerarFacturaAsync(FacturaDTO facturaDTO)
        {
            var factura = new Factura
            {
                IdPaciente = facturaDTO.IdPaciente,
                FechaEmision = facturaDTO.FechaEmision,
                Monto = facturaDTO.Monto,
                Estado = EstadoFactura.Pendiente // Inicialmente, la factura se genera en estado "Pendiente"
            };

            await _facturaRepositorio.CrearFacturaAsync(factura);
        }

        public async Task ActualizarFacturaAsync(FacturaDTO facturaDTO)
        {
            var factura = await _facturaRepositorio.ObtenerPorIdAsync(facturaDTO.IdFactura);
            if (factura == null)
                throw new KeyNotFoundException("Factura no encontrada.");

            factura.FechaEmision = facturaDTO.FechaEmision;
            factura.Monto = facturaDTO.Monto;
            factura.Estado = facturaDTO.Estado;

            await _facturaRepositorio.ActualizarFacturaAsync(factura);
        }
    }
}
