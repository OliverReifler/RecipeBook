using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public record Review
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }

        public int PersonId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}