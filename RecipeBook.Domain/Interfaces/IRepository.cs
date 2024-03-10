using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);

        Task<Ingredient> CreateAsync(Ingredient entity);

        Task Delete(int id);

        Task<T?> GetByID(int id);

        IQueryable<T> GetAll();

        Task SaveChangesAsync();
    }
}