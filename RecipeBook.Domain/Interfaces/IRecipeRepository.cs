using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IRecipeRepository
    {
        public IQueryable<Recipe> GetLatestRecipes(int count);
    }
}