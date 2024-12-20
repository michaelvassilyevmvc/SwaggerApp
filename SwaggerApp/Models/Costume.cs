using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaggerApp.Models
{
    public class Costume
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public ICollection<Lot> Items { get; set; }
    }
}
