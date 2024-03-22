using RecipeBook.Domain.Dtos;

namespace RecipeBook.Domain.Interfaces
{
    public interface IAuthService
    {
        public Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginRequestDto);

        public Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto registerRequestDto);
    }
}