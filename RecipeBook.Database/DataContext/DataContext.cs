using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Database
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasMany(x => x.Ingredients).WithMany().UsingEntity(j => j.ToTable("RecipeIngredients"));
            modelBuilder.Entity<Recipe>().HasMany(x => x.Reviews).WithOne();
            modelBuilder.Entity<Recipe>().HasMany(x => x.Tags).WithMany().UsingEntity(j => j.ToTable("RecipeTags"));

            modelBuilder.Entity<Recipe>().Navigation(x => x.Ingredients).AutoInclude();
            modelBuilder.Entity<Recipe>().Navigation(x => x.Reviews).AutoInclude();
            modelBuilder.Entity<Recipe>().Navigation(x => x.Tags).AutoInclude();
        }
    }
}