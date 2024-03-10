using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);

        Task<Ingredient> CreateAsync(Ingredient entity);

        Task Delete(int id);

        Task<Recipe?> GetRecipeByIdAsync(int id);

        Task<T?> GetByIdAsync(int id);

        IQueryable<Ingredient> GetAllIngredients();

        IQueryable<Recipe> GetAllRecipes();

        Task SaveChangesAsync();
    }
}