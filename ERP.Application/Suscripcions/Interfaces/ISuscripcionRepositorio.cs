// Archivo: ISuscripcionRepositorio.cs 
using System.Threading.Tasks;
using ERP.Domain.Suscripcions.Entidades;

namespace ERP.Application.Suscripcions.Interfaces
{
    public interface ISuscripcionRepositorio
    {
        Task<Suscripcion> ObtenerSuscripcionPorClinica(int idClinica);
        Task<Suscripcion> CrearSuscripcion(Suscripcion suscripcion);
        Task ActualizarSuscripcionAsync(Suscripcion suscripcion);
        Task<bool> ExisteSuscripcionActivaAsync(int idClinica);
    }
}
