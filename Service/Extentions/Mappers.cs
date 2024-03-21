using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Business.Extentions
{
    public static class Mappers
    {
        public static RecipeDto MapToRecipeDto(this Recipe r)
        {
            return new RecipeDto()
            {
                Name = r.Name,
                Instructions = r.Instructions
            };
        }
    }
}