using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<Puesto>> CrearPuesto(PuestoResponse request);
        public Task<Response<List<Puesto>>> GetPuestos();
        public Task<Response<Puesto>> EditPuesto(PuestoResponse request, int Id);
        public Task<Response<Puesto>> DeletePuesto(int Id);

    }
}
