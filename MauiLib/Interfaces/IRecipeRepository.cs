using MauiLib.Models;

namespace MauiLib.Interfaces
{
    public interface IRecipeRepository
    {
        public IQueryable<Recipe> GetLatestRecipes(int count);
    }
}