using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;


namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoServices _puestoServices;
        public PuestoController(IPuestoServices puestoServices)
        {
            _puestoServices = puestoServices;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPuesto([FromBody] PuestoResponse i)
        {
            return Ok(await _puestoServices.CrearPuesto(i));
        }

        [HttpGet]
        public async Task<IActionResult> GetPuestos()
        {
            return Ok(await _puestoServices.GetPuestos());
        }

        [HttpPut]
        public async Task<IActionResult> EditPuesto([FromBody] PuestoResponse request, int Id)
        {
            return Ok(await _puestoServices.EditPuesto(request, Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePuesto(int Id)
        {
            return Ok(await _puestoServices.DeletePuesto(Id));
        }
    }
}
