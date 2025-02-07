// Archivo: IAutenticacionServicio.cs 
using System.Threading.Tasks;
using ERP.Application.Autenticacion.DTOs;

namespace ERP.Application.Autenticacion.Interfaces
{
    public interface IAutenticacionServicio
    {
        Task<AutenticacionResponseDTO> Autenticar(LoginDTO loginDTO);
    }
}
