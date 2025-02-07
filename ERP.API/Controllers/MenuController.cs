// Archivo: MenuController.cs 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using ERP.Application.Menus.Interfaces;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServicio _servicioMenu;

        public MenuController(IMenuServicio servicioMenu)
        {
            _servicioMenu = servicioMenu;
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerMenuPorUsuario(int idUsuario)
        {
            var menu = await _servicioMenu.ObtenerMenuPorIdUsuario(idUsuario);
            return Ok(menu);
        }
    }
}
