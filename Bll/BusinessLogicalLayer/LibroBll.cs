using Beans;
using Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LibroBll
    {
        LibroDAO libroDal = new LibroDAO();

        public Task<IEnumerable<LibroBean>> ListLibro(int id)
        { 
            return libroDal.GetLibro(id);
        }
        public Task<IEnumerable<LibroBean>> ListLibroTexto(string Texto)
        {
            return libroDal.GetLibroTexto(Texto);
        }
        public Task<IEnumerable<LibroBean>> ListLibroAutor(string Texto)
        {
            return libroDal.GetLibroAutor(Texto);
        }
        public Task<IEnumerable<LibroBean>> ListLibroFecha(string finicial, string ffinal)
        {
            return libroDal.GetLibroFecha(finicial,ffinal);
        }
        public  Task<bool> InsertLibro(LibroBean model)
        {
            return libroDal.InsertLibro(model);
        }
        public Task<bool> UpdateLibro(LibroBean model)
        {
            return libroDal.UpdateLibro( model);
        }
        public Task<string> DeleteLibro( int id)
        {
            return libroDal.DeleteLibro(id);
        }
   
    }
}
