using Microsoft.EntityFrameworkCore;
using API.Models;
//using TesteApp.Client;

namespace API.Data
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options)
            : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    }

}