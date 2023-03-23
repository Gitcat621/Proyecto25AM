using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using System;
using System.Linq;
using System.Collections.Generic;



namespace Proyecto25AM.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public readonly ApplicationDbContext _context;
        public string mensaje;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }

        //creacion de funciones CRUD 

        // CREAR - POST 
        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario user = new Usuario()
                {
                    User = request.User,
                    Password = request.Password,
                    FechaRegistro = request.FechaRegistro,
                    IDEmpleado = request.IDEmpleado,
                    IDRol = request.IDRol
                };

                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }

        // CONSULTAR POR ID
        public async Task<Response<Usuario>> GetUserbyID(int Id)
        {
            try
            {
                mensaje = "Buscar usuario por ID";
                var res = await _context.Usuarios.FindAsync(Id);

                if (res == null)
                {
                    mensaje = "No se encontro ningun usuario";
                    return new Response<Usuario>(res, mensaje);
                }
                else
                {
                    return new Response<Usuario>(res);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }

        // LEER/CONSULTAR - get 
        public async Task<Response<List<Usuario>>> GetUsers()
        {
            try
            {
                mensaje = "La lista de usuarios";

                var response = await _context.Usuarios.ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Usuario>>(response, mensaje);
                }
                else
                {
                    mensaje = "No hay nada";
                    return new Response<List<Usuario>>(response);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }

        // BORRAR - DELETE 
        public async Task<Response<Usuario>> DeleteUser(int Id)
        {
            try
            {
                var consult = await _context.Usuarios.FindAsync(Id);
                if (consult == null)
                {
                    mensaje = "No se encontro ningun usuario";
                    return new Response<Usuario>(consult, mensaje);
                }
                else
                {
                    _context.Usuarios.Remove(consult);
                    _context.SaveChanges();
                    mensaje = "Usuario eliminado";
                    return new Response<Usuario>(consult, mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
        }


        //Editar - PuT 
        public async Task<Response<Usuario>> EditUser(UsuarioResponse request, int Id)
        {
            var consult = _context.Usuarios.Find(Id);

            if (consult == null)
            {
                mensaje = "No se encontro ningun usuario";
                return new Response<Usuario>(consult, mensaje);
            }
            else if (request == null)
            {
                mensaje = "Ingresa datos para continuar";
                return new Response<Usuario>(consult, mensaje);
            }
            else
            {
                consult.User = request.User;
                consult.Password = request.Password;
                consult.FechaRegistro = request.FechaRegistro;
                consult.IDEmpleado = request.IDEmpleado;
                consult.IDRol = request.IDRol;


                _context.Entry(consult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                mensaje = "Los datos del usuario han sido editados correctamente";
                return new Response<Usuario>(consult, mensaje);
            }
        }
    }
}
