using TesteApp.Client;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        public TarefasController()
        {
        }


        // GET all action       
        /// <summary>
        /// Get all Tarefas
        /// </summary>
        /// <returns>Returns a list of Tarefas</returns>
        [HttpGet]
        public ActionResult<List<ItemTarefa>> GetAll() =>
        TarefaServices.GetAll();


        /// <summary>
        /// Get all Tarefas Done
        /// </summary>
        /// <returns>Returns a list of Tarefas Done</returns>
        [HttpGet("Done")]
        public ActionResult<List<ItemTarefa>> GetAllDone() => TarefaServices.GetAllDone();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<ItemTarefa> Get(int id)
        {
            var tarefa = TarefaServices.Get(id);

            if (tarefa == null)
                return NotFound();

            return tarefa;
        }

        // POST action = Criar
        [HttpPost]
        public IActionResult Create(ItemTarefa tarefa)
        {
            // This code will save the tarefa and return a result
            TarefaServices.Add(tarefa);
            return CreatedAtAction(nameof(Create), new { id = tarefa.Id }, tarefa);

        }

        // PUT action = Atualizar
        [HttpPut("{id}")]
        public IActionResult Update(int id, ItemTarefa tarefa)
        {
            // This code will update the tarefa and return a result
            if (id != tarefa.Id)
                return BadRequest();

            var existingTarefa = TarefaServices.Get(id);
            if (existingTarefa is null)
                return NotFound();

            TarefaServices.Update(tarefa);

            return NoContent();

        }

        // DELETE action 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // This code will delete the tarefa and return a result
            var tarefa = TarefaServices.Get(id);

            if (tarefa is null)
                return NotFound();

            TarefaServices.Delete(id);

            return NoContent();

        }




    }

}