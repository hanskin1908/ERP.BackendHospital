// Archivo: PacientesController.cs 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.Pacientes.DTOs;
using ERP.Application.Pacientes.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize] // 🔒 Protege todos los métodos en este controlador
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteServicio _pacienteServicio;
        public PacientesController(IPacienteServicio pacienteServicio)
        {
            _pacienteServicio = pacienteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPacientes()
        {
            var pacientes = await _pacienteServicio.ObtenerPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPacientePorId(int id)
        {
            var paciente = await _pacienteServicio.ObtenerPacientePorId(id);
            if (paciente == null)
                return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPaciente([FromBody] PacienteDTO dto)
        {
            var pacienteCreado = await _pacienteServicio.CrearPaciente(dto);
            return CreatedAtAction(nameof(ObtenerPacientePorId), new { id = pacienteCreado.IdPaciente }, pacienteCreado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPaciente([FromBody] PacienteDTO dto)
        {
            var pacienteActualizado = await _pacienteServicio.ActualizarPaciente(dto);
            if (pacienteActualizado == null)
                return NotFound();
            return Ok(pacienteActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            bool resultado = await _pacienteServicio.EliminarPaciente(id);
            if (!resultado)
                return NotFound();
            return NoContent();
        }
    }
}
