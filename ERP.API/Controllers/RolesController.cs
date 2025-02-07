using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;
using ERP.Application.Autenticacion.Interfaces;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolServicio _rolServicio;
        public RolesController(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRoles()
        {
            var roles = await _rolServicio.ObtenerRoles();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] RolDTO dto)
        {
            var rolCreado = await _rolServicio.CrearRol(dto);
            return CreatedAtAction(nameof(ObtenerRoles), new { id = rolCreado.IdRol }, rolCreado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarRol([FromBody] RolDTO dto)
        {
            var rolActualizado = await _rolServicio.ActualizarRol(dto);
            if (rolActualizado == null)
                return NotFound();
            return Ok(rolActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            bool resultado = await _rolServicio.EliminarRol(id);
            if (!resultado)
                return NotFound();
            return NoContent();
        }
    }
}
