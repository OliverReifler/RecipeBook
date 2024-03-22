using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBook.Business.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly IRepository<Recipe> _repository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeBookService(IRepository<Recipe> repository, IRecipeRepository recipeRepository)
        {
            _repository = repository;
            _recipeRepository = recipeRepository;
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

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
        {
            await _repository.UpdateAsync(recipe);
            await _repository.SaveChangesAsync();
            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new ArgumentException("Recipe Id Doesnt Exist/not found");
        }

        public async Task<IEnumerable<Recipe>> GetLatestRecipes(int count)
        {
            return _recipeRepository.GetLatestRecipes(count);
        }
    }
}