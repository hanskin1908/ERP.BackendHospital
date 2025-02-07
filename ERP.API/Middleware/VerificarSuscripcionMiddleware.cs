using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using ERP.Application.Suscripcions.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace ERP.API.Middleware
{
    public class VerificarSuscripcionMiddleware
    {
        private readonly RequestDelegate _next;

        public VerificarSuscripcionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISuscripcionServicio suscripcionServicio)
        {
            // Obtener Id de la clínica desde el usuario autenticado (ajustar según implementación de JWT)
            var idClinica = ObtenerIdClinicaDesdeToken(context);

            if (idClinica.HasValue)
            {
                bool suscripcionActiva = await suscripcionServicio.ValidarSuscripcionActivaAsync(idClinica.Value);

                if (!suscripcionActiva)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Acceso restringido. La suscripción ha expirado.");
                    return;
                }
            }

            await _next(context);
        }

        private int? ObtenerIdClinicaDesdeToken(HttpContext context)
        {
            try
            {
                // Verifica si existe un token en la cabecera de autorización
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return null; // No hay token presente en la solicitud
                }

                var token = authHeader.Split(" ")[1]; // Extrae el token sin "Bearer"
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extraer el claim "idClinica"
                var idClinicaClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "idClinica")?.Value;

                if (!string.IsNullOrEmpty(idClinicaClaim) && int.TryParse(idClinicaClaim, out int idClinica))
                {
                    return idClinica;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al extraer el IdClinica desde el token: {ex.Message}");
                return null;
            }
        }
    }
}
