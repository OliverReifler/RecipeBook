using RecipeBook.Domain.Interfaces;

namespace RecipeBook.Domain.Entities
{
    public record Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}