using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.HCE.DTOs;
using ERP.Application.HCE.Interfaces;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/hce")]
    [Authorize]  // Asegura que solo usuarios autenticados accedan
    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaServicio _historiaServicio;

        public HistoriaClinicaController(IHistoriaClinicaServicio historiaServicio)
        {
            _historiaServicio = historiaServicio;
        }

        [HttpGet("{idPaciente}")]
        public async Task<IActionResult> ObtenerHistoria(int idPaciente)
        {
            var historia = await _historiaServicio.ObtenerHistoriaPorIdPacienteAsync(idPaciente);
            if (historia == null)
                return NotFound(new { mensaje = "Historia clínica no encontrada." });
            return Ok(historia);
        }

        [HttpPost]
        public async Task<IActionResult> CrearHistoria([FromBody] HistoriaClinicaDTO historiaDTO)
        {
            await _historiaServicio.CrearHistoriaClinicaAsync(historiaDTO);
            return CreatedAtAction(nameof(ObtenerHistoria), new { idPaciente = historiaDTO.IdPaciente }, historiaDTO);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarHistoria([FromBody] HistoriaClinicaDTO historiaDTO)
        {
            await _historiaServicio.ActualizarHistoriaClinicaAsync(historiaDTO);
            return Ok(historiaDTO);
        }
    }
}
