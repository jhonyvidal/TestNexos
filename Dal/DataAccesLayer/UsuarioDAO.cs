using Beans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Datos
{
    public class UsuarioDAO 
    {
        RHcontext contexto = new RHcontext();
        
        public async Task<IEnumerable<UsuarioBean>> GetUsuario(int id)
        {
            var context = contexto.CrearContext();
            try
            {
                var resultado = await context.Usuario
               .Where(a => a.usuID == id || id == 0)
               .OrderByDescending(a => a.usuID).ToListAsync();

                return resultado.Select(a => new UsuarioBean
                {
                    id = a.usuID,
                    nombre = a.nombre,
                    apellido = a.apellido

                });

            }
            catch(Exception ex)
            {
                return null;
            }

        }
        public async Task<IEnumerable<UsuarioBean>> GetUsuarioTexto(string texto)
        {
            var context = contexto.CrearContext();

            var resultado = await context.Usuario
                .Where(a => a.nombre.Contains(texto))
                .OrderByDescending(a => a.usuID).ToListAsync();

            if (resultado == null)
            {
                return null;
            }

            return resultado.Select(a => new UsuarioBean
            {
                id = a.usuID,
                nombre = a.nombre,
                apellido = a.apellido

            });
        }
    
       
        public async Task<bool> InsertUsuario(UsuarioBean model)
        {
            var context = contexto.CrearContext();
            DateTime fecha = DateTime.Now;

            Usuario  Usuario = new Usuario
            {
                usuID= model.id,
                nombre = model.nombre,
                apellido = model.apellido,
            };

            context.Usuario.Add(Usuario);


            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public async Task<bool> UpdateUsuario(UsuarioBean model)
        {
            var context = contexto.CrearContext();
            var libro = await context.Usuario.FirstOrDefaultAsync(u => u.usuID == model.id);

                if (libro == null)
                {
                    return false;
                }

                libro.usuID = model.id;
                libro.nombre = model.nombre;
                libro.apellido = model.apellido;

                try
                {
                       await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                     return false;
                }

            return true;
        }
        public async Task<string> DeleteUsuario(int id)
        {
            var context = contexto.CrearContext();
            var usuario = await context.Usuario.FindAsync(id);

                    if (usuario == null)
                    {
                        return "No found";
                    }

                    context.Usuario.Remove(usuario);

                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return "ex:" + ex;
                    }

                    return "ok";
        }

    }
}


