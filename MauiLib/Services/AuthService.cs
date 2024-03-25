using MauiLib.Dtos;
using MauiLib.Interfaces;
using MauiLib.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiLib.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenService _tokenService;
        private readonly IRepository<User> _userRepository;

        public AuthService(TokenService tokenService, IRepository<User> userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
        {
            User DbUser = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == loginRequestDto.Email);
            if (DbUser is null)
                return ApiResponse<AuthResponseDto>.Fail("User does not exist");
            if (DbUser.Password != loginRequestDto.Password)
                return ApiResponse<AuthResponseDto>.Fail("Incorrect Password");

            string token = _tokenService.GenerateJwt(DbUser);
            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(DbUser.Id, DbUser.Name, token));
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            User? existingUser = await _userRepository.GetAll().SingleOrDefaultAsync(u => u.Email == registerRequestDto.Email);

            if (existingUser is not null)
                return ApiResponse<AuthResponseDto>.Fail("Email allready eists");
            User user = new()
            {
                Email = registerRequestDto.Email,
                Password = registerRequestDto.Password,
                Name = registerRequestDto.Name,
            };
            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();
            string token = _tokenService.GenerateJwt(user);

            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(user.Id, user.Name, token));
        }
    }
}