using TesteApp.Client;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TarefasControllers : ControllerBase
    {
        public TarefasControllers()
        {
        }


        // GET all action       
        /// <summary>
        /// Lista todas as Tarefas
        /// </summary>
        /// <returns>Returns a list of Tarefas</returns>
        [HttpGet]
        public ActionResult<List<ItemTarefa>> GetAll() =>
        TarefaServices.GetAll();


        /// <summary>
        /// Lista todas as Tarefas com status concluído
        /// </summary>
        /// <returns>Returns a list of Tarefas Done</returns>
        [HttpGet("Done")]
        public ActionResult<List<ItemTarefa>> GetAllDone() => TarefaServices.GetAllDone();

        /// <summary>
        /// Busca Tarefa pelo seu id
        /// </summary>
        /// <returns>Returns Tarefa by id</returns>
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<ItemTarefa> Get(int id)
        {
            var tarefa = TarefaServices.Get(id);

            if (tarefa == null)
                return NotFound();

            return tarefa;
        }


        /// <summary>
        /// Cria um Tarefa nova
        /// </summary>
        /// <returns>Create a new task</returns>
        // POST action = Criar
        [HttpPost]
        public IActionResult Create(ItemTarefa tarefa)
        {
            // This code will save the tarefa and return a result
            if (TarefaServices.itsnew(tarefa)==false)
            {
                return BadRequest();
            }

            TarefaServices.Add(tarefa);
            return CreatedAtAction(nameof(Create), new { id = tarefa.Id }, tarefa);

        }


        /// <summary>
        /// Alterar tarefa da lista
        /// </summary>
        /// <returns>Alterar tarefa da lista</returns>
        // PUT action = Atualizar
        [HttpPut("{id}")]
        public IActionResult Update(int id, ItemTarefa tarefa)
        {
            // This code will update the tarefa and return a result
            var existingTarefa = TarefaServices.Get(id);
            if (existingTarefa is null)
                return NotFound();

            //if (id != tarefa.Id)
            //    return BadRequest();

            tarefa.Id = id;

            if (TarefaServices.itsnew(tarefa) == false)
            {
                return BadRequest();
            }

            

            TarefaServices.Update(tarefa);

            return NoContent();

        }

        /// <summary>
        /// Remove tarefa da lista
        /// </summary>
        /// <returns>Deleta a tarefa da lista</returns>
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