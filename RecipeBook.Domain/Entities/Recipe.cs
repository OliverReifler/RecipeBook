using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Recipe : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
        public string? Instructions { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<Tag>? Tags { get; set; }

        public string[]? Images { get; set; }
    }
}