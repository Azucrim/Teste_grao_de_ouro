using API.Models;


namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TarefaContext context)
        {

            if (context.Tarefas.Any())
            {
                return;   // DB has been seeded
            }

            var tarefas = new Tarefa[]
            {
                new Tarefa
                    {
                        nome = "teste1",
                        estado = true,
                        
                    },
                new Tarefa
                    {
                        nome = "teste2",
                        estado = false,

                    },
                new Tarefa
                    {
                        nome = "teste3",
                        estado = true,

                    },
            };

            context.Tarefas.AddRange(tarefas);
            context.SaveChanges();
        }
    }
}