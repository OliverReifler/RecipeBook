using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Database
{
    [ExcludeFromCodeCoverage]
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _dataContext;

        public EFRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
            return entity;
        }

        public async Task<Ingredient> CreateAsync(Ingredient ingredient)
        {
            await _dataContext.AddAsync(ingredient);
            return ingredient;
        }

        public async Task Delete(int id)
        {
            _dataContext.Remove(GetByID(id));
            await _dataContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        public async Task<T?> GetByID(int id)
        {
            return await _dataContext.Set<T>()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}