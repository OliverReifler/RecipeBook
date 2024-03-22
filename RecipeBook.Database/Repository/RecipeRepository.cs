using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Database.Repository
{
    [ExcludeFromCodeCoverage]
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Recipe> GetLatestRecipes(int count)
        {
            return _context.Recipes.TakeLast(count).AsQueryable();
        }
    }
}