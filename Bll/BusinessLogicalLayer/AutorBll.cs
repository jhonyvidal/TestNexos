using Beans;
using Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AutorBll
    {
        AutorDAO autorDal = new AutorDAO();

        public Task<IEnumerable<AutorBean>> ListAutor(int id)
        { 
            return autorDal.GetAutor(id);
        }
        public  Task<bool> InsertAutor(AutorBean model)
        {
            return autorDal.InsertAutor(model);
        }
        public Task<bool> UpdateAutor(AutorBean model)
        {
            return autorDal.UpdateAutor( model);
        }
        public Task<string> DeleteAutor( int id)
        {
            return autorDal.DeleteAutor(id);
        }
   
    }
}
