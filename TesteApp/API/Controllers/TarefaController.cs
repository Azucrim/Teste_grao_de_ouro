using API.Models;
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {

        TarefaService _service;

        public TarefaController(TarefaService service)
        {
            _service = service;
        }

        // GET all action       
        /// <summary>
        /// Lista todas as Tarefas do banco de dados
        /// </summary>
        /// <returns>Returns a list of Tarefas</returns>
        [HttpGet]
        public IEnumerable<Tarefa> GetAll()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// Lista todas as Tarefas do banco de dados com status concluído
        /// </summary>
        /// <returns>Returns a list of Tarefas Done</returns>
        [HttpGet("Done")]
        public List<Tarefa> GetAllDone()
        {
            return _service.GetAllDone();
        }

        /// <summary>
        /// Busca Tarefa pelo seu id no banco de dados
        /// </summary>
        /// <returns>Returns Tarefa by id</returns>
        [HttpGet("{id}")]
        public ActionResult<Tarefa> GetById(int id)
        {
            var tarefa = _service.GetById(id);

            if (tarefa is not null)
            {
                return tarefa;
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Cria um Tarefa nova no banco de dados
        /// </summary>
        /// <returns>Create a new task</returns>
        // POST action = Criar
        [HttpPost]
        public IActionResult Create(Tarefa newTarefa)
        {
            bool x=_service.itsnew(newTarefa);
            if (x == true)
            {
                var tarefa = _service.Create(newTarefa);
                return CreatedAtAction(nameof(GetById), new { id = newTarefa!.Id }, newTarefa);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Alterar tarefa do banco de dados
        /// </summary>
        /// <returns>Alterar tarefa da lista</returns>
        // PUT action = Atualizar
        [HttpPut("{id}/update")]
        public IActionResult Update(int id, Tarefa tarefa)
        {
            var ToUpdate = _service.GetById(id);

            if (ToUpdate is not null)
            {
                if (_service.itsnew(tarefa) == false)
                {
                    return BadRequest("Já existe");
                }
                _service.Update(id,tarefa);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove tarefa do banco de dados
        /// </summary>
        /// <returns>Deleta a tarefa da lista</returns>
        // DELETE action 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Tarefa = _service.GetById(id);

            if (Tarefa is not null)
            {
                _service.DeleteById(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
