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
            if (_efRepository.GetAll().Any(x => x.Name == recipe.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _efRepository.CreateAsync(recipe);
            await _efRepository.SaveChangesAsync();
            return recipe;
        }

        public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            if (_efRepository.GetAll().Any(x => x.Name == ingredient.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _efRepository.CreateAsync(ingredient);
            await _efRepository.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            Recipe? recipe = await _efRepository.GetByID(id);

            if (recipe != null)
            {
                return recipe;
            }
            throw new ArgumentException("Doesnt Exist/not found");
        }
    }
}