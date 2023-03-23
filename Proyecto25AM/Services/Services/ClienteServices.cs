using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
namespace Proyecto25AM.Services.Services
{
    public class ClienteServices : IClienteServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;

        }

        #region POST
        public async Task<Response<Cliente>> NuevoCliente(ClienteResponse request)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Telefono = request.Telefono,
                    Email = request.Email,
                    Direccion = request.Direccion,
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////


        #region GET
        public async Task<Response<List<Cliente>>> ObtenerCliente()
        {
            try
            {
                mensaje = "Registro de clientes";

                var response = await _context.Clientes.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Cliente>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay registro de clientes";
                    return new Response<List<Cliente>>(response);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }
        #endregion




        #region GET BY ID
        public async Task<Response<Cliente>> ClientePorID(int Id)
        {
            try
            {
                mensaje = "Buscar cliente por ID";
                var res = await _context.Clientes.FindAsync(Id);

                if (res == null)
                {
                    mensaje = "No hay registro de clientes";
                    return new Response<Cliente>(res, mensaje);
                }
                else
                {
                    return new Response<Cliente>(res);
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
        public async Task<Response<Cliente>> EditarCliente(ClienteResponse request, int Id)
        {
            var consult = _context.Clientes.Find(Id);

            if (consult == null)
            {
                mensaje = "No hay registro de clientes";
                return new Response<Cliente>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Cliente>(consult, mensaje);
            }
            else
            {
                consult.Nombre = request.Nombre;
                consult.Apellidos = request.Apellidos;
                consult.Telefono = request.Telefono;
                consult.Email = request.Email;
                consult.Direccion = request.Direccion;


                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Datos del cliente editados correctamente";
                return new Response<Cliente>(consult, mensaje);
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////

        #region DELETE
        public async Task<Response<Cliente>> BorrarCliente(int Id)
        {
            try
            {
                var consult = await _context.Clientes.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No hay registro de dicho cliente";
                    return new Response<Cliente>(consult, mensaje);
                }
                else
                {
                    _context.Clientes.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Cliente eliminado";
                    return new Response<Cliente>(consult, mensaje);
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
