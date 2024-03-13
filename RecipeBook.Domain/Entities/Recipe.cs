using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Recipe : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Ingredient>? ListOfIngredients { get; set; }

        public string? Preperation { get; set; }
    }
}