using TesteApp.Client;

namespace API.Services
{
    public class TarefaServices
    {

        static List<ItemTarefa> Tarefas { get; }
        static int nextId = 3;
        static TarefaServices()
        {
            Tarefas = new List<ItemTarefa>
            {
                new ItemTarefa { Id = 1, nome = "Teste 1", estado = false },
                new ItemTarefa { Id = 2, nome = "Teste 2", estado = true }
            };
        }

        public static List<ItemTarefa> GetAll() => Tarefas;

        public static ItemTarefa? Get(int id) => Tarefas.FirstOrDefault(p => p.Id == id);

        public static void Add(ItemTarefa tarefa)
        {
            tarefa.Id = nextId++;
            Tarefas.Add(tarefa);
        }

        public static List<ItemTarefa> GetAllDone()
        {
            List<ItemTarefa> tarefax = Tarefas;
            List<ItemTarefa> result = new List<ItemTarefa>();

            foreach (ItemTarefa ta in tarefax)
            {
                if (ta.estado == true)
                {

                    result.Add(ta);

                }
            }

            return result;

        }


        public static void Delete(int id)
        {
            var tarefa = Get(id);
            if (tarefa is null)
                return;

            Tarefas.Remove(tarefa);
        }

        public static void Update(ItemTarefa tarefa)
        {
            var index = Tarefas.FindIndex(p => p.Id == tarefa.Id);
            if (index == -1)
                return;

            Tarefas[index] = tarefa;
        }

    }
}
