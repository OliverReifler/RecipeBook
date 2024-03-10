using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBook.Business.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly IRepository<Recipe> _efRepository;

        public RecipeBookService(IRepository<Recipe> efRepository)
        {
            _efRepository = efRepository;
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            if (_efRepository.GetAllRecipes().Any(x => x.Name == recipe.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _efRepository.CreateAsync(recipe);
            await _efRepository.SaveChangesAsync();
            return recipe;
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            if (_efRepository.GetAllIngredients().Any(x => x.Name == ingredient.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _efRepository.CreateAsync(ingredient);
            await _efRepository.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            Recipe recipe = await _efRepository.GetByIdAsync(id);

            //Recipe recipe = await _efRepository.GetRecipeByIdAsync(id);

            if (recipe != null)
            {
                return recipe;
            }
            throw new ArgumentException("Doesnt Exist/not found");
        }
    }
}