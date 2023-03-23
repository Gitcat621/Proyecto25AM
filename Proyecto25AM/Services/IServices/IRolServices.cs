using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<Rol>> CrearRol(RolResponse request);
        public Task<Response<List<Rol>>> GetRoles();
        public Task<Response<Rol>> EditRol(RolResponse request, int Id);
        public Task<Response<Rol>> DeleteRol(int Id);



    }
}
