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
        Task<Ingredient> CreateIngredient(Ingredient ingredient);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Recipe> GetRecipeById(int id);
    }
}