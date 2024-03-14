using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Review : IEntity
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Person> Persons { get; set; } = new List<Person>();
        public DateTime Created { get; set; } = DateTime.Now;
        public string? ReviewText { get; set; }
    }
}