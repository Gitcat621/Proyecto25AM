using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);
        public Task<Response<Usuario>> GetUserbyID(int Pk);
        public Task<Response<List<Usuario>>> GetUsers();
        public Task<Response<Usuario>> EditUser(UsuarioResponse request, int pk);
        public Task<Response<Usuario>> DeleteUser(int Pk);

    }
}
