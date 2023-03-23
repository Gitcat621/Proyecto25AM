using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoServices _departamentoServices;
        public DepartamentoController(IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DepartamentoResponse i)
        {
            return Ok(await _departamentoServices.CrearDepartamento(i));
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            return Ok(await _departamentoServices.GetDepartamentos());
        }

        [HttpPut]
        public async Task<IActionResult> EditDepartamento([FromBody] DepartamentoResponse request, int Id)
        {
            return Ok(await _departamentoServices.EditDepartamento(request, Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartamento(int Id)
        {
            return Ok(await _departamentoServices.DeleteDepartamento(Id));
        }
    }
}
