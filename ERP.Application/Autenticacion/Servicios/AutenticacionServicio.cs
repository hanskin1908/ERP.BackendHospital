using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Application.Autenticacion.DTOs;
using ERP.Domain.Autenticacion.Entidades;
using BCrypt.Net; // Agregar paquete BCrypt.Net-Next

namespace ERP.Application.Autenticacion.Servicios
{
    public class AutenticacionServicio : IAutenticacionServicio
    {
        private readonly IAutenticacionRepositorio _repositorioAutenticacion;
        private readonly IConfiguration _configuracion;
        private readonly IUsuarioServicio _usuarioServicio;
        public AutenticacionServicio(IUsuarioServicio usuarioServicio, IAutenticacionRepositorio repositorioAutenticacion, IConfiguration configuracion)
        {
            _repositorioAutenticacion = repositorioAutenticacion;
            _usuarioServicio = usuarioServicio;
            _configuracion = configuracion;
        }

        public async Task<AutenticacionResponseDTO> Autenticar(LoginDTO loginDTO)
        {
            // Validar credenciales
            var usuario = await _usuarioServicio.ObtenerPorNombreUsuarioAsync(loginDTO.NombreUsuario);

            if (usuario == null || !VerificarContrasena(loginDTO.Contrasena, usuario.ContrasenaHash))
            {
                return null;
            }
            return new AutenticacionResponseDTO
            {
                Token = GenerarToken(usuario),
                IdUsuario = usuario.IdUsuario
            };
         
        }

        private bool VerificarContrasena(string contrasenaIngresada, string contrasenaHashAlmacenada)
        {
            // Utiliza BCrypt para comparar la contraseña ingresada con el hash almacenado
            return BCrypt.Net.BCrypt.Verify(contrasenaIngresada, contrasenaHashAlmacenada);
        }

        private string GenerarToken(Usuario usuario)
        {

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario es nulo.");
            }

            if (usuario.UsuarioRoles == null || !usuario.UsuarioRoles.Any())
            {
                throw new InvalidOperationException("El usuario no tiene roles asignados.");
            } 

            var claveSecreta = _configuracion["Jwt:ClaveSecreta"];
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveSecreta));
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.NombreUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("idUsuario", usuario.IdUsuario.ToString()),
                new Claim("rol", usuario.UsuarioRoles[0].Rol.NombreRol) // Tomar el primer rol como ejemplo
            };

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Issuer"],
                audience: _configuracion["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
