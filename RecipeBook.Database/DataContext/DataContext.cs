using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RecipeBook.Database
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Person> Persons { get; set; }

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
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RecipeBook");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasMany(x => x.Ingredients).WithMany().UsingEntity(j => j.ToTable("RecipeIngredients"));
            modelBuilder.Entity<Recipe>().Navigation(x => x.Ingredients).AutoInclude();
            modelBuilder.Entity<Recipe>().HasMany(x => x.Reviews).WithOne().IsRequired();
            modelBuilder.Entity<Recipe>().Navigation(x => x.Reviews).AutoInclude();
            modelBuilder.Entity<Recipe>().HasMany(x => x.Tags).WithMany().UsingEntity(j => j.ToTable("RecipeTags"));
            modelBuilder.Entity<Recipe>().Navigation(x => x.Tags).AutoInclude();
            modelBuilder.Entity<Review>().HasMany(x => x.Persons).WithMany().UsingEntity(j => j.ToTable("ReviewPersons"));
            modelBuilder.Entity<Review>().Navigation(x => x.Persons).AutoInclude();

            modelBuilder.Entity<Recipe>().HasData(SeedRecipes());
        }

        //TODO:Create seeding after models updated
        private static List<Recipe> SeedRecipes()
        {
            List<Recipe> Recipes = new()
            {
                new () {Name = "Omelette", Id = 1, Instructions = "Crack open egg, Bake for 3-4 minutes on each side" },
                new () {Name = "Sunny-Side-Up", Id = 2, Instructions = "Crack open egg, Bake for 6-8 minutes on one side"}
            };

            return Recipes;
        }

        //return new List<Recipe>()
        //{
        //    new Recipe() {Name = "Omelette", Id = 1, Instructions = "Crack open egg, Bake for 3-4 minutes on each side",
        //    Tags = new List<Tag>{new Tag(){Id = 1, Title = "Egg"} },
        //    Ingredients = new List<Ingredient>(){
        //        new Ingredient() { Id = 1, Name = "Egg", Category = "Animal Products"},
        //        new Ingredient(){ Id = 2, Name = "Salt", Category = "Spices"}
        //    },
        //    Reviews = new List<Review>() {
        //        new Review(){Id = 1, ReviewText = "Nothing Special", Persons = new List<Person> { new Person() { Id = 1, Name = "James Yolk"} }}
        //    }
        //}
        //};
        //}
    }
}