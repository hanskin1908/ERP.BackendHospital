// Archivo: AutenticacionRepositorio.cs 


using ERP.Application.Autenticacion.Interfaces;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Autenticacion.Repositorios
{
    public class AutenticacionRepositorio : IAutenticacionRepositorio
    {
        private readonly ContextoDatos _contexto;
        public AutenticacionRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }
    }
}
