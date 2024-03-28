using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("authcontroller")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto)
        {
            return await _authService.LoginAsync(loginDto);
        }

        [HttpPost("register")]
        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto registerDto)
        {
            return await _authService.RegisterAsync(registerDto);
        }
    }
}