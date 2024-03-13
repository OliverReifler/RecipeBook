using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBook.Business.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeBookService(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
        {
            if (_repository.GetAll().Any(x => x.Name == recipe.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _repository.CreateAsync(recipe);
            await _repository.SaveChangesAsync();
            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            Recipe recipe = await _repository.GetByIdAsync(id);

            if (recipe != null)
            {
                return recipe;
            }
            throw new ArgumentException("Doesnt Exist/not found");
        }

        //public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        //{
        //    if (_efRepository.GetAllIngredients().Any(x => x.Name == ingredient.Name))
        //    {
        //        throw new ArgumentException("Allready exists");
        //    }
        //    await _efRepository.CreateAsync(ingredient);
        //    await _efRepository.SaveChangesAsync();
        //    return ingredient;
        //}
    }
}