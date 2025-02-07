// Archivo: CitasController.cs 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERP.Application.Citas.DTOs;
using ERP.Application.Citas.Interfaces;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaServicio _citaServicio;

        public CitasController(ICitaServicio citaServicio)
        {
            _citaServicio = citaServicio;
        }

        /// <summary>
        /// Obtiene una cita por su identificador.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCitaPorId(int id)
        {
            var cita = await _citaServicio.ObtenerPorIdAsync(id);
            if (cita == null)
            {
                return NotFound(new { mensaje = "Cita no encontrada." });
            }
            return Ok(cita);
        }

        /// <summary>
        /// Obtiene todas las citas asociadas a un paciente.
        /// </summary>
        [HttpGet("paciente/{idPaciente}")]
        public async Task<IActionResult> ObtenerCitasPorPaciente(int idPaciente)
        {
            var citas = await _citaServicio.ObtenerCitasPorPacienteAsync(idPaciente);
            return Ok(citas);
        }

        /// <summary>
        /// Obtiene todas las citas asignadas a un médico.
        /// </summary>
        [HttpGet("medico/{idMedico}")]
        public async Task<IActionResult> ObtenerCitasPorMedico(int idMedico)
        {
            var citas = await _citaServicio.ObtenerCitasPorMedicoAsync(idMedico);
            return Ok(citas);
        }

        /// <summary>
        /// Crea una nueva cita.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearCita([FromBody] CitaDTO citaDTO)
        {
            try
            {
                await _citaServicio.CrearCitaAsync(citaDTO);
                // Nota: El Id de la cita puede generarse en la base de datos; 
                // se recomienda recuperar la cita creada o incluir el Id en el DTO luego de la creación.
                return CreatedAtAction(nameof(ObtenerCitaPorId), new { id = citaDTO.IdCita }, citaDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza una cita existente.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarCita([FromBody] CitaDTO citaDTO)
        {
            try
            {
                await _citaServicio.ActualizarCitaAsync(citaDTO);
                return Ok(citaDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una cita por su identificador.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCita(int id)
        {
            await _citaServicio.EliminarCitaAsync(id);
            return NoContent();
        }
    }
}
