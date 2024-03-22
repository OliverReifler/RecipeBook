using Microsoft.EntityFrameworkCore;
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

        public async Task<T> UpdateAsync(T entity)
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            _dataContext.Remove(await GetByIdAsync(id));
            await _dataContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        public IQueryable<T> GetTenLatest()
        {
            return _dataContext.Set<T>().TakeLast<T>(10);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dataContext.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}