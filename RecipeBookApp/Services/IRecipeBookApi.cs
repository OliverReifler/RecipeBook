using RecipeBook.Domain.Entities;
using Refit;

namespace RecipeBookApp.Services
{
    public interface IRecipeBookApi
    {
        [Get("/api/RecipeBookController/GetAllRecipes")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<IEnumerable<Recipe>>> GetAllRecipes();
    }
}