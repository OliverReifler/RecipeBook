using MauiLib.Interfaces;
using MauiLib.Models;

namespace MauiLib.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> _repository;

        public IngredientService(IRepository<Ingredient> repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            if (_repository.GetAll().Any(x => x.Name == ingredient.Name))
            {
                throw new ArgumentException("Allready exists");
            }
            await _repository.CreateAsync(ingredient);
            await _repository.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> UpdateIngredient(Ingredient ingredient)
        {
            return await _repository.UpdateAsync(ingredient);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new ArgumentException("Ingredient Id Doesnt Exist/not found");
        }
    }
}