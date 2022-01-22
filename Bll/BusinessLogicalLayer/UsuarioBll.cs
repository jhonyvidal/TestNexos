using Beans;
using Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBll
    {
        UsuarioDAO UsuarioDal = new UsuarioDAO();

        public Task<IEnumerable<UsuarioBean>> ListUsuario(int id)
        { 
            return UsuarioDal.GetUsuario(id);
        }
        public Task<IEnumerable<UsuarioBean>> ListUsuarioTexto(string Texto)
        {
            return UsuarioDal.GetUsuarioTexto(Texto);
        }
    

        public  Task<bool> InsertUsuario(UsuarioBean model)
        {
            return UsuarioDal.InsertUsuario(model);
        }
        public Task<bool> UpdateUsuario(UsuarioBean model)
        {
            return UsuarioDal.UpdateUsuario( model);
        }
        public Task<string> DeleteUsuario( int id)
        {
            return UsuarioDal.DeleteUsuario(id);
        }
   
    }
}
