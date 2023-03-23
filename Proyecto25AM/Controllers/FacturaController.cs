using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServices _facturaServices;
        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        [HttpPost]
        public async Task<IActionResult> NuevaFactura([FromBody] FacturaResponse i)
        {
            return Ok(await _facturaServices.NuevaFactura(i));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFactura()
        {
            return Ok(await _facturaServices.ObtenerFactura());
        }

        [HttpPut]
        public async Task<IActionResult> EditarFactura([FromBody] FacturaResponse request, int Id)
        {
            return Ok(await _facturaServices.EditarFactura(request, Id));
        }

        [HttpGet("BuscarPorID")]
        public async Task<IActionResult> FacturaPorID(int Id)
        {
            return Ok(await _facturaServices.FacturaPorID(Id));
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarFactura(int Id)
        {
            return Ok(await _facturaServices.BorrarFactura(Id));
        }
    }
}
