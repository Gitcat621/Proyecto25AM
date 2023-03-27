using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public EmpleadoServices(ApplicationDbContext context)
        {
            _context = context;

        }


        #region POST
        public async Task<Response<Empleado>> NuevaEmpleado(EmpleadoResponse request)
        {
            try
            {
                Empleado empleado = new Empleado()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Direccion = request.Direccion,
                    Ciudad = request.Ciudad,
                    FkPuesto = request.FkPuesto,
                    FkDepartamento = request.FkDepartamento,
                };

                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                return new Response<Empleado>(empleado);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Empleado>>> ObtenerEmpleado()
        {
            try
            {
                mensaje = "Registro de empleados";

                var response = await _context.Empleados.Include(x => x.Puesto).Include(z => z.Departamento).ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Empleado>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay registro de empleados";
                    return new Response<List<Empleado>>(response);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion




        #region GET BY ID
        public async Task<Response<Empleado>> EmpleadoPorID(int Id)
        {
            try
            {
                mensaje = "Buscar empleado por ID";
                var res = await _context.Empleados.FindAsync(Id);

                if (res == null)
                {
                    mensaje = "No hay registro de empleados";
                    return new Response<Empleado>(res, mensaje);
                }
                else
                {
                    return new Response<Empleado>(res);
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
        public async Task<Response<Empleado>> EditarEmpleado(EmpleadoResponse request, int Id)
        {
            var consult = _context.Empleados.Find(Id);

            if (consult == null)
            {
                mensaje = "No hay registro de empleados";
                return new Response<Empleado>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Empleado>(consult, mensaje);
            }
            else
            {
                consult.Nombre = request.Nombre;
                consult.Apellidos = request.Apellidos;
                consult.Direccion = request.Direccion;
                consult.Ciudad = request.Ciudad;
                consult.FkPuesto = request.FkPuesto;
                consult.FkDepartamento = request.FkDepartamento;

                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Datos del empleado editados correctamente";
                return new Response<Empleado>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Empleado>> BorrarEmpleado(int Id)
        {
            try
            {
                var consult = await _context.Empleados.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No hay registro de dicho empleado";
                    return new Response<Empleado>(consult, mensaje);
                }
                else
                {
                    _context.Empleados.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Empleado eliminado";
                    return new Response<Empleado>(consult, mensaje);
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
