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
            //Ingredient Banana = new() { Id = 3, Name = "Banana" };
            //Ingredient Cherry = new() { Id = 4, Name = "Cherry" };
            //List<Ingredient> ListOne = new() { Banana, Cherry };

            //Recipe recipe1 = new Recipe() { Id = 5, Name = "recipe1", ListOfIngredients = null };
            //Recipe recipe2 = new Recipe() { Id = 6, Name = "recipe2" };
            //List<Ingredient> Ingredients = new List<Ingredient> { (new Ingredient { Id = 1, Name = "Apple" }), (new Ingredient { Id = 2, Name = "Orange" }) };

            //modelBuilder.Entity<Ingredient>().HasData(Banana, Cherry);
            //modelBuilder.Entity<Recipe>().HasData(recipe2, recipe1);
            modelBuilder.Entity<Recipe>().HasMany(x => x.ListOfIngredients).WithMany().UsingEntity(j => j.ToTable("RecipeIngredients"));
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Phone>().Property(x => x.PriceExVat).HasPrecision(18, 2);

            modelBuilder.Entity<Recipe>().Navigation(x => x.ListOfIngredients).AutoInclude();
        }
    }
}