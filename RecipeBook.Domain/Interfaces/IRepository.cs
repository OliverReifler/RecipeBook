namespace RecipeBook.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);

        IQueryable<T> GetAll();

        Task<T?> GetByIdAsync(int id);

        Task Delete(int id);

        Task SaveChangesAsync();
    }
}