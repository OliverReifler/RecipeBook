using RecipeBook.Domain.Entities;
using Refit;

namespace RecipeBookApp.Services
{
    [Headers("Authorization: Bearer")]
    public interface IUserApi
    {
        [Get("/api/UserController/GetLatest")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<IEnumerable<Recipe>>> GetLatestRecipes(int count);
    }
}