using Microsoft.OpenApi.Models;
using RecipeBook.Business.Services;
using RecipeBook.Database;
using RecipeBook.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string? cs = builder.Configuration.GetConnectionString("RecipeBook");

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipeBook", Version = "v1" }))
//.AddCors(o => o.AddPolicy("myCorsPolicy", builder =>
//builder.AllowAnyHeader()
//        .AllowAnyOrigin()
//        .AllowAnyMethod()));
    .AddDbContext<DataContext>()
    .AddScoped<IRecipeBookService, RecipeBookService>()
    .AddScoped<ITagService, TagService>()
    .AddScoped<IIngredientService, IngredientService>()
    .AddScoped<IReviewService, ReviewService>()
    .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipeBook");
    });
}
app.UseHttpsRedirection()
    .UseRouting()
    .UseAuthorization();
app.MapControllers();

app.Run();