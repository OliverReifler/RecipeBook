using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Dtos
{
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        public required string Name { get; set; }
    }
}