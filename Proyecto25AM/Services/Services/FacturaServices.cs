using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class FacturaServices : IFacturaServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public FacturaServices(ApplicationDbContext context)
        {
            _context = context;

        }

        #region POST
        public async Task<Response<Factura>> NuevaFactura(FacturaResponse request)
        {
            try
            {
                Factura factura = new Factura()
                {
                    RazonSocial = request.RazonSocial,
                    Fecha = request.Fecha,
                    RFC = request.RFC,
                    IDCliente = request.IDCliente,
                };

                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();

                return new Response<Factura>(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Factura>>> ObtenerFactura()
        {
            try
            {
                mensaje = "Registro de facturas";

                var response = await _context.Facturas.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Factura>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay registro de facturas";
                    return new Response<List<Factura>>(response);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion




        #region GET BY ID
        public async Task<Response<Factura>> FacturaPorID(int Id)
        {
            try
            {
                mensaje = "Buscar factura por ID";
                var res = await _context.Facturas.FindAsync(Id);

                if (res == null)
                {
                    mensaje = "No hay registro de dicha factura";
                    return new Response<Factura>(res, mensaje);
                }
                else
                {
                    return new Response<Factura>(res);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////

        #region PUT
        public async Task<Response<Factura>> EditarFactura(FacturaResponse request, int Id)
        {
            var consult = _context.Facturas.Find(Id);

            if (consult == null)
            {
                mensaje = "No hay registro de dicha factura";
                return new Response<Factura>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Factura>(consult, mensaje);
            }
            else
            {
                consult.RazonSocial = request.RazonSocial;
                consult.Fecha = request.Fecha;
                consult.RFC = request.RFC;
                consult.IDCliente = request.IDCliente;
                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Factura editada correctamente";
                return new Response<Factura>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Factura>> BorrarFactura(int Id)
        {
            try
            {
                var consult = await _context.Facturas.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No hay registro de dicha factura";
                    return new Response<Factura>(consult, mensaje);
                }
                else
                {
                    _context.Facturas.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Puestp eliminado";
                    return new Response<Factura>(consult, mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion
    }
}
