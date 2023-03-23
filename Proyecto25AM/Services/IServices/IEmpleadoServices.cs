using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IEmpleadoServices
    {
        public Task<Response<Empleado>> NuevaEmpleado(EmpleadoResponse request);
        public Task<Response<List<Empleado>>> ObtenerEmpleado();
        public Task<Response<Empleado>> EmpleadoPorID(int Id);
        public Task<Response<Empleado>> EditarEmpleado(EmpleadoResponse request, int Id);
        public Task<Response<Empleado>> BorrarEmpleado(int Id);


    }
}
