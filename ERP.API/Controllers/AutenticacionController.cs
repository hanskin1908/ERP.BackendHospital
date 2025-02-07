// Archivo: AutenticacionController.cs 
using ERP.Application.Autenticacion.DTOs;
using ERP.Application.Autenticacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacionServicio _servicioAutenticacion;

        public AutenticacionController(IAutenticacionServicio servicioAutenticacion)
        {
            _servicioAutenticacion = servicioAutenticacion;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO loginDTO)
        {
            var response = await _servicioAutenticacion.Autenticar(loginDTO);
            if (response == null)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }
            return Ok(response); // Devuelve { token, idUsuario }
        }
    }
}
