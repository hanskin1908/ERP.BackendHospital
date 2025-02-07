// Archivo: SuscripcionServicio.cs 
using ERP.Application.Suscripcions.DTOs;
using ERP.Application.Suscripcions.Interfaces;
using ERP.Domain.Suscripcions.Entidades;
using System.Threading.Tasks;

namespace ERP.Application.Suscripcions.Servicios
{
    public class SuscripcionServicio : ISuscripcionServicio
    {
        private readonly ISuscripcionRepositorio _repositorioSuscripcion;
        public SuscripcionServicio(ISuscripcionRepositorio repositorioSuscripcion)
        {
            _repositorioSuscripcion = repositorioSuscripcion;
        }

        public async Task<SuscripcionDTO> ObtenerSuscripcionPorClinica(int idClinica)
        {
            Suscripcion suscripcion = await _repositorioSuscripcion.ObtenerSuscripcionPorClinica(idClinica);
            if (suscripcion == null) return null;

            return new SuscripcionDTO
            {
                IdSuscripcion = suscripcion.IdSuscripcion,
                IdClinica = suscripcion.IdClinica,
                Estado = suscripcion.Estado,
                FechaInicio = suscripcion.FechaInicio,
                FechaFin = suscripcion.FechaFin,
                UltimoPago = suscripcion.UltimoPago,
                Plan = suscripcion.Plan
            };
        }

        public async Task<SuscripcionDTO> CrearSuscripcion(SuscripcionDTO suscripcionDTO)
        {
            Suscripcion suscripcion = new Suscripcion
            {
                IdClinica = suscripcionDTO.IdClinica,
                Estado = suscripcionDTO.Estado,
                FechaInicio = suscripcionDTO.FechaInicio,
                FechaFin = suscripcionDTO.FechaFin,
                UltimoPago = suscripcionDTO.UltimoPago,
                Plan = suscripcionDTO.Plan
            };
            Suscripcion creada = await _repositorioSuscripcion.CrearSuscripcion(suscripcion);
            suscripcionDTO.IdSuscripcion = creada.IdSuscripcion;
            return suscripcionDTO;
        }

        public async Task<bool> ValidarSuscripcionActivaAsync(int idClinica)
        {
            return await _repositorioSuscripcion.ExisteSuscripcionActivaAsync(idClinica);
        }
    }
}
