// Archivo: FacturaRepositorio.cs 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ERP.Domain.Facturacion.Entidades;
using ERP.Application.Facturacion.Interfaces;
using ERP.Infrastructure.Data;

namespace ERP.Infrastructure.Facturacion.Repositorios
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private readonly ContextoDatos _contexto;

        public FacturaRepositorio(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<Factura> ObtenerPorIdAsync(int idFactura)
        {
            return await _contexto.Facturas.FindAsync(idFactura);
        }

        public async Task<List<Factura>> ObtenerPorPacienteAsync(int idPaciente)
        {
            return await _contexto.Facturas
                .Where(f => f.IdPaciente == idPaciente)
                .ToListAsync();
        }

        public async Task CrearFacturaAsync(Factura factura)
        {
            await _contexto.Facturas.AddAsync(factura);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarFacturaAsync(Factura factura)
        {
            _contexto.Facturas.Update(factura);
            await _contexto.SaveChangesAsync();
        }
    }
}
