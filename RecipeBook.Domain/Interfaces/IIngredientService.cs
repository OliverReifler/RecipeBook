using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);

        Task<Ingredient?> UpdateIngredient(Ingredient ingredient);

        Task<IEnumerable<Ingredient>> GetAllIngredients();

        Task<Ingredient> GetIngredientByIdAsync(int id);
    }
}