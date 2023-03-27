using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] RolResponse i)
        {
            return Ok(await _rolServices.CrearRol(i));
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _rolServices.GetRoles());
        }

        [HttpPut("Editar/{ID}")]
        public async Task<IActionResult> EditRol([FromBody] RolResponse request, int Id)
        {
            return Ok(await _rolServices.EditRol(request, Id));
        }

        [HttpDelete("Borrar/{ID}")]
        public async Task<IActionResult> DeleteRol(int Id)
        {
            return Ok(await _rolServices.DeleteRol(Id));
        }
    }
}
