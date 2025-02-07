using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;
using ERP.Application.Autenticacion.Interfaces;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuariosController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _usuarioServicio.ObtenerUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _usuarioServicio.ObtenerUsuarioPorId(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDTO dto)
        {
            var usuarioCreado = await _usuarioServicio.CrearUsuario(dto);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuarioCreado.IdUsuario }, usuarioCreado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioDTO dto)
        {
            var usuarioActualizado = await _usuarioServicio.ActualizarUsuario(dto);
            if (usuarioActualizado == null)
                return NotFound();
            return Ok(usuarioActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            bool resultado = await _usuarioServicio.EliminarUsuario(id);
            if (!resultado)
                return NotFound();
            return NoContent();
        }
    }
}
