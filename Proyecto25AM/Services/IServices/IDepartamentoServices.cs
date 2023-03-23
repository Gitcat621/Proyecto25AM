
using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse request);
        public Task<Response<List<Departamento>>> GetDepartamentos();
        public Task<Response<Departamento>> EditDepartamento(DepartamentoResponse request, int Id);
        public Task<Response<Departamento>> DeleteDepartamento(int Id);



    }
}
