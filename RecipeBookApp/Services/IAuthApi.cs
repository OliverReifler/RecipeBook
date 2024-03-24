using RecipeBook.Domain.Dtos;
using Refit;

namespace RecipeBookApp.Services
{
    public interface IAuthApi
    {
        //name clash?
        [Post("/api/AuthController/login")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> Login(LoginRequestDto loginDto);

        [Post("/api/AuthController/register")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> Register(RegisterRequestDto registerDto);
    }
}