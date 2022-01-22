using Beans;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class UsuarioController : ControllerBase
        {
      
        UsuarioBll UsuarioBll = new UsuarioBll();

        // GET: api/Usuario/List/0
        [HttpGet("[action]/{id}")]
        public  Task<IEnumerable<UsuarioBean>> List([FromRoute] int id)
        {

            return UsuarioBll.ListUsuario(id);
        }
        // GET: api/Usuario/ListText/texto
        [HttpGet("[action]/{Texto}")]
        public Task<IEnumerable<UsuarioBean>> ListText([FromRoute] string Texto)
        {
            return UsuarioBll.ListUsuarioTexto(Texto);
        }


        // POST: api/Usuario/Insert
        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] UsuarioBean model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //Insert Datos y Envio de correo
            var consulta = await UsuarioBll.InsertUsuario(model);
            if(consulta == false) { return BadRequest(); }

            return Ok();

        }

        // PUT: api/Usuario/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UsuarioBean model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }
            var consulta = await UsuarioBll.UpdateUsuario(model);

            if (consulta == true) { return Ok(); }
            else { return BadRequest(); }
        }
        // DELETE: api/Libro/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = await UsuarioBll.DeleteUsuario( id);

            if (consulta == "ok") { return Ok(); }
            else { return BadRequest(consulta); }
        }

    }
}

