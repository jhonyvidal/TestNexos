using Beans;
using Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EditorialBll
    {
        EditorialDAO editorialDal = new EditorialDAO();

        public Task<IEnumerable<EditorialBean>> ListEditorial(int id)
        { 
            return editorialDal.GetEditorial(id);
        }
        public  Task<bool> InsertEditorial(EditorialBean model)
        {
            return editorialDal.InsertEditorial(model);
        }
        public Task<bool> UpdateEditorial(EditorialBean model)
        {
            return editorialDal.UpdateEditorial( model);
        }
        public Task<string> DeleteEditorial( int id)
        {
            return editorialDal.DeleteEditorial(id);
        }
   
    }
}
