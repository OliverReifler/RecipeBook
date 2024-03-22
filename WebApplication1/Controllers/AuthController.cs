using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("AuthController")]
    public class AuthController : ControllerBase
    {
        //https://www.youtube.com/watch?v=1js5U3gWamg
        //54:50

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginDto)
        {
            try
            {
                return Ok(await _authService.LoginAsync(loginDto));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerDto)
        {
            try
            {
                return Ok(await _authService.RegisterAsync(registerDto));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}