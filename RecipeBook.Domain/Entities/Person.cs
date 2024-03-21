using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Person : IEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}