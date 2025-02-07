// Archivo: ISuscripcionServicio.cs 
using System.Threading.Tasks;
using ERP.Application.Suscripcions.DTOs;

namespace ERP.Application.Suscripcions.Interfaces
{
    public interface ISuscripcionServicio
    {
        Task<SuscripcionDTO> ObtenerSuscripcionPorClinica(int idClinica);
        Task<SuscripcionDTO> CrearSuscripcion(SuscripcionDTO suscripcionDTO);
        Task<bool> ValidarSuscripcionActivaAsync(int idClinica);
    }
}
