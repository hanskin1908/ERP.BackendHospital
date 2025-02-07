// Archivo: SuscripcionController.cs 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.Application.Suscripcions.Interfaces;
using ERP.Application.Suscripcions.DTOs;
using ERP.Application.Suscripcions.Servicios;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuscripcionController : ControllerBase
    {
        private readonly ISuscripcionServicio _servicioSuscripcion;
        public SuscripcionController(ISuscripcionServicio servicioSuscripcion)
        {
            _servicioSuscripcion = servicioSuscripcion;
        }

        [HttpGet("{idClinica}")]
        public async Task<IActionResult> ObtenerSuscripcionPorClinica(int idClinica)
        {
            SuscripcionDTO suscripcion = await _servicioSuscripcion.ObtenerSuscripcionPorClinica(idClinica);
            if (suscripcion == null)
                return NotFound();
            return Ok(suscripcion);
        }

        /// <summary>
        /// Verifica si una cl�nica tiene una suscripci�n activa.
        /// </summary>
        [HttpGet("validar/{idClinica}")]
        public async Task<IActionResult> ValidarSuscripcion(int idClinica)
        {
            bool suscripcionActiva = await _servicioSuscripcion.ValidarSuscripcionActivaAsync(idClinica);
            if (!suscripcionActiva)
            {
                return Unauthorized(new { mensaje = "La suscripci�n ha expirado. Renueva tu suscripci�n para continuar." });
            }
            return Ok(new { mensaje = "La suscripci�n est� activa." });
        }


        [HttpPost]
        public async Task<IActionResult> CrearSuscripcion([FromBody] SuscripcionDTO suscripcionDTO)
        {
            SuscripcionDTO suscripcionCreada = await _servicioSuscripcion.CrearSuscripcion(suscripcionDTO);
            return CreatedAtAction(nameof(ObtenerSuscripcionPorClinica), new { idClinica = suscripcionCreada.IdClinica }, suscripcionCreada);
        }
    }
}
