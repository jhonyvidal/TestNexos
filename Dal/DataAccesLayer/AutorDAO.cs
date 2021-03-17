using Beans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Datos
{
    public class AutorDAO 
    {
        RHcontext contexto = new RHcontext();
        public async Task<IEnumerable<AutorBean>> GetAutor(int id)
        {
            var context = contexto.CrearContext();

            var resultado =  await context.Autor.Where(a => a.id_autor == id || id == 0)
                .OrderByDescending(a => a.id_autor).ToListAsync();

            return resultado.Select(a => new AutorBean
            {
                id = a.id_autor,
                nombre = a.nombre,
                fecha = a.fecha,
                ciudad = a.ciudad,
                correo = a.correo
               
            });
        }
        public async Task<bool> InsertAutor(AutorBean model)
        {
            var context = contexto.CrearContext();
            //DateTime fecha = DateTime.Now;

            Autor autor = new Autor
            {
                nombre = model.nombre,
                fecha = model.fecha,
                ciudad = model.ciudad,
                correo = model.correo,

            };

            context.Autor.Add(autor);


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
        public async Task<bool> UpdateAutor(AutorBean model)
        {
            var context = contexto.CrearContext();
            var autor = await context.Autor.FirstOrDefaultAsync(u => u.id_autor == model.id);

                if (autor == null)
                {
                    return false;
                }

                autor.nombre = model.nombre;
                autor.fecha = model.fecha;
                autor.ciudad = model.ciudad;
                autor.correo = model.correo;
               

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
        public async Task<string> DeleteAutor(int id)
        {
            var context = contexto.CrearContext();
            var autor = await context.Autor.FindAsync(id);

                    if (autor == null)
                    {
                        return "No found";
                    }

                    context.Autor.Remove(autor);

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


