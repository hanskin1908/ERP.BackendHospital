using System.Threading.Tasks;
using ERP.Domain.Autenticacion.Entidades;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IAutenticacionRepositorio
    {
        Task<Usuario> ObtenerUsuarioPorNombre(string nombreUsuario);
    }
}
// Archivo: IAutenticacionRepositorio.cs 
