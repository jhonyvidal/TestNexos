using Beans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Datos
{
    public class LibroDAO 
    {
        RHcontext contexto = new RHcontext();
        
        public async Task<IEnumerable<LibroBean>> GetLibro(int id)
        {
            var context = contexto.CrearContext();

            var resultado =  await context.Libro.Include(a=>a.Autor).Include(a => a.Editorial)
                .Where(a => a.id_Libro == id || id == 0)
                .OrderByDescending(a => a.id_Libro).ToListAsync();

            if(resultado == null)
            {
                return null;
            }

            return resultado.Select(a => new LibroBean
            {
                id = a.id_Libro,
                id_autor = a.id_autor,
                id_editorial = a.id_editorial,
                titulo = a.titulo,
                autor = a.Autor.nombre,
                editorial = a.Editorial.nombre,
                year = a.año.ToString(),
                genero = a.genero,
                numero_paginas= a.numero_paginas

               
            });
        }
        public async Task<IEnumerable<LibroBean>> GetLibroTexto(string texto)
        {
            var context = contexto.CrearContext();

            var resultado = await context.Libro.Include(a => a.Autor).Include(a => a.Editorial)
                .Where(a => a.titulo.Contains(texto))
                .OrderByDescending(a => a.id_Libro).ToListAsync();

            if (resultado == null)
            {
                return null;
            }

            return resultado.Select(a => new LibroBean
            {
                id = a.id_Libro,
                id_autor = a.id_autor,
                id_editorial = a.id_editorial,
                titulo = a.titulo,
                autor = a.Autor.nombre,
                editorial = a.Editorial.nombre,
                year = a.año.ToString(),
                genero = a.genero,
                numero_paginas = a.numero_paginas


            });
        }
        public async Task<IEnumerable<LibroBean>> GetLibroAutor(string texto)
        {
            var context = contexto.CrearContext();

            var resultado = await context.Libro.Include(a => a.Autor).Include(a => a.Editorial)
                .Where(a => a.Autor.nombre.Contains(texto))
                .OrderByDescending(a => a.id_Libro).ToListAsync();

            if (resultado == null)
            {
                return null;
            }

            return resultado.Select(a => new LibroBean
            {
                id = a.id_Libro,
                id_autor = a.id_autor,
                id_editorial = a.id_editorial,
                titulo = a.titulo,
                autor = a.Autor.nombre,
                editorial = a.Editorial.nombre,
                year = a.año.ToString(),
                genero = a.genero,
                numero_paginas = a.numero_paginas


            });
        }
        public async Task<IEnumerable<LibroBean>> GetLibroFecha(string finicial, string ffinal)
        {
            var context = contexto.CrearContext();
            DateTime fechainicial = Convert.ToDateTime(finicial);
            DateTime fechafinal = Convert.ToDateTime(ffinal);

            var resultado = await context.Libro.Include(a => a.Autor).Include(a => a.Editorial)
                .Where(c => c.año >= fechainicial && c.año <= fechafinal)
                .OrderByDescending(a => a.id_Libro).ToListAsync();

            if (resultado == null)
            {
            }

            return resultado.Select(a => new LibroBean
            {
                id = a.id_Libro,
                id_autor = a.id_autor,
                id_editorial = a.id_editorial,
                titulo = a.titulo,
                autor = a.Autor.nombre,
                editorial = a.Editorial.nombre,
                year = a.año.ToString(),
                genero = a.genero,
                numero_paginas = a.numero_paginas


            });
        }
        public async Task<bool> InsertLibro(LibroBean model)
        {
            var context = contexto.CrearContext();
            DateTime fecha = DateTime.Now;

            Libro libro = new Libro
            {
                id_autor = model.id_autor,
                id_editorial = model.id_editorial,
                titulo = model.titulo,
                año = model.año,
                genero = model.genero,
                numero_paginas = model.numero_paginas

            };

            context.Libro.Add(libro);


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
        public async Task<bool> UpdateLibro(LibroBean model)
        {
            var context = contexto.CrearContext();
            var libro = await context.Libro.FirstOrDefaultAsync(u => u.id_Libro == model.id);

                if (libro == null)
                {
                    return false;
                }

                libro.id_autor = model.id_autor;
                libro.id_editorial = model.id_editorial;
                libro.titulo = model.titulo;
                libro.genero = model.genero;
                libro.numero_paginas = model.numero_paginas;

             

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
        public async Task<string> DeleteLibro(int id)
        {
            var context = contexto.CrearContext();
            var libro = await context.Libro.FindAsync(id);

                    if (libro == null)
                    {
                        return "No found";
                    }

                    context.Libro.Remove(libro);

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


