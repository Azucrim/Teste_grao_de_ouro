using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class TarefaService
    {

        private readonly TarefaContext _context;


        public TarefaService(TarefaContext context)
        {
            _context = context;
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _context.Tarefas
                .AsNoTracking()
                .ToList();
        }

        public Tarefa? GetById(int id)
        {
            return _context.Tarefas                
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public List<Tarefa> GetAllDone()
        {

            List<Tarefa> result = new List<Tarefa>();

            foreach (Tarefa ta in _context.Tarefas)
            {
                if (ta.estado == true)
                {

                    result.Add(ta);

                }
            }

            return result;

        }

        public Tarefa Create(Tarefa newTarefa)
        {
            _context.Tarefas.Add(newTarefa);
            _context.SaveChanges();

            return newTarefa;
        }

        public bool itsnew(Tarefa newtarefa)
        {

            bool aux = true;

            foreach (var tarefa in _context.Tarefas)
            {
                if (tarefa.nome == newtarefa.nome)
                {
                    return false;
                }
            }

            return aux;

        }

        public void Update(int id,Tarefa tarefa)
        {          

            var ToUpdate = _context.Tarefas.Find(id);

            if (ToUpdate is null)
            {
                throw new NullReferenceException("Tarefa does not exist");
            }

            ToUpdate.nome = tarefa.nome;
            ToUpdate.estado= tarefa.estado;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var tarefaToDelete = _context.Tarefas.Find(id);
            if (tarefaToDelete is not null)
            {
                _context.Tarefas.Remove(tarefaToDelete);
                _context.SaveChanges();
            }
        }

    }
}
