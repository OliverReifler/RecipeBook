using RecipeBook.Domain.Dtos;
using Refit;

namespace RecipeBookApp.Services
{
    [Headers("Content-Type: application/json;accept: text/plain")]
    public interface IAuthApi
    {
        [Post("/authcontroller/login")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> LoginAsync([Body] LoginRequestDto loginDto);

        [Post("/authcontroller/register")]
        Task<RecipeBook.Domain.Dtos.ApiResponse<AuthResponseDto>> RegisterAsync([Body] RegisterRequestDto registerDto);
    }
}
