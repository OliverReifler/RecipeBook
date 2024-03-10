using Microsoft.OpenApi.Models;
using RecipeBook.Business.Services;
using RecipeBook.Database;
using RecipeBook.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("V1", new OpenApiInfo { Title = "Test", Version = "v1" }));
//.AddCors(o => o.AddPolicy("myCorsPolicy", builder =>
//builder.AllowAnyHeader()
//        .AllowAnyOrigin()
//        .AllowAnyMethod()));
builder.Services.AddDbContext<DataContext>()
    .AddScoped<IRecipeBookService, RecipeBookService>()
    .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseRouting()
    .UseAuthorization();
app.MapControllers();

app.Run();