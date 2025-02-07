// Archivo: SuscripcionRepositorio.cs 
using System.Threading.Tasks;
using ERP.Application.Suscripcions.Interfaces;
using ERP.Application.Suscripcions.Interfaces;
using ERP.Domain.Suscripcions.Entidades;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Suscripcions.Repositorios
{
    public class SuscripcionRepositorio : ISuscripcionRepositorio
    {
        private readonly ContextoDatos _contexto;
        public SuscripcionRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<Suscripcion> ObtenerSuscripcionPorClinica(int idClinica)
        {
            return await _contexto.Suscripciones.FirstOrDefaultAsync(s => s.IdClinica == idClinica);
        }

        public async Task<Suscripcion> CrearSuscripcion(Suscripcion suscripcion)
        {
            _contexto.Suscripciones.Add(suscripcion);
            await _contexto.SaveChangesAsync();
            return suscripcion;
        }

        public async Task ActualizarSuscripcionAsync(Suscripcion suscripcion)
        {
            _contexto.Suscripciones.Update(suscripcion);
            await _contexto.SaveChangesAsync();
        }

        public async Task<bool> ExisteSuscripcionActivaAsync(int idClinica)
        {
            return await _contexto.Suscripciones
                .AnyAsync(s => s.IdClinica == idClinica && s.Estado == "Activo");
        }
    }
}
