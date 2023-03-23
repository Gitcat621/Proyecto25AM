using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class PuestoServices : IPuestoServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;

        public PuestoServices(ApplicationDbContext context)
        {
            _context = context;

        }

        #region POST
        public async Task<Response<Puesto>> CrearPuesto(PuestoResponse request)
        {
            try
            {
                Puesto puesto = new Puesto()
                {
                    Nombre = request.Nombre,
                };

                _context.Puestos.Add(puesto);
                await _context.SaveChangesAsync();

                return new Response<Puesto>(puesto);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Puesto>>> GetPuestos()
        {
            try
            {
                mensaje = "Puestos";

                var response = await _context.Puestos.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Puesto>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay nada";
                    return new Response<List<Puesto>>(response);
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
        public async Task<Response<Puesto>> EditPuesto(PuestoResponse request, int Id)
        {
            var consult = _context.Puestos.Find(Id);

            if (consult == null)
            {
                mensaje = "No existe ningun puesto";
                return new Response<Puesto>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Puesto>(consult, mensaje);
            }
            else
            {
                consult.Nombre = request.Nombre;
                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Puestos editados correctamente";
                return new Response<Puesto>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Puesto>> DeletePuesto(int Id)
        {
            try
            {
                var consult = await _context.Puestos.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No existe ningun puesto";
                    return new Response<Puesto>(consult, mensaje);
                }
                else
                {
                    _context.Puestos.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Puestp eliminado";
                    return new Response<Puesto>(consult, mensaje);
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
