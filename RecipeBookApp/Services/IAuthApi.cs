using RecipeBook.Domain.Dtos;
using Refit;

namespace RecipeBookApp.Services
{
    public interface IAuthApi
    {
        //name clash?
        [Post("/api/AuthController/login")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto);

        [Post("/api/AuthController/register")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto registerDto);
    }
}