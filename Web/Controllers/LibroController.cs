using Beans;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class LibroController : ControllerBase
        {
      
        LibroBll libroBLL = new LibroBll();

        // GET: api/Libro/List/0
        [HttpGet("[action]/{id}")]
        public  Task<IEnumerable<LibroBean>> List([FromRoute] int id)
        {

            return libroBLL.ListLibro(id);
        }
        // GET: api/Libro/ListText/texto
        [HttpGet("[action]/{Texto}")]
        public Task<IEnumerable<LibroBean>> ListText([FromRoute] string Texto)
        {
            return libroBLL.ListLibroTexto(Texto);
        }
        // GET: api/Libro/ListAutor/texto
        [HttpGet("[action]/{Texto}")]
        public Task<IEnumerable<LibroBean>> ListAutor([FromRoute] string Texto)
        {
            return libroBLL.ListLibroAutor(Texto);
        }
        // GET: api/Libro/ListFecha/fechainical/fechafinal
        [HttpGet("[action]/{finicial}/{ffinal}")]
        public Task<IEnumerable<LibroBean>> ListFecha([FromRoute] string finicial, string ffinal)
        {
            return libroBLL.ListLibroFecha(finicial,ffinal);
        }

        // POST: api/Libro/Insert
        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] LibroBean model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //Insert Datos y Envio de correo
            var consulta = await libroBLL.InsertLibro(model);
            if(consulta == false) { return BadRequest(); }

            return Ok();

        }

        // PUT: api/Libro/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] LibroBean model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }
            var consulta = await libroBLL.UpdateLibro(model);

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

            var consulta = await libroBLL.DeleteLibro( id);

            if (consulta == "ok") { return Ok(); }
            else { return BadRequest(consulta); }
        }

    }
}

