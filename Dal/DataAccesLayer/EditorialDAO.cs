using Beans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Datos
{
    public class EditorialDAO 
    {
        RHcontext contexto = new RHcontext();
        public async Task<IEnumerable<EditorialBean>> GetEditorial(int id)
        {
            var context = contexto.CrearContext();

            var resultado =  await context.Editorial.Where(a => a.id_editorial == id || id == 0)
                .OrderByDescending(a => a.id_editorial).ToListAsync();

            if(resultado == null)
            {
                return null;
            }

            return resultado.Select(a => new EditorialBean
            {
                id = a.id_editorial,
                nombre = a.nombre,
                correspondencia = a.correspondencia,
                telefono = a.telefono,
                correo = a.correo,
                max_registros = a.max_registros
               
            });
        }
        public async Task<bool> InsertEditorial(EditorialBean model)
        {
            var context = contexto.CrearContext();
            //DateTime fecha = DateTime.Now;

            Editorial editorial = new Editorial
            {
                nombre = model.nombre,
                correspondencia = model.correspondencia,
                telefono = model.telefono,
                correo = model.correo,
                max_registros = model.max_registros    

            };

            context.Editorial.Add(editorial);


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
        public async Task<bool> UpdateEditorial(EditorialBean model)
        {
            var context = contexto.CrearContext();
            var editorial = await context.Editorial.FirstOrDefaultAsync(u => u.id_editorial == model.id);

                if (editorial == null)
                {
                    return false;
                }

                editorial.nombre = model.nombre;
                editorial.correspondencia = model.correspondencia;
                editorial.telefono = model.telefono;
                editorial.correo = model.correo;
                editorial.max_registros = model.max_registros;

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
        public async Task<string> DeleteEditorial(int id)
        {
            var context = contexto.CrearContext();
            var editorial = await context.Editorial.FindAsync(id);

                    if (editorial == null)
                    {
                        return "No found";
                    }

                    context.Editorial.Remove(editorial);

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


