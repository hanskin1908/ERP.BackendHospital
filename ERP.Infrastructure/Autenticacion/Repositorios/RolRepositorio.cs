using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Application.Autenticacion.Interfaces;
using ERP.Domain.Autenticacion.Entidades;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Autenticacion.Repositorios
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly ContextoDatos _contexto;
        public RolRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<Rol>> ObtenerTodos()
        {
            return await _contexto.Roles.ToListAsync();
        }
        public async Task<Rol> ObtenerPorId(int id)
        {
            return await _contexto.Roles.FindAsync(id);
        }
        public async Task Crear(Rol rol)
        {
            _contexto.Roles.Add(rol);
            await _contexto.SaveChangesAsync();
        }
        public async Task Actualizar(Rol rol)
        {
            _contexto.Roles.Update(rol);
            await _contexto.SaveChangesAsync();
        }
        public async Task<bool> Eliminar(int id)
        {
            var rol = await ObtenerPorId(id);
            if (rol == null) return false;
            _contexto.Roles.Remove(rol);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
