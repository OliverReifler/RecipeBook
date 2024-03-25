using MauiLib.Dtos;
using MauiLib.Models;
using System.Linq.Expressions;

namespace MauiLib.Extentions
{
    public static class Selectors
    {
        public static Expression<Func<Recipe, RecipeListDto>> RecipeToRecipeListDto =>
            r => new RecipeListDto
            {
                Id = r.Id,
                Name = r.Name,
                Images = r.Images,
            };
    }
}