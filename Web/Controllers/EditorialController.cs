using Beans;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class EditorialController : ControllerBase
        {

        EditorialBll editorialBLL = new EditorialBll();

        // GET: api/Editorial/List/0
        [HttpGet("[action]/{id}")]
        public  Task<IEnumerable<EditorialBean>> List([FromRoute] int id)
        {
            return editorialBLL.ListEditorial(id);
        }

        // POST: api/Editorial/Insert
        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] EditorialBean model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //Insert Datos y Envio de correo
            var consulta = await editorialBLL.InsertEditorial(model);
            if(consulta == false) { return BadRequest(); }

            return Ok();

        }

        // PUT: api/Editorial/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] EditorialBean model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }
            var consulta = await editorialBLL.UpdateEditorial(model);

            if (consulta == true) { return Ok(); }
            else { return BadRequest(); }
        }
        // DELETE: api/Editorial/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = await editorialBLL.DeleteEditorial( id);

            if (consulta == "ok") { return Ok(); }
            else { return BadRequest(consulta); }
        }

    }
}

