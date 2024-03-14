using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Ingredient : IEntity
    {
        [Key]
        public int Id { get; set; }
        //public List<int>? RecipeId { get; set; } = new List<int>();
        public string? Name { get; set; }

        public string? Category { get; set; }

        //public ICollection<Recipe>? Recipes { get; set; }
    }
}