using System.ComponentModel.DataAnnotations;

namespace TesteApp.Client
{
    public class ItemTarefa
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? nome { get; set; }
        public bool estado { get; set; } = false;
    }
}
