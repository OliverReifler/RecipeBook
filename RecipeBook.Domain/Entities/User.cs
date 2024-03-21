using RecipeBook.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class User : IEntity
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name { get; set; }

        [Required, MaxLength(100)]
        public required string Email { get; set; }

        [Required, MaxLength(20)]
        public required string Password { get; set; }
    }
}