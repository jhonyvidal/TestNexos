using Beans;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class AutorController : ControllerBase
        {

        AutorBll autorBLL = new AutorBll();

        // GET: api/Autor/List/0
        [HttpGet("[action]/{id}")]
        public  Task<IEnumerable<AutorBean>> List([FromRoute] int id)
        {
            return autorBLL.ListAutor(id);
        }

        // POST: api/Autor/Insert
        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] AutorBean model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //Insert Datos y Envio de correo
            var consulta = await autorBLL.InsertAutor(model);
            if(consulta == false) { return BadRequest(); }

            return Ok();

        }

        // PUT: api/Autor/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] AutorBean model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }
            var consulta = await autorBLL.UpdateAutor(model);

            if (consulta == true) { return Ok(); }
            else { return BadRequest(); }
        }
        // DELETE: api/Autor/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = await autorBLL.DeleteAutor( id);

            if (consulta == "ok") { return Ok(); }
            else { return BadRequest(consulta); }
        }

    }
}

