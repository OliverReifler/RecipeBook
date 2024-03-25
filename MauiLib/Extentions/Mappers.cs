using MauiLib.Dtos;
using MauiLib.Models;

namespace MauiLib.Extentions
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