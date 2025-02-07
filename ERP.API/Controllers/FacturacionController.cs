// Archivo: FacturacionController.cs 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.Facturacion.DTOs;
using ERP.Application.Facturacion.Interfaces;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/facturacion")]
    [Authorize]
    public class FacturacionController : ControllerBase
    {
        private readonly IFacturacionServicio _facturacionServicio;

        public FacturacionController(IFacturacionServicio facturacionServicio)
        {
            _facturacionServicio = facturacionServicio;
        }

        [HttpGet("{idFactura}")]
        public async Task<IActionResult> ObtenerFactura(int idFactura)
        {
            var factura = await _facturacionServicio.ObtenerFacturaPorIdAsync(idFactura);
            if (factura == null)
                return NotFound(new { mensaje = "Factura no encontrada." });
            return Ok(factura);
        }

        [HttpGet("paciente/{idPaciente}")]
        public async Task<IActionResult> ObtenerFacturasPorPaciente(int idPaciente)
        {
            var facturas = await _facturacionServicio.ObtenerFacturasPorPacienteAsync(idPaciente);
            return Ok(facturas);
        }

        [HttpPost]
        public async Task<IActionResult> GenerarFactura([FromBody] FacturaDTO facturaDTO)
        {
            await _facturacionServicio.GenerarFacturaAsync(facturaDTO);
            return CreatedAtAction(nameof(ObtenerFactura), new { idFactura = facturaDTO.IdFactura }, facturaDTO);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarFactura([FromBody] FacturaDTO facturaDTO)
        {
            await _facturacionServicio.ActualizarFacturaAsync(facturaDTO);
            return Ok(facturaDTO);
        }
    }
}
