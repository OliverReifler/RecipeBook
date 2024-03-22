using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using RecipeBook.Business.Services;
using RecipeBook.Database;
using RecipeBook.Database.Repository;
using RecipeBook.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string? cs = builder.Configuration.GetConnectionString("RecipeBook");

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jqtOptions => jqtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration));

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipeBook", Version = "v1" }))
//.AddCors(o => o.AddPolicy("myCorsPolicy", builder =>
//builder.AllowAnyHeader()
//        .AllowAnyOrigin()
//        .AllowAnyMethod()));
    .AddDbContext<DataContext>()
    .AddScoped<IRecipeBookService, RecipeBookService>()
    .AddScoped<IIngredientService, IngredientService>()
    .AddScoped<IReviewService, ReviewService>()
    .AddScoped<ITagService, TagService>()
    .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
    .AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository))
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<TokenService>()
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
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();