using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ClienteResponse i)
        {
            return Ok(await _clienteServices.NuevoCliente(i));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {
            return Ok(await _clienteServices.ObtenerCliente());
        }

        [HttpPut("Editar/{ID}")]
        public async Task<IActionResult> EditarCliente([FromBody] ClienteResponse request, int Id)
        {
            return Ok(await _clienteServices.EditarCliente(request, Id));
        }

        [HttpGet("ByID/{ID}")]
        public async Task<IActionResult> ClientePorID(int Id)
        {
            return Ok(await _clienteServices.ClientePorID(Id));
        }

        [HttpDelete("Borrar/{ID}")]
        public async Task<IActionResult> BorrarCliente(int Id)
        {
            return Ok(await _clienteServices.BorrarCliente(Id));
        }
    }
}
