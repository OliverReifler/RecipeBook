using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IRecipeBookService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<Recipe> CreateRecipe(Recipe recipe);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Recipe> GetRecipeByIdAsync(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<Recipe> AddIngredientToRecipe(string ingredient, string recipe);
    }
}