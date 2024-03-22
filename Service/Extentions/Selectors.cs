using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Entities;
using System.Linq.Expressions;

namespace RecipeBook.Business.Extentions
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