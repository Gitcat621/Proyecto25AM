using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServices _empleadoServices;
        public EmpleadoController(IEmpleadoServices empleadoServices)
        {
            _empleadoServices = empleadoServices;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] EmpleadoResponse i)
        {
            return Ok(await _empleadoServices.NuevaEmpleado(i));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleado()
        {
            return Ok(await _empleadoServices.ObtenerEmpleado());
        }

        [HttpPut]
        public async Task<IActionResult> EditarEmpleado([FromBody] EmpleadoResponse request, int Id)
        {
            return Ok(await _empleadoServices.EditarEmpleado(request, Id));
        }

        [HttpGet("BuscarPorID")]
        public async Task<IActionResult> EmpleadoPorID(int Id)
        {
            return Ok(await _empleadoServices.EmpleadoPorID(Id));
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarEmpleado(int Id)
        {
            return Ok(await _empleadoServices.BorrarEmpleado(Id));
        }
    }
}
