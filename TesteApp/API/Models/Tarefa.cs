using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? nome { get; set; }
        public bool estado { get; set; } = false;

    }
}
