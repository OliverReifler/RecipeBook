using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("AuthController")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ApiResponse<AuthResponseDto>> Login(LoginRequestDto loginDto)
        {
            return await _authService.LoginAsync(loginDto);
        }

        [HttpPost("register")]
        public async Task<ApiResponse<AuthResponseDto>> Register(RegisterRequestDto registerDto)
        {
            return await _authService.RegisterAsync(registerDto);
        }
    }
}