using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Tag : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}