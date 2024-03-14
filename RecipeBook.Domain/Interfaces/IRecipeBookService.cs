using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IRecipeBookService
    {
        Task<Recipe> CreateRecipeAsync(Recipe recipe);

        Task<Recipe> UpdateRecipeAsync(Recipe recipe);

        Task<Recipe> GetRecipeByIdAsync(int id);

        Task<IEnumerable<Recipe>> GetAllRecipes();

        //Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    }
}