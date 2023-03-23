using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class DepartamentoServices : IDepartamentoServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public DepartamentoServices(ApplicationDbContext context)
        {
            _context = context;

        }

        #region POST
        public async Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse request)
        {
            try
            {
                Departamento dep = new Departamento()
                {
                    Nombre = request.Nombre,
                };

                _context.Departamentos.Add(dep);
                await _context.SaveChangesAsync();

                return new Response<Departamento>(dep);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Departamento>>> GetDepartamentos()
        {
            try
            {
                mensaje = "Departamentos";

                var response = await _context.Departamentos.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Departamento>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay nada";
                    return new Response<List<Departamento>>(response);
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
        public async Task<Response<Departamento>> EditDepartamento(DepartamentoResponse request, int Id)
        {
            var consult = _context.Departamentos.Find(Id);

            if (consult == null)
            {
                mensaje = "No existe ningun departamento";
                return new Response<Departamento>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Departamento>(consult, mensaje);
            }
            else
            {
                consult.Nombre = request.Nombre;
                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Departamentos editados correctamente";
                return new Response<Departamento>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Departamento>> DeleteDepartamento(int Id)
        {
            try
            {
                var consult = await _context.Departamentos.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No existe ningun departamento";
                    return new Response<Departamento>(consult, mensaje);
                }
                else
                {
                    _context.Departamentos.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Departamento eliminado";
                    return new Response<Departamento>(consult, mensaje);
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
