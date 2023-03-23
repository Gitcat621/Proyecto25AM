using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioResponse i)
        {
            return Ok(await _usuarioServices.CrearUsuario(i));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok (await _usuarioServices.GetUsers());
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody]UsuarioResponse request, int Id)
        {
            return Ok(await _usuarioServices.EditUser(request, Id));
        }

        [HttpGet("BuscarPorID")]
        public async Task<IActionResult> GetUserbyID(int Id)
        {
            return Ok(await _usuarioServices.GetUserbyID(Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            return Ok(await _usuarioServices.DeleteUser(Id));
        }
    }

}
