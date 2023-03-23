using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class RolServices : IRolServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;

        }


        #region POST
        public async Task<Response<Rol>> CrearRol(RolResponse request)
        {
            try
            {
                Rol rol = new Rol()
                {
                    Nombre = request.Nombre,
                };

                _context.Roles.Add(rol);
                await _context.SaveChangesAsync();

                return new Response<Rol>(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Rol>>> GetRoles()
        {
            try
            {
                mensaje = "Roles";

                var response = await _context.Roles.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Rol>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay nada";
                    return new Response<List<Rol>>(response);
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
        public async Task<Response<Rol>> EditRol(RolResponse request, int Id)
        {
            var consult = _context.Roles.Find(Id);

            if (consult == null)
            {
                mensaje = "No existe ningun rol";
                return new Response<Rol>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Rol>(consult, mensaje);
            }
            else
            {
                consult.Nombre = request.Nombre;
                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Roles editados correctamente";
                return new Response<Rol>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Rol>> DeleteRol(int Id)
        {
            try
            {
                var consult = await _context.Roles.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No existe ningun rol";
                    return new Response<Rol>(consult, mensaje);
                }
                else
                {
                    _context.Roles.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Rol eliminado";
                    return new Response<Rol>(consult, mensaje);
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
