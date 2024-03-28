using RecipeBook.Domain.Entities;
using Refit;

namespace RecipeBookApp.Services
{
    [Headers("Authorization: Bearer")]
    public interface IUserApi
    {
        [Get("/usercontroller/getlatest")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<IEnumerable<Recipe>>> GetLatestRecipes(int count);
    }
}