using MauiLib.Models;

namespace MauiLib.Interfaces
{
    public interface IRecipeBookService
    {
        Task<Recipe> CreateRecipeAsync(Recipe recipe);

        Task<Recipe> UpdateRecipeAsync(Recipe recipe);

        Task<Recipe> GetRecipeByIdAsync(int id);

        Task<IEnumerable<Recipe>> GetAllRecipes();

        Task<IEnumerable<Recipe>> GetLatestRecipes(int count);
    }
}