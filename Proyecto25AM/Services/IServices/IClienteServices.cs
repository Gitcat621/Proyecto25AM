using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<Cliente>> NuevoCliente(ClienteResponse request);
        public Task<Response<List<Cliente>>> ObtenerCliente();
        public Task<Response<Cliente>> ClientePorID(int Id);
        public Task<Response<Cliente>> EditarCliente(ClienteResponse request, int Id);
        public Task<Response<Cliente>> BorrarCliente(int Id);

    }
}
