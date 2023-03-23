using Domain.Dto;
using Domain.Entities;

namespace Proyecto25AM.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<Factura>> NuevaFactura(FacturaResponse request);
        public Task<Response<List<Factura>>> ObtenerFactura();
        public Task<Response<Factura>> FacturaPorID(int Id);
        public Task<Response<Factura>> EditarFactura(FacturaResponse request, int Id);
        public Task<Response<Factura>> BorrarFactura(int Id);

    }
}
